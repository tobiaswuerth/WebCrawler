using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;
using HtmlAgilityPack;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Controller
{
    public static class WebpageHttpHandler
    {
        public static Webpage Crawl(Webpage webpage, Int32 timeout, Int32 retries)
        {
            webpage.LastCrawledDate = DateTime.Now;

            // create web request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(webpage.Webaddress.Uri);
            request.Method = "GET";
            request.Timeout = timeout;

            Int32 statusCode = 0;
            String webpageContent = null;
            String webpageMime = null;

            // read webpage content
            Int32 retryCount = 0;
            while (retryCount <= retries)
            {
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    statusCode = (Int32) ((HttpWebResponse) response).StatusCode;
                                    webpageContent = reader.ReadToEnd();
                                    webpageMime = response.ContentType;
                                }
                            }
                            else
                            {
                                throw new NullReferenceException();
                            }
                        }
                    }

                    break;
                }
                catch (TimeoutException)
                {
                    if (retryCount == retries)
                    {
                        throw;
                    }

                    retryCount++;
                }
            }

            webpage.Status = statusCode;
            webpage.Mime = webpageMime;

            // content to html document
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(webpageContent);

            // get uris from html document
            HtmlNodeCollection relevantNodes =
                htmlDocument.DocumentNode.SelectNodes("//*[@href] | //*[@src] | //*[@url]");

            HashSet<Webpage> uris = new HashSet<Webpage>();
            if (null != relevantNodes)
            {
                foreach (HtmlNode node in relevantNodes)
                {
                    String value = node.GetAttributeValue("href", null) ??
                                   node.GetAttributeValue("src", null) ?? node.GetAttributeValue("url", null);

                    // value to uri
                    Uri nodeUri = new Uri(value.Trim(), UriKind.RelativeOrAbsolute);
                    if (!nodeUri.IsAbsoluteUri)
                    {
                        nodeUri = new Uri(webpage.Webaddress.Uri, nodeUri);
                    }
                    uris.Add(new Webpage(new Webaddress(nodeUri), webpage.Depth + 1,
                        Webpage.WebpageType.Root == webpage.Type || Webpage.WebpageType.NewRoot == webpage.Type ||
                        Webpage.WebpageType.UncrawledRoot == webpage.Type
                            ? webpage
                            : webpage.RootWebpage));
                }
            }

            webpage.ChildWebpages = uris.ToList();

            // get title from html document
            HtmlNode titleNode = htmlDocument.DocumentNode.SelectSingleNode("//head/title");
            webpage.Title = null == titleNode ? String.Empty : titleNode.InnerText.Trim();

            return webpage;
        }
    }
}