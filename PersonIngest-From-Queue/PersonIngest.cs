using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PersonIngest_From_Queue
{
    public static class PersonIngest
    {
        [FunctionName("PersonIngest")]
        public static void Run([QueueTrigger("persondb", Connection = "persondbqueue")]string myQueueItem, ILogger log)
        {
            if (myQueueItem.Contains("exception")) throw new Exception("Exception found in message");
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
