<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopInvPrint.aspx.cs" Inherits="VIJAYA_PRODUCTS.ShopInvPrint" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <center>
            <div id="dvReport">
                 <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" AsyncRendering="true"
                    SizeToReportContent="true"></rsweb:ReportViewer>
            </div>
        </center>
    </div>
    </form>
</body>
</html>
