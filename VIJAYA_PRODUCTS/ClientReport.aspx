<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ClientReport.aspx.cs" Inherits="RCandJJ.CustomerReport1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Confirm() {

            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Customer deleted successfully...');
        }

        function UpdateOk() {
            alertify.error('Follow date updated successfully...');
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
        .control-label
        {
            padding-top: 10px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="ClientReport.aspx">Client Report</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Client Report</h4>
                        </div>
                        <div class="panel-body">
                            <div class="row" style="margin-bottom: 30px;">
                                <div class="col-md-1 control-label">
                                    Client Name</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control" placeholder="Client Name"
                                        AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="5"
                                        CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                        CompletionListItemCssClass="listItem" CompletionSetCount="1" EnableCaching="false"
                                        FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionListName"
                                        TargetControlID="txtClientName">
                                    </asp:AutoCompleteExtender>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdClientReport" runat="server" Width="1500px" AutoGenerateColumns="False"
                                    DataKeyNames="CUSTOMER_ID" OnPageIndexChanging="grdClientReport_PageIndexChanging"
                                    BorderStyle="None" AllowPaging="true" PageSize="10" CssClass="table nomargin grid">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("CUSTOMER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Font-Bold="false" Text='<%# Eval("MOBILE_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Gst No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Font-Bold="false" Text='<%# Eval("GST_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="FSSAI No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label66" runat="server" Font-Bold="false" Text='<%# Eval("FSSAI_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Email Id">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="false" Text='<%# Eval("EMAIL_ID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Font-Bold="false" Text='<%# Eval("Address")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Delivery Address">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Font-Bold="false" Text='<%# Eval("DELIVERY_ADDRESS")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" OnClick="lnkView_Click" CssClass="btn btn-info"
                                                    data-toggle="modal" data-target="#myModal" Style="padding: 7px;" Text="View Details" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <a href='AddClient.aspx?cid=<%# Eval("CUSTOMER_ID")%>'><i class="fa fa-pencil"
                                                    title="Edit"></i></a>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o" title="Delete"></i></asp:LinkButton>
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
    <div class="modal bounceIn animated in" runat="server" id="myModal" tabindex="-1"
        role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;
        padding-right: 17px;">
        <div class="modal-dialog">
            <div class="modal-content" style="height: 550px; overflow: auto;">
                <div class="modal-header">
                    <button type="button" class="close" onclick="Closemodel()">
                        ×</button>
                    <h4 class="modal-title" id="myModalLabel">
                        Details</h4>
                </div>
                <div class="modal-body">
                    <p>
                         <span>Name : </span>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></p>
                    <p>
                        <span>Address : </span><asp:Label ID="lblAddress" runat="server"></asp:Label></p>
                         <p>
                        <span> Delivery Address : </span>
                        <asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label></p>
                    <p>
                        <span> Mobile No : </span>
                        <asp:Label ID="lblMobileno" runat="server" Text="Mobile No"></asp:Label></p>
                    <p>
                        <span> Email Id : </span>
                        <asp:Label ID="lblEmail" runat="server" Text="Email Id"></asp:Label></p>
                   
                    <%--<p>
                        Pan No :
                        <asp:Label ID="lblPanNo" runat="server"></asp:Label></p>--%>
                    <p>
                        <span>GST No : </span><asp:Label ID="lblGstNo" runat="server"></asp:Label></p>
                    <div class="table-responsive">
                        <asp:GridView ID="grdPopupDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                            BorderStyle="None" AllowPaging="false" CssClass="table nomargin grid">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="GST">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Font-Bold="false" Text='<%# Eval("GST")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("RATE")%>' Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" onclick="Closemodel()">
                            Close</button>
                    </div>
                </div>
                <!-- modal-content -->
            </div>
            <!-- modal-dialog -->
        </div>
    </div>
    <script type="text/javascript">
        function Closemodel() {
            document.getElementById('ContentPlaceHolder1_myModal').style.display = 'none';

        }
    </script>
    <asp:Label ID="lblClientID" runat="server"></asp:Label>
    <asp:Label ID="lblClientID1" runat="server"></asp:Label>
</asp:Content>
