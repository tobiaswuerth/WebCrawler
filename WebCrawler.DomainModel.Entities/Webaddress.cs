using System;

namespace ch.wuerth.tobias.WebCrawler.DomainModel.Entities
{
    public class Webaddress
    {
        #region Constructor

        public Webaddress(Uri uri)
        {
            Uri = uri;
        }

        #endregion

        #region Fields

        private Uri _uri;
        private Hash _uriHash;

        #endregion

        #region Properties

        public Uri Uri
        {
            get { return _uri; }
            private set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }
                if (!value.IsAbsoluteUri)
                {
                    throw new NotSupportedException();
                }

                _uri = value;
                UriHash = Hash.Factory.Create(Uri.AbsoluteUri);
            }
        }

        public Hash UriHash
        {
            get { return _uriHash; }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }

                _uriHash = value;
            }
        }

        #endregion
    }
}