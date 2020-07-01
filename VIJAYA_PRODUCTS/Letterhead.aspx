<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Letterhead.aspx.cs" Inherits="SRIRAM_MILK.Letterhead" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {


            document.getElementById("letter-date").innerHTML = document.getElementById("ContentPlaceHolder1_txtDate").value;
            document.getElementById("data").innerHTML = document.getElementById('ContentPlaceHolder1_Editor1_ctl02_ctl00').contentWindow.document.body.innerHTML;

            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="Letterhead.aspx">Letter Head</a></li>
            </ol>
            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-9">
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="col-md-12">
                                <hr style="border-color: #f46f0d; border-width: 4px;" />
                                <div class="col-md-4">
                                    <img src="images/logo.png" alt="" width="80%" />
                                   <p>
                                        <br />79/156 Bijali Nagar, Executive Apts.. Near Patil Medical, Chinchwad, Pune-411033
                                    </p>
                                </div>
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-4">
                                    <br />
                                    <p>
                                      <%--  FSSAI:- 11518037000949 <br />
                                        GSTN/UIN:- 27ADGPJ5438CIZQ<br />--%>
                                        Email:- vijayaproducts96@gmail.com<br />
                                        Contact No:- 020-27653112</p>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr />
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-4">
                                    Date:<asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox></div>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <cc1:Editor ID="Editor1" runat="server" Height="600px" />
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr style="border-color: #e70000; border-width: 4px;" />
                            </div>
                            <center>
                                <asp:Button ID="btnSubmit" runat="server" Text="Print" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                    OnClientClick="return PrintPanel();" /></center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="display: none;">
        <asp:Panel ID="pnlContents" runat="server">
            <hr style="border-color: #f46f0d; border-width: 3px;" />
            <div style="width: 33%; float: left;">
                <img src="images/logo.png" alt="" width="60%" />
                <p style="font-family: Arial; font-size: 12px;">
                    79/156 Bijali Nagar, Executive Apts.. Near Patil Medical, Chinchwad, Pune-411033
                </p>
            </div>
            <div style="width: 33%; float: left;">
            </div>
            <div style="width: 25%; float: right;">
                <br />
                <p style="font-family: Arial; font-size: 12px;">
                                        <%-- FSSAI:- <br />
                                        GSTN/UIN:- 27ADGPJ5438CIZQ<br />--%>
                                        Email:- vijayaproducts96@gmail.com<br />
                                        Contact No:- 020-27653112</p>
            </div>
            <hr style="width: 100%; float: left;" />
            <div style="width: 25%; float: right; font-size: 12px; font-family: Arial;">
                <p style="font-size: 12px;">
                    Date : <span id="letter-date"></span>
                </p>
            </div>
            <br />
            <div style="width: 96.5%; min-height:600px; float: left; font-size: 12px; padding-left: 20px; padding-right: 20px;background-image: url(../images/watermark1.jpg);
    background-size: cover; background-position:center;">
                <span id="data"></span>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
