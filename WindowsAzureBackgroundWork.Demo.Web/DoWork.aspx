<%@ Page Language="C#" %>
<%@ Import Namespace="WindowsAzureBackgroundWork.Demo.Web" %>
<% Global.BackgroundWorker.DoWork("DoWork.aspx").Wait(); %>
Done.
