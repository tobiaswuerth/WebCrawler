using System;
using System.Collections.Generic;
using WebCrawler.DomainModel.Entities;
using Type = WebCrawler.DomainModel.Entities.Type;

namespace WebCrawler.Infrastructure.Database
{
    public interface IWebCrawlerRepository
    {
        Dictionary<String, Type> GetTypes();
        Dictionary<UInt32, Status> GetStatus();
        List<Webpage> GetAll();
        Webpage GetByAddressHash(Hash hash);
        void SaveWebPage(Webpage webpage);
    }
}