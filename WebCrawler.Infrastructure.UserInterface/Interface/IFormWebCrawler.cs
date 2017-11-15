using System;
using System.Collections.Generic;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Interface
{
    public interface IFormWebCrawler
    {
        Boolean ValidateUri(String url);

        void StartCrawling(Uri startUri);
        void StopCrawling();

        Int32 GetLinksCrawledCount();
        Boolean IsCrawlerRunning();
        IEnumerable<Tuple<Int32, Boolean, Int32>> GetCrawlingInstanceInformation();

        void SetDepth(Int32 value);
        void SetInstances(Int32 value);
        void SetMaxTasks(Int32 value);
        void SetNoTaskIntervalBreak(Int32 value);
        void SetRetries(Int32 value);
        void SetTaskRestockThreshold(Int32 value);
        void SetTaskBufferSize(Int32 value);
        void SetTimeout(Int32 value);
        void SetUpdateIntervalBreak(Int32 value);

        Int32 GetDepth();
        Int32 GetInstances();
        Int32 GetMaxTasks();
        Int32 GetNoTaskIntervalBreak();
        Int32 GetRetries();
        Int32 GetTaskRestockThreshold();
        Int32 GetTaskBufferSize();
        Int32 GetTimeout();
        Int32 GetUpdateIntervalBreak();
    }
}