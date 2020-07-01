<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SalesReport.aspx.cs" Inherits="SRIRAM_MILK.SalesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .grid a
        {
            color: #505b72;
            font-size: 16px;
            padding-left: 5px;
        }
        .grid a:hover
        {
            color: #257bab;
        }
        
        .select2-container--default .select2-selection--single .select2-selection__arrow
        {
            height: 26px;
        }
    </style>
    <style>
        .total
        {
            margin: 40px;
            width: 30%;
            background-color: #e0e0e0;
        }
        
        .total tr td
        {
            padding: 10px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function customOpen(url) {
            var w = window.open(url, '_blank');
            w.focus();
        }
    </script>
    <script type="text/javascript">
        function PrintPanel() {
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
                <li><a href="Invoice_Report.aspx">Invoice Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Invoice Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                <div class="col-md-1">
                                    <a href="Invoice_Report.aspx" class="btn btn-info" style="width: 80px;">All</a>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSearchPO" CssClass="form-control" runat="server" placeholder="Invoice NO"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Customer Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        AutoCompleteType="None"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" runat="server"
                                        Format="dd MMM yyyy">
                                    </asp:CalendarExtender>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        AutoCompleteType="None"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txttoDate" runat="server"
                                        Format="dd MMM yyyy">
                                    </asp:CalendarExtender>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="80px" OnClick="txtSearchPO_TextChanged" />
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn btn-default" Width="80px"
                                        OnClientClick="return PrintPanel();" />
                                </div>
                                 <div class="clearfix">
                            </div>
                                <div class="col-md-3" style="margin-top: 10px;">
                                    <asp:Button ID="btnExportExcel" runat="server" Text="Export To Excel" CssClass="btn btn-default" OnClick="btnExcelExportClick"
                                        Width="120px" />
                                </div>
                            </div>
                           <div class="clearfix">
                            </div>
                            <asp:Panel ID="pnlContents" runat="server">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdPOReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="false" BorderStyle="None" CssClass="table nomargin grid" DataKeyNames="PO_NO">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Invoice Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Party Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("CUSTOMER_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="GST No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label222" runat="server" Font-Bold="false" Text='<%# Eval("GST_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="TOTAL QTY">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL_QTY")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="HSN">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label33" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_HSN")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Invoice Value">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Taxable Value">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label66" runat="server" Font-Bold="false" Text='<%# Eval("GST_AMOUNT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST AMT">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("CGST_AMOUNT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST AMT">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("SGST_AMOUNT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Grand Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination" />
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <!-- table-responsive -->
                        </div>
                    </div>
                </div>
                <!-- panel -->
                <!-- col-md-6 -->
            </div>
        </div>
        <!-- contentpanel -->
    </div>
</asp:Content>
