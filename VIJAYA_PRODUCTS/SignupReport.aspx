<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SignupReport.aspx.cs" Inherits="RCandJJ.SignupReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('User deleted successfully...');
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
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="SignupReport.aspx">User Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                User Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="grdLoginReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="false" BorderStyle="None" CssClass="table nomargin grid" DataKeyNames="USER_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SrNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("USER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Font-Bold="false" Text='<%# Eval("EMAIL_ID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="false" Text='<%# Eval("MOBILE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Password">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Font-Bold="false" Text='<%# Eval("Password")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="GST">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Font-Bold="false" Text='<%# Eval("COLUMN_1")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Invoice">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Font-Bold="false" Text='<%# Eval("COLUMN_2")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Site">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Font-Bold="false" Text='<%# Eval("COLUMN_3")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Client">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Font-Bold="false" Text='<%# Eval("COLUMN_4")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <a href='SignUp.aspx?userid=<%# Eval("USER_ID")%>'><i class="fa fa-pencil"></i></a>
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
</asp:Content>
