<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShopsInvoice.aspx.cs" Inherits="VIJAYA_PRODUCTS.ShopsInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/quirk.css" />
    <style type="text/css">
        .panel-title {
            font-size: 21px;
            letter-spacing: .3px;
            text-align: center
        }

        .panel-heading {
            text-align: center
        }

        .actions {
            text-align: right;
            padding: 25px;
            margin-right: 10px;
        }
    </style>
     <script type="text/javascript">
        function customOpen(url) {
            var w = window.open(url, '_blank');
            w.focus();
            window.location = "ShopsInvoice.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">

                            <h3 class="panel-title">VIJAYA PRODUCTS</h3>
                            <p>79/156 Bijli Nagar ,Executive Apts.. Near Patil Medical,Chinchwad,Pune-411033</p>
                        </div>
                        <div class="panel-body">
                            <div class="form-group col-md-6" id="name">
                                <label class="col-md-4 control-label">Ms/Mrs</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" ForeColor="Red">

                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <%-- <div class="form-group col-md-6" id="InvoiceNo">
                                <label class="col-md-4 control-label">Tax Invoice No</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control" placeholder="Invoice No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Invoice no" ControlToValidate="txtInvoiceNo" ForeColor="Red"></asp:RequiredFieldValidator>
                                    
                                </div>
                            </div>--%>
                            <asp:Label ID="lblInvoiceId" runat="server" Visible="false"></asp:Label>
                            <div class="form-group col-md-6" id="particular">
                                <label class="col-md-4 control-label">Particular</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtParticular" runat="server" CssClass="form-control" placeholder="Enter Product"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-md-6" id="date">
                                <label class="col-md-4 control-label">
                                    Date
                                </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCalender" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:HiddenField ID="hidShopId" runat="server" />
                            <asp:HiddenField ID="hidHSNCode" runat="server" />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <table class="table nomargin" width="100%">
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtShop1" runat="server" CssClass="form-control" placeholder="Client1"></asp:TextBox></td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Client name" ControlToValidate="txtShop1" ForeColor="red"></asp:RequiredFieldValidator>
                                                    <td>
                                                        <asp:TextBox ID="txtShop2" runat="server" CssClass="form-control" placeholder="Client2"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtShop3" runat="server" CssClass="form-control" placeholder="Client3"></asp:TextBox></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="grdProduct" runat="server" CssClass="table nomargin" AutoGenerateColumns="false" BorderStyle="None" DataKeyNames="INVOICE_PRODUCT_ID">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SrNO">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" Text='<%# Eval("DATE")%>' placeholder="dd/MM/yyyy"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity1">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty1" runat="server" CssClass="form-control" placeholder="Qty" AutoPostBack="true" OnTextChanged="ProductContent_TextChange" Text='<%# Eval("QTY1")%>'></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtQty1" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity2">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty2" runat="server" CssClass="form-control" placeholder="Qty" AutoPostBack="true" OnTextChanged="ProductContent_TextChange" Text='<%# Eval("QTY2")%>'></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtQty2" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity3">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty3" runat="server" CssClass="form-control" placeholder="Qty" AutoPostBack="true" OnTextChanged="ProductContent_TextChange" Text='<%# Eval("QTY3")%>'></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Input"
                                                                SetFocusOnError="true" ControlToValidate="txtQty3" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRate" AutoPostBack="true" OnTextChanged="ProductContent_TextChange" Text='<%# Eval("RATE")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAmount" ReadOnly="true" Text='<%# Eval("AMOUNT")%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" AutoPostBack="true" OnClick="RemoveProduct" ForeColor="#FF5722"
                                                                CausesValidation="false">x</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="col-md-7">
                                            </div>
                                            <div class="col-md-5">
                                                <div class="table-responsive">
                                                    <table class="table table-bordered table-primary nomargin" style="padding: 10px;">
                                                        <tr>
                                                            <td style="width: 40%;">Total
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtTotal" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>CGST
                                                            </td>
                                                            <td style="width: 25%;">
                                                                <asp:TextBox ID="txtCGSTPer" CssClass="form-control" Text="0" AutoPostBack="true" OnTextChanged="InvoiceContentChange" runat="server"></asp:TextBox>
                                                                <asp:HiddenField ID="hidGstID" runat="server" />
                                                                <asp:HiddenField ID="hidGstValue" runat="server" />
                                                            </td>
                                                            <td style="width: 70%;">
                                                                <asp:TextBox ID="txtCGSTAmount" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>SGST
                                                            </td>
                                                            <td style="width: 25%;">
                                                                <asp:TextBox ID="txtSGSTPer" CssClass="form-control" AutoPostBack="true" OnTextChanged="InvoiceContentChange" Text="0" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 70%;">
                                                                <asp:TextBox ID="txtSGSTAmount" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Grand Total
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtGrandTotal" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <!-- table-responsive -->
                                            </div>
                                        </div>
                                        <!-- table-responsive -->
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="actions">
                            <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                        </div>
                    </div>


                    <!-- col-md-12 -->
                </div>
            </div>
            <!-- row -->
        </div>
        <!-- contentpanel -->
    </div>
</asp:Content>
