<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LedgerReport.aspx.cs" Inherits="VIJAYA_PRODUCTS.LedgerReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="LedgerReport.aspx">Ledger Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Ledger Report</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4;" />

                         
                            <div class="col-md-12 row" style="margin-bottom: 30px;">

                             <div class="col-md-3">
                                        <asp:DropDownList ID="auto_ddlPartyName" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="auto_ddlPartyName"
                                            InitialValue="0" CssClass="error" ErrorMessage="Party Name required..."></asp:RequiredFieldValidator>
                                    </div>

                                <div class="col-md-3">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        AutoCompleteType="None" TextMode="Date"></asp:TextBox>
                                  
                                </div>

                                <div class="col-md-3">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        AutoCompleteType="None" TextMode="Date"></asp:TextBox>
                               
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="Datevalidate();" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnSearchLedger"/>
                                </div>
                            </div>
                 

                            <div class="col-md-12">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="true"
                                    SizeToReportContent="true">
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
