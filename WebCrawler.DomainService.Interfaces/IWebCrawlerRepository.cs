using System;
using System.Collections.Generic;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;

namespace ch.wuerth.tobias.WebCrawler.DomainService.Interfaces
{
    public interface IWebCrawlerRepository
    {
        List<Webpage> GetByRootAndStatus(Webpage root, Int32 status, Int32 maxRowsReturned, Int32 maxDepth);
        void Save(Webpage webpage);
        void Save(List<Webpage> webpages);
        void ResetStatus();
        Webpage GetRootPageByWebaddressHash(Webpage rootPage);
    }
}