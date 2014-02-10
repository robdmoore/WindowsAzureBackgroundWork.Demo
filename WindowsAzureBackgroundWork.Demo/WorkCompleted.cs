using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WindowsAzureBackgroundWork.Demo
{
    public class WorkCompleted : TableEntity
    {
        public WorkCompleted(string originator)
        {
            Originator = originator;
            RowKey = Guid.NewGuid().ToString();
            WorkStarted = DateTime.UtcNow;
            Increment = 0;
        }

        public void ReportWork()
        {
            Increment++;
        }

        public string Originator { get { return PartitionKey; } set { PartitionKey = value; } }
        public DateTime WorkStarted { get; set; }
        public int Increment { get; set; }
    }
}