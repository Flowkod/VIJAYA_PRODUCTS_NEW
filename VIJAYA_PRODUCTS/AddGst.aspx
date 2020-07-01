<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddGst.aspx.cs" Inherits="RCandJJ.AddGst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function Saveclick() {

        if ($("#ContentPlaceHolder1_txtGST").val() == '') {
            $("#gst").addClass("has-error"); OnClick = "btnSave_Click"
        }
    }

    function SuccessOk() {
        alertify.error('GST added successfully...');
    }

    function UpdateOk() {
        alertify.error('GST updated successfully...');
    }

    function Confirm() {
        alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
    }

    function DeleteOk() {
        alertify.error('GST deleted successfully...');
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display:none;" />
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="AddGst.aspx">Add GST %</a></li>
            </ol>
            <div class="row">
                <div class="col-md-5">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add GST %</h4>
                                </div>
                            <div class="panel-body nopaddingtop" style="height: 400px;">
                            <p>
                                <br />
                                Please provide your GST %.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="gst" class="form-group col-md-12">
                                    <label class="col-md-4 control-label">
                                        GST % <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtGST" runat="server" class="form-control" placeholder="Enter GST %"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGST"
                                            CssClass="error" ErrorMessage="" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid %."
                                            SetFocusOnError="true" ControlToValidate="txtGST" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                               
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick()" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="AddGst.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="panel" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                GST Report</h4>
                        </div>
                        <div class="panel-body">
                         <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Opps! No record found..</strong>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdGSTReport" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="grdGSTReport_PageIndexChanging"
                                    BorderStyle="None" PageSize="10" CssClass="table nomargin grid" DataKeyNames="GST_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="GST %">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("GST")%>'></asp:Label>
                                                <asp:TextBox ID="txtGst" runat="server" Text='<%# Eval("GST")%>' Visible="false"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnCancel" title="Cancel" runat="server" OnClick="btnCancel_Click" Visible="false"><i class="fa fa-close"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnEdit" title="Edit" runat="server" OnClick="btnEdit"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnUpdate" title="Update" runat="server" OnClick="btnUpdate" Visible="false"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" tile="Delete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
