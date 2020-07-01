<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Invoice_Report.aspx.cs" Inherits="RCandJJ.PO_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function DeleteOk() {
            alertify.error('Customer deleted successfully...');
        }

        function WarningOk() {
            alertify.error('No record found...');
        }

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Invoice deleted successfully...');
        }

    </script>
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
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
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
                    <div class="panel panel-danger" style="height: 625px; overflow: auto;">
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
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" AutoCompleteType="None" TextMode=Date></asp:TextBox>
                                  
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE" AutoCompleteType="None" TextMode=Date></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="80px" OnClick="txtSearchPO_TextChanged" />
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn btn-default" Width="80px"
                                        OnClientClick="return PrintPanel();" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdPOReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" BorderStyle="None" CssClass="table nomargin grid" DataKeyNames="PURCHASEORDER_ID" PageSize="10" OnPageIndexChanging="grdPOReport_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Inv. No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd MMM yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="To Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("CUSTOMER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="TOTAL QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST(Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("CGST_AMOUNT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST(Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("SGST_AMOUNT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Grand Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click" CssClass="btn btn-info"
                                                    Font-Size="13px" Width="60px" ForeColor="White" Style="padding: 5px;">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <a href='InvoiceForm.aspx?po_no=<%# Eval("PURCHASEORDER_ID")%>&cid=<%# Eval("CUSTOMER_ID")%>&cname=<%# Eval("CUSTOMER_NAME")%>'>
                                                    <i class="fa fa-pencil"></i></a>
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                                <table class="total" id="total" runat="server" visible="false">
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            CGST
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCgst" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            SGST
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSgst" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Grand Total
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
    <div style="display: none;">
        <asp:Panel ID="pnlContents" runat="server">
            <div class="table-responsive">
                <asp:GridView ID="grdInvoiceReportPrint" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="False" BorderStyle="None" CssClass="table nomargin grid">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Inv. No">
                            <ItemTemplate>
                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("PO_NO")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="To Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("CUSTOMER_NAME")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="TOTAL QTY">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL_QTY")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST(Rs.)">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("CGST_AMOUNT")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST(Rs.)">
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
            <br />
            <table class="total" id="Table1" runat="server" width="30%">
                <tr>
                    <td>
                        Total
                    </td>
                    <td>
                        <asp:Label ID="lblPrintTotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        CGST
                    </td>
                    <td>
                        <asp:Label ID="lblPrintCgst" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        SGST
                    </td>
                    <td>
                        <asp:Label ID="lblPrintSgst" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Grand Total
                    </td>
                    <td>
                        <asp:Label ID="lblPrintGrandTotal" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
