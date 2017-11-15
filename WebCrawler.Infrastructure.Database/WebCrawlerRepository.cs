using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebCrawler.DomainModel.Entities;
using WebCrawler.Infrastructure.Data;
using WebCrawler.Infrastructure.Data.WebCrawlerDataSetTableAdapters;
using WebCrawler.Infrastructure.Mapper;
using Type = WebCrawler.DomainModel.Entities.Type;

namespace WebCrawler.Infrastructure.Database
{
    public class WebCrawlerRepository : IWebCrawlerRepository
    {
        #region TableAdapters

        private WebpageTableAdapter _webpageTableAdapter;

        private WebpageTableAdapter WebpageTableAdapter
        {
            get
            {
                return _webpageTableAdapter ?? (_webpageTableAdapter = new WebpageTableAdapter());
            }
        }

        private MailTableAdapter _mailTableAdapter;

        public MailTableAdapter MailTableAdapter
        {
            get
            {
                return _mailTableAdapter ?? (_mailTableAdapter = new MailTableAdapter());
            }
        }

        private StatusTableAdapter _statusTableAdapter;

        public StatusTableAdapter StatusTableAdapter
        {
            get
            {
                return _statusTableAdapter ?? (_statusTableAdapter = new StatusTableAdapter());
            }
        }

        private TypeTableAdapter _typeTableAdapter;

        public TypeTableAdapter TypeTableAdapter
        {
            get
            {
                return _typeTableAdapter ?? (_typeTableAdapter = new TypeTableAdapter());
            }
        }

        #endregion

        private Dictionary<String, Type> _types;
        private Dictionary<UInt32, Status> _status;

        public Dictionary<String, Type> GetTypes()
        {
            if(null == _types)
            {
                WebCrawlerDataSet.TypeDataTable typeData = TypeTableAdapter.GetData();
                List<Type> typesList = TypeMapper.Map(typeData);
                _types = typesList.ToDictionary(t => t.Extension);
            }

            return _types;
        }

        public Dictionary<UInt32, Status> GetStatus()
        {
            if(null == _status)
            {
                WebCrawlerDataSet.StatusDataTable statusData = StatusTableAdapter.GetData();
                List<Status> statusList = StatusMapper.Map(statusData);
                _status = statusList.ToDictionary(s => s.StatusId);
            }

            return _status;
        }

        public List<Webpage> GetAll()
        {
            return null;
        }
        
        public Webpage GetByAddressHash(Hash hash)
        {
            WebCrawlerDataSet.WebpageDataTable webpageData = WebpageTableAdapter.GetDataByWebpageAddressHash(hash.HashBytes);
            return null;
        }

        public void SaveWebPage(Webpage webpage)
        {
            if(!webpage.Validate())
            {
                throw new InvalidDataException("Webpage is not valid");
            }
        }
    }
}