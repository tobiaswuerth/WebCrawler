using System;
using System.Collections.Generic;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Data;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Repository;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Mapper
{
    public static class MapperWebpage
    {
        private static readonly WebCrawlerRepository WebCrawlerRepository = new WebCrawlerRepository();

        public static List<Webpage> Map(WebCrawlerDataSet.WebpageDataTable webpageData)
        {
            List<Webpage> webpages = new List<Webpage>();

            foreach (WebCrawlerDataSet.WebpageRow row in webpageData.Rows)
            {
                Boolean isRootNode = row.IsRootUriHashNull();
                Boolean isCrawled = !row.IsLastCrawledDateNull() && !row.IsWebpageMimeNull() &&
                                    !row.IsWebpageTitleNull();

                if (isRootNode && isCrawled)
                {
                    webpages.Add(new Webpage(row.WebpageId, new Webaddress(new Uri(row.WebpageUri)), row.WebpageTitle,
                        row.WebpageMime, new List<Webpage>(), row.LastCrawledDate, row.Status));
                }
                else if (isRootNode && !isCrawled)
                {
                    webpages.Add(new Webpage(row.WebpageId, new Webaddress(new Uri(row.WebpageUri))));
                }
                else if (!isRootNode && !isCrawled)
                {
                    webpages.Add(new Webpage(row.WebpageId, new Webaddress(new Uri(row.WebpageUri)), row.Depth,
                        WebCrawlerRepository.GetRootPage(Hash.Factory.Create(row.RootUriHash))));
                }
                else if (!isRootNode && isCrawled)
                {
                    webpages.Add(new Webpage(row.WebpageId, new Webaddress(new Uri(row.WebpageUri)), row.WebpageTitle,
                        row.WebpageMime, new List<Webpage>(), row.LastCrawledDate, row.Depth,
                        WebCrawlerRepository.GetRootPage(Hash.Factory.Create(row.RootUriHash)), row.Status));
                }
            }

            return new List<Webpage>(webpages);
        }
    }
}