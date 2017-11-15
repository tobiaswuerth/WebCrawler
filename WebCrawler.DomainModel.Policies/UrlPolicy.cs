using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebCrawler.DomainModel.Policies
{
    public static class UrlPolicy
    {
        private static readonly List<Regex> UrlRegexPatterns = new List<Regex>
                                                               {
                                                                   new Regex(
                                                                       @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])(:[\d]{1,5})?"),
                                                                   new Regex(@"(?<link>((?<prot>http:\/\/)*(?<subdomain>(www|[^\-\n]*)*)(\.)*(?<domain>[^\-\n]+)\.(?<after>[a-zA-Z]{2,3}[^>\n]*)))")
                                                               };

        public static Boolean Fulfills(String webpageAddress)
        {
            if(null == webpageAddress)
            {
                return false;
            }

            foreach(Regex pattern in UrlRegexPatterns)
            {
                if(pattern.Match(webpageAddress).Success)
                {
                    return true;
                }
            }

            return false;
        }
    }
}