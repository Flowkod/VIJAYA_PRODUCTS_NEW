<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddFund.aspx.cs" Inherits="SRIRAM_MILK.AddFund" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function SuccessOk() {
            alertify.error('Cash Memo added successfully...');
            window.location = "AddFund.aspx";
        }
       

        function DeleteOk() {
            alertify.error('Cash Memo deleted successfully...');
        }
        function SuccessfuelOk() {
            alertify.error('Fund added successfully...');
            window.location = "AddFund.aspx";
        }

        function UpdateOk() {
            alertify.error('Expenses updated successfully...');
            window.location = "AddFund.aspx";
        }

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button4.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Expenses deleted successfully...');
        }

        function WarningAmount() {
            alertify.alert('Warning', 'Insufficient Amount.!', function () { alertify.success('Ok'); });
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
        .table-responsive {
    overflow-x: auto;
   
    height: 400px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Button ID="Button2" Text="Upload" runat="server"
        Style="display: none;" />
    <asp:ToolkitScriptManager runat="server">
    </asp:ToolkitScriptManager>
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="AddFund.aspx">Add Fund</a></li>
            </ol>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add Fund</h4>
                        </div>
                          <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4;" />                            
                            
                            <div class="col-md-12">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
                                    <h3>
                                Available Balance:
                                <asp:Label ID="lblAvailableBalance" runat="server"></asp:Label>
                              
                            </h3> <br />
                                    <div id="Div1" class="form-group col-md-12">
                                        <label class="col-md-4 control-label">
                                            Description
                                        </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDescription" runat="server" class="form-control" TextMode="MultiLine"
                                                Height="100px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="sitename" class="form-group col-md-12">
                                        <label class="col-md-4 control-label">
                                            Amount<span class="text-danger">*</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
                                                ForeColor="Red" ErrorMessage="Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Amount."
                                                SetFocusOnError="true" ControlToValidate="txtAmount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                ForeColor="Red" ValidationGroup="fuel" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                  
                                    <div class="col-md-12">
                                        <hr style="border-color: #03A9F4;" />
                                        <asp:Button ID="btnSubmit" OnClick="btnSave_Click" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                           ValidationGroup="Save" />
                                        <asp:Button ID="Button1" runat="server" Text="Button"  Style="display: none;" />
                                        <a href="AddFund.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
                                    </div>
                                </asp:Panel>
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
                    <div class="panel" style="height: 550px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Fund Report</h4>
                        </div>
                        <div class="panel-body">
                            <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Oops! No record found..</strong>
                            </div>
                            <div class="table-responsive">
                                <asp:Panel ID="Panel2" runat="server" DefaultButton="Button3">
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                                         <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txtDate" runat="server"
                                            Format="dd MMM yyyy">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" placeholder="To Date"></asp:TextBox>
                                         <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtToDate" runat="server"
                                            Format="dd MMM yyyy">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div class="col-md-1" style="margin-bottom: 20px;">
                                        <asp:Button ID="Button3" runat="server" Text="Search" OnClick="btnSearch" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                             />
                                    </div>
                                    <br />
                                   
                                    <br /><br />
                                </asp:Panel> <h4>
                                Total Amount Added :
                                <asp:Label ID="lblAvailableAmount" runat="server"></asp:Label>
                                </h4>
                                <asp:GridView ID="grdExpensesReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" OnPageIndexChanging="grdExpensesReport_PageIndexChanging"
                                    BorderStyle="None" PageSize="5" CssClass="table nomargin grid" DataKeyNames="FUND_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SRNO">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Description" HeaderStyle-Width="35%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Font-Bold="false" Text='<%# Eval("DESCRIPTION")%>'></asp:Label>
                                                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("DESCRIPTION")%>'
                                                    Visible="false" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Fund Amount" HeaderStyle-Width="35%">
                                            <ItemTemplate>
                                                <asp:Panel ID="Panel3" runat="server" DefaultButton="btnUpdate">
                                                    <asp:Label ID="lblAmount" runat="server" Font-Bold="false" Text='<%# Eval("FUND_AMOUNT")%>'></asp:Label>
                                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("FUND_AMOUNT")%>' Visible="false"
                                                        CssClass="form-control"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Amount."
                                                        SetFocusOnError="true" ControlToValidate="txtAmount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </asp:Panel>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Date" HeaderStyle-Width="35%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Font-Bold="false" Text='<%# Eval("CREATED_ON", "{0:dd-MM-yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnCancel" runat="server"  title="Cancel" OnClick="btnCancel_Click" Visible="false"><i class="fa fa-close"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnEdit" title="Edit" OnClick="btnEdit" runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnUpdate" runat="server"  title="Update" OnClick="btnUpdate"  Visible="false"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkDelete" runat="server" title="Delete" OnClick="btnDeleteConfirm" ><i class="fa fa-trash-o" ></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
                                
                              
                            </h4> 
                               <asp:Button ID="Button4" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
                                <div class="clearfix">
                                </div>
                               <%-- <h4>
                                    Total Spent Amount :
                                    <asp:Label ID="lblTotalExpensesAmount" runat="server" Text="0"></asp:Label>
                                </h4>--%>
                            </div>
                            <!-- table-responsive -->
                        </div>
                    </div>
                </div>
           
                <!-- panel -->
                <!-- col-md-6 -->
            </div>
        </div>
       
    </div>
    <asp:Label ID="lblID" runat="server"></asp:Label>
</asp:Content>

