<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SignUp.aspx.cs" Inherits="RCandJJ.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function Saveclick(id) {

            if (id.id == "ContentPlaceHolder1_btnSubmit") {

                if ($('#ContentPlaceHolder1_ddlSite').find('option:selected').text() == '-Select Site Name-') {

                    $("#ContentPlaceHolder1_ddlSite").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_ddlSite").removeClass("error");
                }

                if ($("#ContentPlaceHolder1_txtName").val() == '') {
                    $("#ContentPlaceHolder1_txtName").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtName").removeClass("error");
                }

                if ($("#ContentPlaceHolder1_txtMobileNo").val() == '') {
                    $("#ContentPlaceHolder1_txtMobileNo").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtMobileNo").removeClass("error");
                }

                if ($("#ContentPlaceHolder1_txtEmailId").val() == '') {
                    $("#ContentPlaceHolder1_txtEmailId").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtEmailId").removeClass("error");
                }

                if ($("#ContentPlaceHolder1_txtPassword").val() == '') {
                    $("#ContentPlaceHolder1_txtPassword").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtPassword").removeClass("error");
                }

                if ($("#ContentPlaceHolder1_txtConfirmPassword").val() == '') {
                    $("#ContentPlaceHolder1_txtConfirmPassword").addClass("error");
                }
                else {
                    $("#ContentPlaceHolder1_txtConfirmPassword").removeClass("error");
                }
            }

            if (id.value == '') {
                document.getElementById(id.id).classList.add("error");
            }
            else {
                document.getElementById(id.id).classList.remove("error");
            }

            if ($('#ContentPlaceHolder1_ddlSite').find('option:selected').text() == '-Select Site Name-') {

                $("#ContentPlaceHolder1_ddlSite").addClass("error");
            }
            else {
                $("#ContentPlaceHolder1_ddlSite").removeClass("error");
            }

        }

        function SuccessOk() {
            alertify.error('User added successfully...');
        }

        function UpdateOk() {
            alertify.error('User updated successfully...');
        }

        function WarningOk() {
            alertify.alert('Warning', 'Select Authentication type...!', function () { alertify.success('Ok'); });
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="SignUp.aspx">Sign Up</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Sign Up</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your details, address and contact person.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Site Name <span class="text-danger">*</span></label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlSite" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSite"
                                            Display="none" InitialValue="0" CssClass="error" ErrorMessage="Select Site..."
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Name <span class="text-danger">*</span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Type your name..."
                                            onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                            Display="None" CssClass="error" ErrorMessage="User name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Mobile No <span class="text-danger">*</span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Type your Mobile No..."
                                            onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo"
                                            Display="None" CssClass="error" ErrorMessage="User Mobile No required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                            ControlToValidate="txtMobileNo" ValidationExpression="[0-9]{10}" ForeColor="Red"
                                            runat="server" ErrorMessage="Please Enter Valid Mobile No"></asp:RegularExpressionValidator>
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        Email Id<span class="text-danger">*</span></label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" placeholder="Type your Email ID..."
                                            onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailId"
                                            Display="None" CssClass="error" ErrorMessage="User Email ID required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                            ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Password<span class="text-danger">*</span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" onchange="Saveclick(this)" TextMode="Password" placeholder="Type your password..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword"
                                            Display="None" CssClass="error" ErrorMessage="Password required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        Confirm Password<span class="text-danger">*</span></label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" class="form-control"
                                            placeholder="Type your Confirm Password..." onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword"
                                            Display="None" CssClass="error" ErrorMessage="Confirm password required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToCompare="txtPassword"
                                            ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Password must be same"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Link Authentication
                                    </label>
                                    <div class="col-md-10">
                                        <label class="ckbox">
                                            <asp:CheckBox ID="checkMarketing" runat="server" />
                                            <span>GST</span>
                                        </label>
                                        <label class="ckbox">
                                            <asp:CheckBox ID="checkPurchase" runat="server" />
                                            <span>Invoice </span>
                                        </label>
                                        <label class="ckbox">
                                            <asp:CheckBox ID="checkSite" runat="server" />
                                            <span>Site Management</span>
                                        </label>
                                        <label class="ckbox">
                                            <asp:CheckBox ID="checkEngineering" runat="server" />
                                            <span>Client</span>
                                        </label>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick(this)" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="SignUp.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
</asp:Content>
