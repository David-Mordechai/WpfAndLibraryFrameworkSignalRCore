using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClassLibrary1
{
    public class RetryPolicy : IRetryPolicy
    {
        ///<summary>
        ///Retry count less then 50: interval 1s; less then 250: interval 30s; >= 250: interval 1m
        ///</summary>
        ///<param name="retryContext"></param>
        ///<returns>TimeSpan?</returns>
        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            var count = retryContext.PreviousRetryCount / 50;

            if (count < 50)
                return new TimeSpan(0, 0, 1);

            return count < 250 ? 
                new TimeSpan(0, 0, 30) : 
                new TimeSpan(0, 1, 0);
        }
    }
}
