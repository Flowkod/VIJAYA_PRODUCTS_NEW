<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShopInvoice_Report.aspx.cs" Inherits="VIJAYA_PRODUCTS.ShopInvoice_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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
    <script type="text/javascript">
        function customOpen(url) {
            var w = window.open(url, '_blank');
            w.focus();
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
                <li><a href="ShopInvoice_Report.aspx">Day Invoice Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                              Day Invoice Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12 row" style="margin-bottom: 30px;">
                                
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtInvoiceNo" CssClass="form-control" runat="server" placeholder="Invoice NO"></asp:TextBox>
                                </div>
                               
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE" AutoCompleteType="None" TextMode=Date></asp:TextBox>
                                  
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE" AutoCompleteType="None" TextMode=Date></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnSearch_Click"/>
                                </div>
                               
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdPOReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="false" BorderStyle="None" CssClass="table nomargin grid" DataKeyNames="INVOICE_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SRNO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="false" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Inv. No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label0" runat="server" Font-Bold="false" Text='<%# Eval("INVOICE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SHOP1 TOTAL QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("QTY_CLIENT1")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SHOP2 TOTAL QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("QTY_CLIENT2")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SHOP3 TOTAL QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("QTY_CLIENT3")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="CGST(Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("CGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="SGST(Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="false" Text='<%# Eval("SGST")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Grand Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server"  OnClick="lnkView_Click" CssClass="btn btn-info"
                                                    Font-Size="13px" Width="60px" ForeColor="White" Style="padding: 5px;">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" onclick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
    
</asp:Content>
