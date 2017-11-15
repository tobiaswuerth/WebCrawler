using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;
using ch.wuerth.tobias.WebCrawler.DomainService.Interfaces;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Data;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Data.WebCrawlerDataSetTableAdapters;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Mapper;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Repository
{
    public class WebCrawlerRepository : IWebCrawlerRepository
    {
        #region Fields

        private WebpageTableAdapter _webpageTableAdapter;

        #endregion

        #region Properties

        private WebpageTableAdapter WebpageTableAdapter
        {
            get { return _webpageTableAdapter ?? (_webpageTableAdapter = new WebpageTableAdapter()); }
        }

        #endregion

        #region Methods READ

        public List<Webpage> GetByRootAndStatus(Webpage root, Int32 status, Int32 maxRowsReturned, Int32 maxDepth)
        {
            WebCrawlerDataSet.WebpageDataTable data =
                WebpageTableAdapter.GetDataStatusAndRootHashMaxDepth(maxRowsReturned, status,
                    root.Webaddress.UriHash.HashBytes, maxDepth);
            data.ToList().ForEach(x => x.Status = -1); // mark as grabbed
            WebpageTableAdapter.Update(data);
            return MapperWebpage.Map(data);
        }

        #endregion

        #region UPDATE / CREATE

        public void Save(Webpage webpage)
        {
            Save(new List<Webpage> {webpage});
        }

        public void Save(List<Webpage> webpages)
        {
            if (null == webpages || webpages.Count == 0)
            {
                return;
            }

            WebCrawlerDataSet.WebpageDataTable webpageData = new WebCrawlerDataSet.WebpageDataTable();

            foreach (Webpage wp in webpages)
            {
                if (null == wp)
                {
                    Console.WriteLine("Invalid webpage ignored");
                    continue;
                }

                WebCrawlerDataSet.WebpageRow webpageRow =
                    Webpage.WebpageType.NewChild != wp.Type && Webpage.WebpageType.NewRoot != wp.Type
                        ? WebpageTableAdapter.GetDataByWebpageId(wp.WebpageId)[0]
                        : webpageData.NewWebpageRow();

                webpageRow.Depth = wp.Depth;
                webpageRow.WebpageUri = wp.Webaddress.Uri.ToString();
                webpageRow.WebpageUriHash = wp.Webaddress.UriHash.HashBytes;
                webpageRow.Status = wp.Status;

                if (Webpage.WebpageType.NewRoot != wp.Type && Webpage.WebpageType.Root != wp.Type &&
                    Webpage.WebpageType.UncrawledRoot != wp.Type)
                {
                    webpageRow.RootUriHash = wp.RootWebpage.Webaddress.UriHash.HashBytes;
                }

                if (Webpage.WebpageType.NewRoot != wp.Type && Webpage.WebpageType.NewChild != wp.Type)
                {
                    webpageRow.WebpageTitle = wp.Title;
                    webpageRow.WebpageMime = wp.Mime;
                    webpageRow.LastCrawledDate = wp.LastCrawledDate;
                    webpageData.ImportRow(webpageRow);
                }
                else
                {
                    webpageData.AddWebpageRow(webpageRow);
                }
            }

            // backup settings to change them temporarily
            Boolean oldContinueUpdateOnError = WebpageTableAdapter.Adapter.ContinueUpdateOnError;
            UpdateRowSource oldUpdateRowSource = WebpageTableAdapter.Adapter.UpdateCommand.UpdatedRowSource;
            UpdateRowSource oldInsertRowSource = WebpageTableAdapter.Adapter.InsertCommand.UpdatedRowSource;
            Int32 oldUpdateBatchSize = WebpageTableAdapter.Adapter.UpdateBatchSize;

            // change settings to allow batch update/insert
            WebpageTableAdapter.Adapter.ContinueUpdateOnError = true;
            WebpageTableAdapter.Adapter.UpdateBatchSize = webpageData.Rows.Count;
            WebpageTableAdapter.Adapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            WebpageTableAdapter.Adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

            // process data
            WebpageTableAdapter.Update(webpageData);

            // restore adapter settings
            WebpageTableAdapter.Adapter.ContinueUpdateOnError = oldContinueUpdateOnError;
            WebpageTableAdapter.Adapter.UpdateBatchSize = oldUpdateBatchSize;
            WebpageTableAdapter.Adapter.UpdateCommand.UpdatedRowSource = oldUpdateRowSource;
            WebpageTableAdapter.Adapter.InsertCommand.UpdatedRowSource = oldInsertRowSource;

            // recursive call for child uris
            foreach (Webpage wp in webpages.Where(x =>
                null != x &&
                (Webpage.WebpageType.UncrawledRoot == x.Type || Webpage.WebpageType.UncrawledChild == x.Type) &&
                x.ChildWebpages.Count > 0))
            {
                Save(wp.ChildWebpages);
            }
        }

        public Webpage GetRootPage(Hash rootHash)
        {
            return MapperWebpage.Map(WebpageTableAdapter.GetDataByWebpageUriHashRootUriHashNull(rootHash.HashBytes))[0];
        }

        /// <summary>
        ///     The crawler has a task buffer. Once he gathered the tasks to do from the database,
        ///     the records will be marked with status -1 to prevent duplicate processing.
        ///     If the crawler does not exit correctly, those status might still be set incorrectly.
        ///     This method resets all status which are set to -1 to 0.
        /// </summary>
        public void ResetStatus()
        {
            WebpageTableAdapter.ResetStatus();
        }

        public Webpage GetRootPageByWebaddressHash(Webpage rootPage)
        {
            return MapperWebpage.Map(
                WebpageTableAdapter.GetDataByWebpageUriHashRootUriHashNull(rootPage.Webaddress.UriHash.HashBytes))[0];
        }

        #endregion
    }
}