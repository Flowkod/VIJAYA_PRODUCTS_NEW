<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="AddClient.aspx.cs" Inherits="RCandJJ.AddCustomer1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function Saveclick(id) {

            if (id.id == "ContentPlaceHolder1_btnSubmit") {

                if ($("#ContentPlaceHolder1_txtCustomerName").val() == '') {
                    $("#ContentPlaceHolder1_txtCustomerName").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtCustomerName").removeClass("error");
                }


                if ($("#ContentPlaceHolder1_txtVehical").val() == '') {
                    $("#ContentPlaceHolder1_txtVehical").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtVehical").removeClass("error");
                }

               
            }

            if (id.value == '') {
                document.getElementById(id.id).classList.add("error");
            }
            else {
                document.getElementById(id.id).classList.remove("error");
            }
        }

        function SuccessOk() {
            alertify.error('Client added successfully...');
            //window.location = "AddClient.aspx";
        }

        function UpdatedOk() {
            alertify.error('Client updated successfully...');
            window.location = "ClientReport.aspx";
        }

    </script>
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
        .error
        {
            border: solid 1px #FF5722;
        }
        .completionList
        {
            border: 1px solid #aaa;
            height: 200px;
            padding: 3px;
            position: absolute;
            top: 0;
            overflow: auto;
            background-color: #FFFFFF;
            z-index: 999999 !important;
        }
        .completionList li
        {
            list-style: none;
            padding: 5px;
        }
        .completionList li:hover
        {
            background-color: #2598ab;
            color: White;
            border-radius: 2px;
        }
        .btnRemovebtn
        {
            vertical-align: middle !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="AddClient.aspx">Client Management</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Client</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your details, address and GST No.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Client Name <span class="text-danger">*</span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtCustomerName" runat="server" class="form-control" placeholder="Enter Customer name..."
                                            onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName"
                                            Display="None" CssClass="error" ErrorMessage="User name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <%-- <label class="col-sm-2 control-label">
                                        Contact Person
                                    </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" placeholder="Enter Contact Person Name..."></asp:TextBox>
                                    </div>--%>
                                    <label class="col-md-2 control-label">
                                        Mobile No </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Type your Mobile No..."
                                            onchange="Saveclick(this)"></asp:TextBox>                                     
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                            ControlToValidate="txtMobileNo" ValidationExpression="[0-9]{10}" ForeColor="Red"
                                            runat="server" ErrorMessage="Please Enter Valid Mobile No"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Email Id </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" placeholder="Enter Email ID..."
                                            onchange="Saveclick(this)"></asp:TextBox>                                     
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                            ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        GST No </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtGSTNo" runat="server" class="form-control" placeholder="Enter GST No..." style="text-transform: uppercase;"
                                            onchange="Saveclick(this)"></asp:TextBox>                                 
                                    </div>
                                </div>
                          
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Address
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control"
                                            placeholder="Type your address..." Height="80px"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Delivery Address
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtDeliveryAddress" runat="server" TextMode="MultiLine" class="form-control"
                                            placeholder="Type your delivery address..." Height="80px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">                                   
                                    <label class="col-sm-2 control-label">
                                        FSSAI No</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFssai" runat="server" class="form-control" placeholder="Enter FSSAI No..." style="text-transform: uppercase;"></asp:TextBox>                                 
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="form-group col-md-12">
                                    <p>
                                        <br />
                                        Please provide Product details.</p>
                                    <hr style="border-color: #03A9F4;" />
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdCustomerProduct" runat="server" Width="100%" AutoGenerateColumns="False"
                                            OnRowDataBound="grdCustomerProduct_RowDataBound" ShowHeader="false" AllowPaging="false"
                                            BorderStyle="None" PageSize="10" CssClass="table nomargin grid" DataKeyNames="ID">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px" ItemStyle-CssClass="btnRemovebtn">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Product Name" ItemStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtProductName" runat="server" class="form-control" Text='<%# Eval("MATERIAL_NAME")%>'
                                                            placeholder="Product Name" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="5"
                                                            CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                            CompletionListItemCssClass="listItem" CompletionSetCount="1" EnableCaching="false"
                                                            FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                            TargetControlID="txtProductName">
                                                        </asp:AutoCompleteExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                           
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Rate" HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" class="form-control" Text='<%# Eval("RATE")%>'
                                                            placeholder="Rate" AutoPostBack="true" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red"
                                                            ValidationGroup="Bill" Display="Dynamic" ControlToValidate="txtRate" SetFocusOnError="true"
                                                            ErrorMessage="Please Enter Valid Rate"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                            ErrorMessage="Invalid amount." SetFocusOnError="true" ControlToValidate="txtRate"
                                                            ValidationExpression="^[1-9][\.\d]*(,\d+)?$" ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150px" ItemStyle-CssClass="btnRemovebtn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete" ForeColor="#e70000">x</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick(this)" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="AddClient.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
                                </div>
                            </div>
                        </div>
                        <!-- panel-body -->
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <!-- panel -->
                <!-- col-md-6 -->
            </div>
        </div>
        <!-- contentpanel -->
    </div>
    <asp:Label ID="lblID" runat="server"></asp:Label>
</asp:Content>
