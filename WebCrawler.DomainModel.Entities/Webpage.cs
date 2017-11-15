using System;
using System.Collections.Generic;
using ch.wuerth.tobias.WebCrawler.DomainModel.Exceptions;

namespace ch.wuerth.tobias.WebCrawler.DomainModel.Entities
{
    public class Webpage : IDisposable
    {
        #region Enum

        public enum WebpageType
        {
            NewRoot,
            UncrawledRoot,
            Root,
            NewChild,
            UncrawledChild,
            Child
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            _webpageId = null;
            _lastCrawledDate = null;
            _mime = null;
            if (null != _rootWebpage)
            {
                _rootWebpage.Dispose();
                _rootWebpage = null;
            }
            _title = null;
            _webaddress = null;
            if (null != _childWebpages)
            {
                _childWebpages.ForEach(x => x = null);
                _childWebpages.Clear();
                _childWebpages = null;
            }
            _webpageId = null;
        }

        #endregion

        #region Fields

        private Int32? _webpageId;
        private Webaddress _webaddress;
        private String _title;
        private String _mime;
        private List<Webpage> _childWebpages = new List<Webpage>();
        private DateTime? _lastCrawledDate;
        private Int32 _depth;
        private Webpage _rootWebpage;
        private Int32 _status;

        #endregion

        #region Properties

        public Int32 Status
        {
            get { return _status; }
            set
            {
                if (-1 > value)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _status = value;
            }
        }

        public String Title
        {
            get
            {
                if (null == _title)
                {
                    throw new ValueNotSetException();
                }

                return _title;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _title = value;
            }
        }

        public String Mime
        {
            get
            {
                if (_mime == null)
                {
                    throw new ValueNotSetException();
                }

                return _mime;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _mime = value;
            }
        }

        public DateTime LastCrawledDate
        {
            get
            {
                if (!_lastCrawledDate.HasValue)
                {
                    throw new ValueNotSetException();
                }

                return _lastCrawledDate.Value;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _lastCrawledDate = value;
            }
        }

        public Int32 WebpageId
        {
            get
            {
                if (!_webpageId.HasValue)
                {
                    throw new ValueNotSetException();
                }

                return _webpageId.Value;
            }
            set { _webpageId = value; }
        }

        public Int32 Depth
        {
            get { return _depth; }
            set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _depth = value;
            }
        }

        public Webaddress Webaddress
        {
            get { return _webaddress; }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _webaddress = value;
            }
        }

        public List<Webpage> ChildWebpages
        {
            get
            {
                if (null == _childWebpages)
                {
                    throw new ValueNotSetException();
                }

                return _childWebpages;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _childWebpages = value;
            }
        }

        public Webpage RootWebpage
        {
            get
            {
                if (null == _rootWebpage)
                {
                    throw new ArgumentNullException();
                }

                return _rootWebpage;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _rootWebpage = value;
            }
        }

        public WebpageType Type { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor for NewRoot Webpage
        /// </summary>
        public Webpage(Webaddress webaddress)
        {
            Webaddress = webaddress;
            Depth = 0;
            Status = 0;
            Type = WebpageType.NewRoot;
        }

        /// <summary>
        ///     Constructor for UncrawledRoot Webpage
        /// </summary>
        public Webpage(Int32 webpageId, Webaddress webaddress)
        {
            WebpageId = webpageId;
            Webaddress = webaddress;
            Depth = 0;
            Status = 0;
            Type = WebpageType.UncrawledRoot;
        }

        /// <summary>
        ///     Constructor for Root Webpage
        /// </summary>
        public Webpage(Int32 webpageId, Webaddress webaddress, String title, String mime,
            List<Webpage> childChildWebpages, DateTime lastCrawledDate, Int32 status)
        {
            WebpageId = webpageId;
            Webaddress = webaddress;
            Title = title;
            Mime = mime;
            ChildWebpages = childChildWebpages;
            LastCrawledDate = lastCrawledDate;
            Status = status;
            Type = WebpageType.Root;
        }

        /// <summary>
        ///     Constructor for NewChild Webpage
        /// </summary>
        public Webpage(Webaddress webaddress, Int32 depth, Webpage rootWebpage)
        {
            Webaddress = webaddress;
            Depth = depth;
            Status = 0;
            RootWebpage = rootWebpage;
            Type = WebpageType.NewChild;
        }

        /// <summary>
        ///     Constructor for UncrawledChild Webpage
        /// </summary>
        public Webpage(Int32 webpageId, Webaddress webaddress, Int32 depth, Webpage rootWebpage)
        {
            WebpageId = webpageId;
            Webaddress = webaddress;
            Depth = depth;
            Status = 0;
            RootWebpage = rootWebpage;
            Type = WebpageType.UncrawledChild;
        }

        /// <summary>
        ///     Constructor for Child Webpage
        /// </summary>
        public Webpage(Int32 webpageId, Webaddress webaddress, String title, String mime, List<Webpage> childWebpages,
            DateTime lastCrawledDate, Int32 depth, Webpage rootWebpage, Int32 status)
        {
            WebpageId = webpageId;
            Webaddress = webaddress;
            Title = title;
            Mime = mime;
            ChildWebpages = childWebpages;
            LastCrawledDate = lastCrawledDate;
            Depth = depth;
            RootWebpage = rootWebpage;
            Status = status;
            Type = WebpageType.Child;
        }

        #endregion
    }
}