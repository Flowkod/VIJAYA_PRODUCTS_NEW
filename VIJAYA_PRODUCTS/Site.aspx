<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Site.aspx.cs" Inherits="RCandJJ.Site" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function Saveclick() {

        if ($("#ContentPlaceHolder1_txtName").val() == '') {
            $("#sitename").addClass("has-error"); OnClick = "btnSave_Click"
        }
    }

    function SuccessOk() {
        alertify.error('Site added successfully...');
    }

    function UpdateOk() {
        alertify.error('Site updated successfully...');
    }

    function Confirm() {
        alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
    }

    function DeleteOk() {
        alertify.error('Site deleted successfully...');
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
                <li><a href="site.aspx">Add Site</a></li>
            </ol>
            <div class="row">
                <div class="col-md-5">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Site</h4>
                                </div>
                            <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Material name and Material rate.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="sitename" class="form-group col-md-12">
                                    <label class="col-md-3 control-label">
                                        Site Name <span class="text-danger">*</span></label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Type your Site name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Display="None"
                                            CssClass="error" ErrorMessage="Site name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-md-3 control-label">
                                        Site Address</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Type your Site address..."
                                            TextMode="MultiLine" Height="100px"></asp:TextBox>
                                    </div>
                                </div>
                            <%--    <div class="form-group col-md-12">
                                    <label class="col-sm-3 control-label">
                                        Contact Person</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtContact" runat="server" class="form-control" TextMode="MultiLine"
                                            Height="70px" placeholder="Ex- Name-xyz, Mob- 999994562..."></asp:TextBox>
                                    </div>
                                </div>--%>
                                   <div class="form-group col-md-12">
                                    <label class="col-sm-3 control-label">
                                      GST NO</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtGst" runat="server" class="form-control" style="text-transform: uppercase;"
                                         placeholder="GST NO"></asp:TextBox>
                                    </div>
                                </div>
                                  <div class="form-group col-md-12">
                                    <label class="col-sm-3 control-label">
                                       Mobile Number</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                             placeholder="Mobile Number"></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                            ControlToValidate="txtMobile" ValidationExpression="[0-9]{10}" ForeColor="Red"
                                            runat="server" ErrorMessage="Please Enter Valid Mobile No"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-md-12">
                                    <label class="col-sm-3 control-label">
                                       HSN Code</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txthsnCode" runat="server" class="form-control" 
                                             placeholder="HSN Code"></asp:TextBox>                                         
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick()" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="site.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
                                Site Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="grdSiteName" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="grdSiteName_PageIndexChanging"
                                    BorderStyle="None" PageSize="10" CssClass="table nomargin grid" DataKeyNames="SITE_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="SRNO" HeaderText="SRNO" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle Width="50px"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SiteName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("SITE_NAME")%>'></asp:Label>
                                              
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("Address")%>'></asp:Label>
                                             
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Gst No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("GST_NO")%>'></asp:Label>                                            
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="MOBILE NO">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Font-Bold="false" Text='<%# Eval("MOBILE_NO")%>'></asp:Label>
                                          
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnCancel" title="Cancel" runat="server" OnClick="btnCancel_Click" Visible="false"><i class="fa fa-close"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnEdit" title="Edit" runat="server" OnClick="btnEdit"><i class="fa fa-pencil"></i></asp:LinkButton>                                               
                                                <%--<asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>--%>
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
