using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage;

namespace WindowsAzureBackgroundWork.Demo.Web
{
    public class Global : HttpApplication
    {
        public static BackgroundWorkerService BackgroundWorker;

        protected void Application_Start(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Storage"].ConnectionString;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            BackgroundWorker = new BackgroundWorkerService(storageAccount);
            Task.Run(() => BackgroundWorker.DoWork("Application_Start"));
        }
    }
}