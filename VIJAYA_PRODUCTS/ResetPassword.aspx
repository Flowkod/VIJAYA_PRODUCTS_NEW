<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ResetPassword.aspx.cs" Inherits="Nation52Admin.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function ErrorOk() {
            alertify.alert('Warning', 'Old Password does not match...!', function () { alertify.success('Ok'); });
        }

        function SuccessOk() {
            alertify.error('Password reset successfully...');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="site.aspx">Add Material</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Reset Your Password</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Login details.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Old Password<span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"
                                            placeholder="Old Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOldPassword"
                                            ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Old Password"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        New Password<span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"
                                            placeholder="New Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPassword"
                                            ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter New Password"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="col-md-4 control-label">
                                        Confirm New Password<span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"
                                            placeholder="Confirm Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtConfirmPassword"
                                            ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Confirm Password"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                                            ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Password Does Not Match The Confirm Password"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-block btn-danger" Text="Reset"
                                        OnClick="btnReset_Click"></asp:Button>
                                </div>
                                <div class="clearfix">
                                </div>
                                <hr style="border-color: #03A9F4;" />
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
