using System;

namespace ch.wuerth.tobias.WebCrawler.DomainModel.Exceptions
{
    public static class HashPolicy
    {
        public static void ValidateHash(Byte[] value)
        {
            if (null == value)
            {
                throw new ArgumentNullException();
            }
            if (!64.Equals(value.Length))
            {
                throw new InvalidLengthException();
            }
        }
    }
}