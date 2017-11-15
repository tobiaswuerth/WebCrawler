using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Interface;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Properties;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Controller
{
    public class CrawlingInstance
    {
        private readonly IFormWebCrawler _parent;
        private volatile ThreadStart _threadStart;
        private volatile Boolean _threadStopRequest;
        public volatile List<Webpage> WebpagesDone = new List<Webpage>();

        public volatile List<Webpage> WebpagesTodo = new List<Webpage>();

        public CrawlingInstance(IFormWebCrawler parent)
        {
            _parent = parent;
        }

        public Boolean ThreadRunning { get; private set; }

        public void Stop()
        {
            _threadStopRequest = true;
        }

        public ThreadStart GetThreadStartInstance()
        {
            return _threadStart ?? (_threadStart = ThreadRun);
        }

        private void ThreadRun()
        {
            ThreadRunning = true;
            _threadStopRequest = false;

            while (!_threadStopRequest)
            {
                // no tasks? sleep
                if (WebpagesTodo.Count < 1)
                {
                    Thread.Sleep(_parent.GetNoTaskIntervalBreak());
                    continue;
                }

                Webpage webpageInput = WebpagesTodo[0];

                try
                {
                    Webpage webpageOutput =
                        WebpageHttpHandler.Crawl(webpageInput, _parent.GetTimeout(), _parent.GetRetries());
                    WebpagesDone.Add(webpageOutput);
                }
                catch (WebException ex)
                {
                    HttpWebResponse response = ex.Response as HttpWebResponse;

                    if (response != null)
                    {
                        webpageInput.Status = (Int32) response.StatusCode;
                        webpageInput.Mime = response.ContentType;
                        webpageInput.Title = String.Empty;
                        WebpagesDone.Add(webpageInput);
                    }
                    else
                    {
                        webpageInput.Status = 999;
                        webpageInput.Mime = ex.Status.ToString();
                        webpageInput.Title = String.Empty;
                        WebpagesDone.Add(webpageInput);
                    }
                }
                catch (InvalidCastException)
                {
                    webpageInput.Status = 999;
                    webpageInput.Mime = "InvalidCast";
                    webpageInput.Title = String.Empty;
                    WebpagesDone.Add(webpageInput);
                }
                catch (NotSupportedException)
                {
                    webpageInput.Status = 999;
                    webpageInput.Mime = "NotSupported";
                    webpageInput.Title = String.Empty;
                    WebpagesDone.Add(webpageInput);
                }
                catch (UriFormatException)
                {
                    webpageInput.Status = 999;
                    webpageInput.Mime = "UriFormat";
                    webpageInput.Title = String.Empty;
                    WebpagesDone.Add(webpageInput);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(Resources.Error_occured + ex.StackTrace);
                    // todo exception handling
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Resources.Error_occured + ex.StackTrace);
                    // todo exception handling
                }
                WebpagesTodo.Remove(WebpagesTodo[0]);
            }

            ThreadRunning = false;
        }
    }
}