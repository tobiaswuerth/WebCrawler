using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Infrastructure.Data;
using Type = WebCrawler.DomainModel.Entities.Type;

namespace WebCrawler.Infrastructure.Mapper
{
    public static class TypeMapper
    {
        public static List<Type> Map(WebCrawlerDataSet.TypeDataTable typeData)
        {
            if(null == typeData)
            {
                throw new ArgumentNullException("typeData");
            }
            return (from WebCrawlerDataSet.TypeRow row in typeData.Rows select Map(row)).ToList();
        }

        public static Type Map(WebCrawlerDataSet.TypeRow typeRow)
        {
            if(null == typeRow)
            {
                throw new ArgumentNullException("typeRow");
            }
            return new Type
                   {
                       TypeId = typeRow.TypeId,
                       Extension = typeRow.Extension,
                       Description = typeRow.Description,
                       MIME = typeRow.MIME
                   };
        }
    }
}