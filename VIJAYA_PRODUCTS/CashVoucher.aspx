<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="CashVoucher.aspx.cs" Inherits="SparkInventory.Expenses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function SuccessOk() {
            alertify.error('Cash Memo added successfully...');
            window.location = "CashVoucher.aspx";
        }

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Cash Memo deleted successfully...');
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
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDeleteCashMemo" runat="server"
        Style="display: none;" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="CashVoucher.aspx">Cash Memo</a></li>
            </ol>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add Cash Memo</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <h3>
                                    Available Balance:
                                    <asp:Label ID="lblAvailableBalance" runat="server"></asp:Label>
                                </h3>
                                <br />
                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        SrNo. <span class="text-danger">*</span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtSrNo" runat="server" class="form-control" placeholder="Sr No"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Date
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtDate" runat="server" class="form-control" placeholder="Date"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txtDate" runat="server"
                                            Format="dd MMM yyyy">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-md-3 control-label">
                                        Party Name <span class="text-danger">*</span></label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPartyName" runat="server" class="form-control" placeholder="Party Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="form-group col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdCashMemo" runat="server" Width="100%" AutoGenerateColumns="False"
                                            ShowHeader="false" AllowPaging="false" BorderStyle="None" PageSize="10" CssClass="table nomargin grid"
                                            DataKeyNames="DESCRIPTION_ID">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Description" ItemStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDescription" runat="server" class="form-control" Text='<%# Eval("Description")%>'
                                                            placeholder="Discription" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" class="form-control" Text='<%# Eval("QUANTITY")%>'
                                                            placeholder="Quantity" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                                            ValidationGroup="Bill" Display="Dynamic" ControlToValidate="txtQty" SetFocusOnError="true"
                                                            ErrorMessage="Invalid Quantity"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid amount."
                                                            SetFocusOnError="true" ControlToValidate="txtQty" ValidationExpression="^[1-9][\.\d]*(,\d+)?$"
                                                            ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" class="form-control" Text='<%# Eval("RATE")%>'
                                                            placeholder="Amount" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                                            ValidationGroup="Bill" Display="Dynamic" ControlToValidate="txtRate" SetFocusOnError="true"
                                                            ErrorMessage="Please Enter Valid Rate"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid amount."
                                                            SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[1-9][\.\d]*(,\d+)?$"
                                                            ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150px" ItemStyle-CssClass="btnRemovebtn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete" ForeColor="#FF5722">x</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <asp:HiddenField ID="hidCashMemoID" runat="server" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick(this)" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="AddClient.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
                                </div>
                                <div class="col-md-6">
                                    <h4>
                                        Grand Total :<asp:Label ID="lblGrandTotal" runat="server" Text="0"></asp:Label></h4>
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
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Cash Memo Report</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12 row" style="margin-bottom: 10px;">
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        AutoCompleteType="None"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" runat="server"
                                        Format="dd MMM yyyy">
                                    </asp:CalendarExtender>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        AutoCompleteType="None"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txttoDate" runat="server"
                                        Format="dd MMM yyyy">
                                    </asp:CalendarExtender>
                                </div>
                               <div class="col-md-6">
                                    <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Supplier Name">
                                    </asp:DropDownList>
                                        </div>
                            </div>
                             <div class="col-md-12 row" style="margin-bottom: 10px;">
                              <div class="col-md-8">
                              </div>
                             <div class="col-md-2">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="Datevalidate();" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnSearchCashMemo" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnPrint" runat="server" Text="Print All" CssClass="btn btn-info"
                                        Width="80px" OnClick="btnPrintCashMemo" />
                                </div>
                                </div>
                            <div class="clearfix">
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdCashMemoReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" OnPageIndexChanging="grdCashMemoReport_PageIndexChanging"
                                    ShowFooter="true" BorderStyle="None" PageSize="10" CssClass="table nomargin grid"
                                    DataKeyNames="CASH_MEMO_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SRNO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrno" runat="server" Font-Bold="false" Text='<%# Eval("SRNO")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyName" runat="server" Font-Bold="false" Text='<%# Eval("PARTY_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="DATE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="GRAND TOTAL">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="false" Text='<%# Eval("GRAND_TOTAL")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href='CashMemoPrint.aspx?cashmemo=<%# Eval("CASH_MEMO_ID")%>' target="_blank"
                                                    class="btn btn-info" style="font-size: 13px; width: 60px; color: White; padding: 5px;">
                                                    View</a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btnDeleteConfirm"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                            </div>
                        </div>
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
