<%@ Page Language="C#" %>
<%@ Import Namespace="System.Threading.Tasks" %>
<%@ Import Namespace="WindowsAzureBackgroundWork.Demo.Web" %>
<% Task.Run(() => Global.BackgroundWorker.DoWork("DoWork.aspx")).Wait(); %>
Done.
