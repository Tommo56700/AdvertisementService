using System;
using System.Collections.Generic;
using System.Threading;

namespace BadProject.Utility
{
    public static class Retry
    {
        public static T Do<T>(Func<T> action, Queue<DateTime> errorQueue, int retryInterval, int maxAttemptCount = 3)
        {
            for (var retry = 0; retry < maxAttemptCount; retry++)
            {
                try
                {
                    if (retry > 0) Thread.Sleep(retryInterval);
                    return action();
                }
                catch
                {
                    errorQueue.Enqueue(DateTime.Now);
                }
            }

            return default;
        }
    }
}