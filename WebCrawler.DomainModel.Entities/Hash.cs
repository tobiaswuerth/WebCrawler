using System;
using System.Security.Cryptography;
using System.Text;
using ch.wuerth.tobias.WebCrawler.DomainModel.Exceptions;

namespace ch.wuerth.tobias.WebCrawler.DomainModel.Entities
{
    public class Hash
    {
        #region Fields

        private Byte[] _hashBytes;

        #endregion

        #region Constructor

        private Hash(Byte[] hash)
        {
            HashBytes = hash;
        }

        #endregion

        #region Properties

        public Byte[] HashBytes
        {
            get
            {
                if (null != _hashBytes)
                {
                    return _hashBytes;
                }

                throw new ValueNotSetException();
            }
            private set
            {
                if (null == value)
                {
                    throw new ArgumentNullException();
                }
                if (!64.Equals(value.Length))
                {
                    throw new InvalidLengthException();
                }

                _hashBytes = value;
            }
        }

        #endregion

        #region Factory

        public static class Factory
        {
            public static Hash Create(String value)
            {
                SHA512 sha512 = SHA512.Create();
                Byte[] valueBytes = Encoding.UTF8.GetBytes(value);
                Byte[] hashBytes = sha512.ComputeHash(valueBytes);

                return Create(hashBytes);
            }

            public static Hash Create(Byte[] hashBytes)
            {
                return new Hash(hashBytes);
            }
        }

        #endregion
    }
}