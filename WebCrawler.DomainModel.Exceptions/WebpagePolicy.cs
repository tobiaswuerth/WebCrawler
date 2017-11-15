using System;

namespace ch.wuerth.tobias.WebCrawler.DomainModel.Exceptions
{
    public static class WebpagePolicy
    {
        public static void ValidateUri(Uri uri)
        {
            if (null == uri)
            {
                throw new ArgumentNullException();
            }
            if (!uri.IsAbsoluteUri)
            {
                throw new NotSupportedException();
            }
        }

        public static void ValidateDepth(Int32 depth)
        {
            if (0 > depth)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void ValidateStatus(Int32 status)
        {
            // status can be -1 to indicate beeing processed
            if (-1 > status)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}