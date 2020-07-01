<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="PurchaseRegisterReport.aspx.cs" Inherits="INVOICE_DEMO.PurchaseRegisterReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Purchase Order deleted successfully...');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button2" Text="Upload" runat="server" OnClick="btnDelete" Style="display: none;" />
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
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSearchPO" CssClass="form-control" runat="server" placeholder="Invoice NO"></asp:TextBox>
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
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearchReport"
                                        Width="80px" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnExportExcel" runat="server" Text="Export To Excel" CssClass="btn btn-default" OnClick="btnExcelExportClick"
                                        Width="120px" />
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdPOReport" runat="server" Width="100%" AutoGenerateColumns="false"
                                    AllowPaging="false" BorderStyle="None" CssClass="table nomargin grid" DataKeyNames="PURCHASE_REG_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label99" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("Party_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Gst No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("GST_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Place Of Supply">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("Place_of_Supply")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="E-Commmerce GSTIN">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Font-Bold="false" Text='<%# Eval("E_COMM_GSTIN")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("Category")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Commodity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("Commodity")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("Unit")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("Quantity")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="HSN">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("HSN")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("Invoice_Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Taxable Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label199" runat="server" Font-Bold="false" Text='<%# Eval("Taxable_Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="IGST_AMT">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("IGST_AMT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CGST_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Font-Bold="false" Text='<%# Eval("CGST_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CGST_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Font-Bold="false" Text='<%# Eval("CGST_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SGST_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Font-Bold="false" Text='<%# Eval("SGST_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SGST_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Font-Bold="false" Text='<%# Eval("SGST_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CESS_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Font-Bold="false" Text='<%# Eval("CESS_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CESS_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label19" runat="server" Font-Bold="false" Text='<%# Eval("CESS_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Rounded_Off">
                                            <ItemTemplate>
                                                <asp:Label ID="Label20" runat="server" Font-Bold="false" Text='<%# Eval("Rounded_Off")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Total_Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label210" runat="server" Font-Bold="false" Text='<%# Eval("Total_Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
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
                <asp:GridView ID="grdPoPrint" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="false" BorderStyle="None" CssClass="table nomargin grid">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label99" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("Party_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Gst No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("GST_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Place Of Supply">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("Place_of_Supply")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="E-Commmerce GSTIN">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Font-Bold="false" Text='<%# Eval("E_COMM_GSTIN")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("Category")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Commodity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("Commodity")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("Unit")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%# Eval("Quantity")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="HSN">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("HSN")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Invoice Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("Invoice_Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Taxable Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label199" runat="server" Font-Bold="false" Text='<%# Eval("Taxable_Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="IGST_AMT">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("IGST_AMT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CGST_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Font-Bold="false" Text='<%# Eval("CGST_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CGST_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Font-Bold="false" Text='<%# Eval("CGST_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SGST_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Font-Bold="false" Text='<%# Eval("SGST_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SGST_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Font-Bold="false" Text='<%# Eval("SGST_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CESS_Amt">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Font-Bold="false" Text='<%# Eval("CESS_Amt")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="CESS_Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label19" runat="server" Font-Bold="false" Text='<%# Eval("CESS_Rate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Rounded_Off">
                                            <ItemTemplate>
                                                <asp:Label ID="Label20" runat="server" Font-Bold="false" Text='<%# Eval("Rounded_Off")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Total_Value">
                                            <ItemTemplate>
                                                <asp:Label ID="Label210" runat="server" Font-Bold="false" Text='<%# Eval("Total_Value")%>'></asp:Label>
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
