using System.Configuration;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace WindowsAzureBackgroundWork.Demo.WebJob
{
    class Program
    {
        static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Storage"].ConnectionString;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var backgroundWorker = new BackgroundWorkerService(storageAccount);
            Task.Run(() => backgroundWorker.DoWork("WebJob")).Wait();
        }
    }
}
