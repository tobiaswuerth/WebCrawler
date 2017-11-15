using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ch.wuerth.tobias.WebCrawler.DomainModel.Entities;
using ch.wuerth.tobias.WebCrawler.DomainService.Interfaces;
using ch.wuerth.tobias.WebCrawler.Infrastructure.Database.Repository;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Interface;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Controller
{
    public class FormWebCrawlerController : IFormWebCrawler
    {
        private readonly List<CrawlingInstance> _crawlingInstances = new List<CrawlingInstance>();
        private readonly IWebCrawlerRepository _webCrawlerRepository = new WebCrawlerRepository();
        private volatile Int32 _depth = 2;
        private volatile Int32 _instances = 15;
        private volatile Int32 _maxTasks = 30;
        private volatile Int32 _noTaskIntervalBreak = 500;
        private volatile Int32 _retries = 3;
        private List<Webpage> _taskBuffer = new List<Webpage>();
        private volatile Int32 _taskBufferSize = 1000;
        private volatile Int32 _taskRestockThreshold = 10;

        private Boolean _threadIsRunning;
        private Boolean _threadStopRequest;
        private volatile Int32 _timeout = 10000;
        private volatile Int32 _updateIntervalBreak = 250;

        private Webpage _webpage;
        private Int32 _webpagesPassedToDatabase;

        public void StartCrawling(Uri startUri)
        {
            // reset
            _crawlingInstances.Clear();
            _webpagesPassedToDatabase = 0;
            _taskBuffer.Clear();

            // reset left over status
            _webCrawlerRepository.ResetStatus();

            // create new instances
            for (UInt32 i = 0;
                i < _instances;
                i++)
            {
                _crawlingInstances.Add(new CrawlingInstance(this));
            }

            // start instances
            foreach (CrawlingInstance ci in _crawlingInstances)
            {
                new Thread(ci.GetThreadStartInstance()).Start();
            }

            // save baseuri
            _webpage = new Webpage(new Webaddress(startUri));
            _webCrawlerRepository.Save(_webpage);
            _webpage = _webCrawlerRepository.GetRootPageByWebaddressHash(_webpage);
            _taskBuffer.Add(_webpage);

            // start this thread
            new Thread(CrawlerInstanceHandler).Start();
        }

        public void StopCrawling()
        {
            // stop all instances
            foreach (CrawlingInstance crawlingInstance in _crawlingInstances)
            {
                crawlingInstance.Stop();
            }

            // wait until every instance is done
            while (_crawlingInstances.Any(x => x.ThreadRunning))
            {
                Thread.Sleep(200);
            }

            // stop this thread
            _threadStopRequest = true;
        }

        public Boolean ValidateUri(String url)
        {
            try
            {
                new Webaddress(new Uri(url));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Int32 GetLinksCrawledCount()
        {
            return _webpagesPassedToDatabase;
        }

        public IEnumerable<Tuple<Int32, Boolean, Int32>> GetCrawlingInstanceInformation()
        {
            return _crawlingInstances
                .Select((t, i) => new Tuple<Int32, Boolean, Int32>(i, t.ThreadRunning, t.WebpagesTodo.Count)).ToList();
        }

        public void SetDepth(Int32 value)
        {
            _depth = value;
        }

        public void SetInstances(Int32 value)
        {
            _instances = value;
        }

        public void SetMaxTasks(Int32 value)
        {
            _maxTasks = value;
        }

        public void SetNoTaskIntervalBreak(Int32 value)
        {
            _noTaskIntervalBreak = value;
        }

        public void SetRetries(Int32 value)
        {
            _retries = value;
        }

        public void SetTaskRestockThreshold(Int32 value)
        {
            _taskRestockThreshold = value;
        }

        public void SetTaskBufferSize(Int32 value)
        {
            _taskBufferSize = value;
        }

        public void SetTimeout(Int32 value)
        {
            _timeout = value;
        }

        public void SetUpdateIntervalBreak(Int32 value)
        {
            _updateIntervalBreak = value;
        }

        public Int32 GetDepth()
        {
            return _depth;
        }

        public Int32 GetInstances()
        {
            return _instances;
        }

        public Int32 GetMaxTasks()
        {
            return _maxTasks;
        }

        public Int32 GetNoTaskIntervalBreak()
        {
            return _noTaskIntervalBreak;
        }

        public Int32 GetRetries()
        {
            return _retries;
        }

        public Int32 GetTaskRestockThreshold()
        {
            return _taskRestockThreshold;
        }

        public Int32 GetTaskBufferSize()
        {
            return _taskBufferSize;
        }

        public Int32 GetTimeout()
        {
            return _timeout;
        }

        public Int32 GetUpdateIntervalBreak()
        {
            return _updateIntervalBreak;
        }

        public Boolean IsCrawlerRunning()
        {
            return _threadIsRunning;
        }

        private void CrawlerInstanceHandler()
        {
            _threadIsRunning = true;
            _threadStopRequest = false;

            while (!_threadStopRequest)
            {
                Thread.Sleep(_updateIntervalBreak);

                // get crawled webpages
                List<Webpage> webpagesFromInstances = new List<Webpage>();

                foreach (CrawlingInstance ci in _crawlingInstances.Where(x => x.WebpagesDone.Count > 0))
                {
                    lock (ci.WebpagesDone)
                    {
                        webpagesFromInstances.AddRange(ci.WebpagesDone);
                        ci.WebpagesDone.Clear();
                    }
                }

                if (webpagesFromInstances.Count > 0)
                {
                    _webCrawlerRepository.Save(webpagesFromInstances);
                    _webpagesPassedToDatabase += webpagesFromInstances.Count;
                    webpagesFromInstances.Where(x => !x.Equals(_webpage)).ToList().ForEach(x =>
                    {
                        x.Dispose();
                        x = null;
                    });
                    webpagesFromInstances.Clear();
                }

                if (_taskBuffer.Count == 0)
                {
                    _taskBuffer = _webCrawlerRepository.GetByRootAndStatus(_webpage, 0, _taskBufferSize, _depth);

                    if (_taskBuffer.Count == 0)
                    {
                        // no tasks in db
                        Int32 urlsToDo = _crawlingInstances.Sum(x => x.WebpagesTodo.Count);

                        if (urlsToDo == 0 && _crawlingInstances.Sum(x => x.WebpagesDone.Count) == 0)
                        {
                            // no tasks in instances
                            StopCrawling();
                        }
                    }
                }
                else
                {
                    foreach (CrawlingInstance crawlingInstance in _crawlingInstances)
                    {
                        if (_taskBuffer.Count == 0)
                        {
                            // no tasks to distribute
                            break;
                        }

                        if (crawlingInstance.WebpagesTodo.Count > _taskRestockThreshold)
                        {
                            continue;
                        }

                        // how many tasks should be restocked?
                        Int32 amountOfTasksToAdd = _maxTasks - crawlingInstance.WebpagesTodo.Count;
                        if (amountOfTasksToAdd > _taskBuffer.Count)
                        {
                            amountOfTasksToAdd = _taskBuffer.Count;
                        }

                        // assign tasks to instance
                        crawlingInstance.WebpagesTodo.AddRange(_taskBuffer.Take(amountOfTasksToAdd));
                        _taskBuffer.RemoveRange(0, amountOfTasksToAdd);
                    }
                }
            }

            _webCrawlerRepository.ResetStatus();
            _threadIsRunning = false;
        }
    }
}