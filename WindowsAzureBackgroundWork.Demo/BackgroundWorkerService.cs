using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace WindowsAzureBackgroundWork.Demo
{
    public class BackgroundWorkerService
    {
        private const string TableName = "BackgroundWork";

        private readonly CloudTable _table;

        public BackgroundWorkerService(CloudStorageAccount storageAccount)
        {
            _table = storageAccount.CreateCloudTableClient().GetTableReference(TableName);
            _table.CreateIfNotExists();
        }

        public async Task DoWork(string requestOriginator)
        {
            var work = new WorkCompleted(requestOriginator);
            await _table.ExecuteAsync(TableOperation.Insert(work));

            while (work.Increment <= 150)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                work.ReportWork();
                await _table.ExecuteAsync(TableOperation.Replace(work));
            }
        }
    }
}
