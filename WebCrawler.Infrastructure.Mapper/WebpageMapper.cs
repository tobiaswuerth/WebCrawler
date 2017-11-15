using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.DomainModel.Entities;
using WebCrawler.Infrastructure.Data;
using Type = WebCrawler.DomainModel.Entities.Type;

namespace WebCrawler.Infrastructure.Mapper
{
    public static class WebpageMapper
    {
        public static List<Webpage> Map(WebCrawlerDataSet.WebpageDataTable webpageData, Status status, Type type)
        {
            if(null == webpageData)
            {
                throw new ArgumentNullException("webpageData");
            }
            return (from WebCrawlerDataSet.WebpageRow row in webpageData.Rows select Map(row, status, type)).ToList();
        }

        public static Webpage Map(WebCrawlerDataSet.WebpageRow webpageRow, Status status, Type type)
        {
            if(null == webpageRow)
            {
                throw new ArgumentNullException("webpageRow");
            }
            if(status.StatusId.Equals(webpageRow.StatusId))
            {
                throw new ArgumentException("Status object does not match row status", "status");
            }
            if(type.TypeId.Equals(webpageRow.TypeId))
            {
                throw new ArgumentException("Type object does not match row type", "type");
            }

            Webpage wp = new Webpage(webpageRow.WebpageId, webpageRow.WebpageAddress, status, type);
            if(!webpageRow.IsLastCrawledDateNull())
            {
                wp.LastCrawledDate = webpageRow.LastCrawledDate;
                wp.WebpageTitle = webpageRow.WebpageTitle;
            }

            return wp;
        }
    }
}