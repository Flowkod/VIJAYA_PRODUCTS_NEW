<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreditDebit.aspx.cs" Inherits="VIJAYA_PRODUCTS.CreditDebit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">

       function Saveclick() {

           if ($("#ContentPlaceHolder1_auto_select1").val() == '') {
               $("#Toname").addClass("has-error");
           }
           else {
               $("#Toname").removeClass("has-error");
           }


           if ($("#ContentPlaceHolder1_txtPartyName").val() == '') {
               $("#name").addClass("has-error");
           }
           else {
               $("#name").removeClass("has-error");
           }

           if ($("#ContentPlaceHolder1_txtType").val() == '') {
               $("#Type").addClass("has-error");
           }
           else {
               $("#Type").removeClass("has-error");
           }


           if ($("#ContentPlaceHolder1_txtGST").val() == '') {
               $("#gst").addClass("has-error");
           }
           else {
               $("#gst").removeClass("has-error");
           }

           if ($("#ContentPlaceHolder1_txtDate").val() == '') {
               $("#Date").addClass("has-error");
           }
           else {
               $("#Date").removeClass("has-error");
           }


           if ($("#ContentPlaceHolder1_txtAmount").val() == '') {
               $("#Amount").addClass("has-error");
           }
           else {
               $("#Amount").removeClass("has-error");
           }

           if ($("#ContentPlaceHolder1_txtDescription").val() == '') {
               $("#Description").addClass("has-error");
           }
           else {
               $("#Description").removeClass("has-error");
           }


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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="site.aspx">Credit/Debit Entry</a></li>
            </ol>
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add Credit/Debit Entry</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide below Details.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>

                                 <div id="Toname" class="form-group col-md-12 nomargin">
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="auto_select1" runat="server" class="form-control" data-placeholder="Supplier Name or Customer Name" 
                                                AutoPostBack="true" OnSelectedIndexChanged="Name_SelectedIndexchange">
                                                </asp:DropDownList>
                    </div>
                                 </div>
                                 <center>OR<center>
                                <div id="name" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPartyName" runat="server" class="form-control" placeholder="Type your Party Name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPartyName"
                                            Display="None" CssClass="error" ErrorMessage="Party Name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    </div>

                                <div id="gst" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                                        <asp:ListItem>Select Type</asp:ListItem>
                                        <asp:ListItem>Credit</asp:ListItem>
                                        <asp:ListItem>Debit</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div id="Date" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtDate" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                            Display="None" CssClass="error" ErrorMessage="Date required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                       
                                    </div>
                                </div>

                                <div id="Amount" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" placeholder="Amount"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
                                            Display="None" CssClass="error" ErrorMessage="Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter valid amount" ValidationGroup="Save"
                                                                        SetFocusOnError="true" ControlToValidate="txtAmount" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div id="Description" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                      OnClick="btnSave_Click" OnClientClick="Saveclick()" ValidationGroup="Save" />
                                    
                                </div>
                            </div>
                        </div>
                        <!-- panel-body -->
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>


                                


                <div class="col-md-8">
                    <div class="panel" style="height: 625px; overflow: auto;">
                        <div class="panel-heading">
                            <h4 class="panel-title col-md-6">
                                Credit/Debit Report</h4>
                        </div>


                       <div class="panel-body nopaddingtop">
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12 row" style="margin-bottom: 10px;">

                                <div class="col-md-3">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="FROM DATE"
                                        AutoCompleteType="None" TextMode="Date"></asp:TextBox>
                                  
                                </div>

                                <div class="col-md-3">
                                    <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" placeholder="TO DATE"
                                        AutoCompleteType="None" TextMode="Date"></asp:TextBox>
                               
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="Datevalidate();" CssClass="btn btn-primary"
                                        Width="80px" OnClick="btnSearchCreditDebit"/>
                                </div>
                            </div>
                        </div>

                                    
                                <div class="clearfix"></div>
                        <div class="panel-body">
                            <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Opps! No record found..</strong>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdCreditDebitReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" 
                                    BorderStyle="None" PageSize="8" CssClass="table nomargin grid" DataKeyNames="id">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyName" runat="server" Font-Bold="false" Text='<%# Eval("PartyName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Type" HeaderStyle-Width="20%">
                                            <ItemTemplate>                                               
                                                <asp:Label ID="lblType" runat="server" Font-Bold="false" Text='<%# Eval("Type")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Font-Bold="false" Text='<%# Eval("DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Font-Bold="false" Text='<%# Eval("Amount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Font-Bold="false" Text='<%# Eval("Description")%>'></asp:Label>                                                
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="btnCancel" title="Cancel" runat="server" OnClick="btnCancel_Click"
                                                    Visible="false"><i class="fa fa-close"></i></asp:LinkButton>--%>
                                               <%-- <asp:LinkButton ID="btnEdit" title="Edit" runat="server" OnClick="btnEdit"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnUpdate" title="Update" runat="server" OnClick="btnUpdate"
                                                    Visible="false"><i class="fa fa-floppy-o"></i></asp:LinkButton>--%>
                                                <asp:LinkButton ID="btnDelete" title="Delete" runat="server" OnClick="btnDelete"><i class="fa fa-trash-o"></i></asp:LinkButton>
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

            </div>
        </div>

    </div>
</asp:Content>
