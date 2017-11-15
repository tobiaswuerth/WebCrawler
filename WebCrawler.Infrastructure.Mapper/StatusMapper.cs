using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.DomainModel.Entities;
using WebCrawler.Infrastructure.Data;

namespace WebCrawler.Infrastructure.Mapper
{
    public static class StatusMapper
    {
        public static List<Status> Map(WebCrawlerDataSet.StatusDataTable statusData)
        {
            if(null == statusData)
            {
                throw new ArgumentNullException("statusData");
            }
            return (from WebCrawlerDataSet.StatusRow row in statusData.Rows select Map(row)).ToList();
        }

        public static Status Map(WebCrawlerDataSet.StatusRow statusRow)
        {
            if(null == statusRow)
            {
                throw new ArgumentNullException("statusRow");
            }
            return new Status
                   {
                       StatusId = statusRow.StatusId,
                       Name = statusRow.Name
                   };
        }
    }
}