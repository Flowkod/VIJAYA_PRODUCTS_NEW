<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="InvoiceForm.aspx.cs" Inherits="RCandJJ.PO_Form1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="../css/quirk.css" />

    <style type="text/css">
        .control-label
        {
            padding-top: 10px;
        }
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
        .grid tr td
        {
            padding: 10px 5px !important;
        }
        .content
        {
            height: 560px;
        }
        .table td th tr
        {
            border: 1px solid black;
        }
        .supplierheading
        {
            color: #ffffff;
            background-color: #e70000;
            border-color:#e70000;
            padding-top: 10px;
            padding-bottom: 10px;
            border-bottom: 0;
            font-size: 14px;
        }
        
        .nomargin td
        {
            padding: 2px;
            vertical-align: middle !important;
        }
        
        .error
        {
            background: rgb(251, 227, 228);
            border: 1px solid #fbc2c4;
            color: #8a1f11;
            margin: 0 !important;
        }
        
        .qty
        {
            width: 10%;
        }
        
        .select2
        {
            width: 100% !important;
        }
        .select2-container--default .select2-selection--single .select2-selection__arrow
        {
            height: 26px;
        }
    </style>

    <script type="text/javascript">

        function Saveclick(id) {

            if (id.value == '') {
                document.getElementById(id.id).classList.add("error");
            }
            else {
                document.getElementById(id.id).classList.remove("error");
            }
        }

        function SaveClickDropdown() {
            var e = document.getElementById("ContentPlaceHolder1_auto_select1");
            var strSite = e.options[e.selectedIndex].value;

            if (strSite == "") {
                $(".select2").addClass("error");
                $(".select2-selection__rendered").addClass("error");
            }
            else {
                $(".select2").removeClass("error");
                $(".select2-selection__rendered").removeClass("error");
            }
        }

        function getNextButton(btnid) {

            if (btnid.id == "Finish") {
                document.getElementById("<%=Button1.ClientID %>").click();
            }

        }
    </script>
    <script type="text/javascript">
        function customOpen(url) {
            var w = window.open(url, '_blank');
            w.focus();
            window.location = "InvoiceForm.aspx";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hidSearchtext" runat="server" />
    <div class="mainpanel">
        <div class="contentpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4; margin: 10px 0;" />
                            <div id="wizard-basic2" class="wizard-style2">
                                <h3>
                                    Invoice Form <small>Enter your information.</small></h3>
                                <div>
                                    <div class="col-md-12">
                                        <div id="name" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Site
                                            </label>
                                            <div class="col-md-8">
                                                <label class="control-label">
                                                    <asp:Label ID="lblSite" runat="server" Text="Site" CssClass="control-label"></asp:Label>
                                                </label>
                                            </div>
                                        </div>
                                        <div id="pono" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Invoice No</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPoNo" runat="server" CssClass="form-control" placeholder="Enter Invoice No"></asp:TextBox>
                                                <asp:HiddenField ID="hidid" runat="server" />
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div id="address" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Address</label>
                                            <div class="col-md-8">
                                                <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="txtform" Text="Address"></asp:Label>
                                            </div>
                                        </div>
                                        <div id="date" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Date
                                            </label>
                                            <div class="col-md-8">
                                               
                                                    <asp:TextBox ID="txtCalender" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                                               
                                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtCalender" runat="server"
                                                    Format="dd MMM yyyy">
                                                </asp:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div id="Contactperson" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                GST No
                                            </label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtgstno" onchange="Saveclick(this)" runat="server" CssClass="form-control"
                                                    Style="text-transform: uppercase;" placeholder="Enter GST NO person"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="phoneno" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Phone No
                                            </label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" placeholder="Enter phone no"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div id="h2" class="form-group col-md-12">
                                        <label class="col-md-12 control-label supplierheading">
                                            Client Details</label>
                                    </div>
                                    <div class="form-group">
                                        <div id="Toname" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Client Name <span class="text-danger">*</span></label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Client Name"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ClientName_SelectedIndexchange" onchange="SaveClickDropdown()">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div id="cperson" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Address</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div id="saddress" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Delivery Address</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDeliveryAddress" runat="server" CssClass="form-control" placeholder="Enter delivery address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="sphoneno" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Client Phone No</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtSupplierPhoneNo" runat="server" CssClass="form-control" placeholder="Enter client phone no"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div id="mailid" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                Mail Id
                                            </label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtSupplierEmailID" runat="server" CssClass="form-control" placeholder="Enter mail id"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" Display="Dynamic"
                                                    ControlToValidate="txtSupplierEmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                       
                                        <div id="GSTno" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                GST No</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtSupplierGSTNo" runat="server" CssClass="form-control" Style="text-transform: uppercase;"
                                                    placeholder="Enter gst no"></asp:TextBox>
                                                <asp:HiddenField ID="hidFSSAI" runat="server" />
                                            </div>
                                        </div>

                                        <div id="BillNo" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                                E-Way Bill No</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtewaybillno" runat="server" CssClass="form-control"
                                                    placeholder="Enter E-Way Bill No"></asp:TextBox>
                                            </div>
                                        </div>

                                          <div id="Transport" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                               Transport</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txttransport" runat="server" CssClass="form-control"
                                                    placeholder="Enter Tansport Mode"></asp:TextBox>
                                            </div>
                                        </div>

                                          <div id="dateofsupply" class="form-group col-md-6">
                                            <label class="col-md-4 control-label">
                                               Date Of Supply</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtdateofsupply" runat="server" CssClass="form-control" placeholder="From Date To To Date"
                                                  ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="visible-flase" style="display: none;">
                                            <asp:TextBox ID="txtDraftid" runat="server" ForeColor="White"></asp:TextBox>
                                            <asp:TextBox ID="txtVatHide" runat="server" ForeColor="White"></asp:TextBox>
                                            <asp:TextBox ID="txtCstHide" runat="server" ForeColor="White"></asp:TextBox>
                                            <asp:Label ID="lblDiscount" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblAction" runat="server" ForeColor="White"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <h3>
                                    Product Details <small>Enter Your Information.</small></h3>
                                <div>
                                    <asp:HiddenField ID="hidHSNCode" runat="server" />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                                        <ContentTemplate>
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grdProduct" runat="server" CssClass="table nomargin grid" AutoGenerateColumns="false"
                                                        DataKeyNames="PURCHES_ORDER_PRODUCT_ID" BorderStyle="None" OnRowDataBound="grdProduct_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="#" ItemStyle-Width="3%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PARTICULAR">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'
                                                                        Style="display: none;"></asp:Label>
                                                                    <asp:Label ID="lblProduct_id" runat="server" Text='<%# Eval("MATERIAL_ID")%>' Style="display: none;"></asp:Label>
                                                                    <asp:DropDownList ID="auto_selectProduct" runat="server" data-placeholder="Select Product"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="Product_SelectedIndexChange">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="HSN Code" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txthsn" runat="server" ReadOnly="true" Text='<%# Eval("HSN_CODE")%>' CssClass="form-control"></asp:TextBox>
                                                                   </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GST" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGst" runat="server" Text='<%# Eval("GST")%>' Style="display: none;"></asp:Label>
                                                                    <asp:Label ID="lblGst_id" runat="server" Text='<%# Eval("GST_ID")%>' Style="display: none;"></asp:Label>
                                                                    <asp:DropDownList ID="ddlGstRate" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnTextChanged="Product_SelectedIndexChange">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("QTY")%>' CssClass="form-control"
                                                                        AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Input"
                                                                        SetFocusOnError="true" ControlToValidate="txtQty" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UNIT" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtUnit" runat="server" Text='<%# Eval("UNIT")%>' CssClass="form-control"
                                                                        AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("RATE")%>' CssClass="form-control"
                                                                        AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Input"
                                                                        SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="12%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("AMOUNT")%>' CssClass="form-control"
                                                                        ReadOnly="true" AutoPostBack="true" OnTextChanged="ProductContent_TextChange"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Input"
                                                                        SetFocusOnError="true" ControlToValidate="txtAmount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" OnClick="RemoveProduct" ForeColor="#FF5722"
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
                                                                    <td style="width: 40%;">
                                                                        Total
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtTotal" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        CGST
                                                                    </td>
                                                                    <td style="width: 25%;">
                                                                        <asp:TextBox ID="txtCGSTPer" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                                                        <asp:HiddenField ID="hidGstID" runat="server" />
                                                                        <asp:HiddenField ID="hidGstValue" runat="server" />
                                                                    </td>
                                                                    <td style="width: 70%;">
                                                                        <asp:TextBox ID="txtCGSTAmount" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        SGST
                                                                    </td>
                                                                    <td style="width: 25%;">
                                                                        <asp:TextBox ID="txtSGSTPer" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 70%;">
                                                                        <asp:TextBox ID="txtSGSTAmount" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                       
                                                                <tr>
                                                                    <td>
                                                                        Net Total
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtNet" CssClass="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                             
                                                                <tr>
                                                                    <td>
                                                                        Round Off
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtRoundOff" CssClass="form-control" runat="server" Text="0" AutoPostBack="true"
                                                                            OnTextChanged="txtContent_Textchanged" onclick="if(this.value=='0') this.value='';"
                                                                            onblur="if(this.value=='') this.value='0';"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Input"
                                                                            SetFocusOnError="true" ControlToValidate="txtRoundOff" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Grand Total
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
                                
                                <asp:HiddenField ID="HidWizardState" runat="server" />
                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSubmit_Click" Style="display: none;" />
                            </div>
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
