<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Material.aspx.cs" Inherits="RCandJJ.Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function Saveclick() {

            if ($("#ContentPlaceHolder1_txtMaterialName").val() == '') {
                $("#name").addClass("has-error");
            }
            else {
                $("#name").removeClass("has-error");
            }

//            if ($("#ContentPlaceHolder1_txtRate").val() == '') {
//                $("#rate").addClass("has-error");
//            }
//            else {
//                $("#rate").removeClass("has-error");
//            }

            if ($("#ContentPlaceHolder1_txtGST").val() == '') {
                $("#gst").addClass("has-error");
            }
            else {
                $("#gst").removeClass("has-error");
            }
        }

        function SuccessOk() {
            alertify.error('Material added successfully...');
        }

        function UpdateOk() {
            alertify.error('Material updated successfully...');
        }

        function UpdateStockOk() {
            alertify.error('Qty in Stock updated successfully...');
        }

        function UpdateLowQtyOk() {
            alertify.error('Low Qty updated successfully...');
        }

        function Confirm() {
            alertify.confirm('Alert', 'Are you sure want to delete?', function () { __doPostBack("<%=Button2.UniqueID%>", ""); }
                , function () { alertify.error('Cancel') });
        }

        function DeleteOk() {
            alertify.error('Material deleted successfully...');
        }

        function WarningOk() {
            alertify.alert('Warning', 'Material allready exists...!', function () { alertify.success('Ok'); });
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
    <asp:Button ID="Button2" Text="Upload" OnClick="btnDelete" runat="server" Style="display: none;" />
    <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="site.aspx">Add Material</a></li>
            </ol>
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Material</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <p>
                                <br />
                                Please provide your Material name and Material rate.</p>
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">
                                <div class="error">
                                </div>
                                <div id="name" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtMaterialName" runat="server" class="form-control" placeholder="Type your Material name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaterialName"
                                            Display="None" CssClass="error" ErrorMessage="Material name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div id="gst" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlGst" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="rate" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtRate" runat="server" class="form-control" placeholder="Enter material rate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRate"
                                            Display="None" CssClass="error" ErrorMessage="Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Rate."
                                            SetFocusOnError="true" ControlToValidate="txtRate" ValidationExpression="^[0-9][\.\d]*(,\d+)?$"
                                            ForeColor="Red" ValidationGroup="Save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="Div1" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtUnit" runat="server" class="form-control" placeholder="Material Unit"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="Div2" class="form-group col-md-12">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtHsnCode" runat="server" class="form-control" placeholder="HSN Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSave_Click" OnClientClick="Saveclick()" ValidationGroup="Save" />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
                                    <a href="Material.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
                                Material Report</h4>
                                <div class="col-md-4">
                                        <asp:TextBox ID="txtSearchMaterialName" runat="server" class="form-control" placeholder="Material Name"></asp:TextBox>
                                    </div>
                               
                                <div class="col-md-2">                                   
                                    <asp:Button ID="Button3" runat="server" Text="Search" CssClass="btn btn-wide btn-primary btn-quirk mr5"
                                        OnClick="btnSearch_Click"  />                                   
                                </div>
                        </div>
                       
                                    
                                <div class="clearfix"></div>
                        <div class="panel-body">
                            <div id="errorMsg" runat="server" class="alert alert-warning" style="background-color: #d8dce3;
                                color: #505b72;">
                                <strong>Opps! No record found..</strong>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdMaterialReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" OnPageIndexChanging="grdMaterialReport_PageIndexChanging"
                                    BorderStyle="None" PageSize="8" CssClass="table nomargin grid" DataKeyNames="MATERIAL_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterialName" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                                <asp:TextBox ID="txtMaterialName" runat="server" Text='<%# Eval("MATERIAL_NAME")%>'
                                                    Visible="false" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="GST %" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGSTID" runat="server" Font-Bold="false" Visible="false" Text='<%# Eval("GST_ID")%>'></asp:Label>
                                                <asp:Label ID="lblGST" runat="server" Font-Bold="false" Text='<%# Eval("GST")%>'></asp:Label>
                                                <asp:DropDownList ID="ddlGst1" CssClass="form-control" runat="server" Visible="false"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                                <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("RATE")%>' Visible="false"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit" runat="server" Font-Bold="false" Text='<%# Eval("UNIT")%>'></asp:Label>
                                                <asp:TextBox ID="txtUnit" runat="server" Text='<%# Eval("UNIT")%>' Visible="false"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="HSN Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHsnCode" runat="server" Font-Bold="false" Text='<%# Eval("HSN_CODE")%>'></asp:Label>
                                                <asp:TextBox ID="txtHsnCode" runat="server" Text='<%# Eval("HSN_CODE")%>' Visible="false"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                          <%--    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="LOW_QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOW_QTY" runat="server" Font-Bold="false" Text='<%# Eval("LOW_QTY")%>'></asp:Label>
                                                <asp:TextBox ID="txtLOW_QTY" runat="server" Text='<%# Eval("LOW_QTY")%>' Visible="false"
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnCancel" title="Cancel" runat="server" OnClick="btnCancel_Click"
                                                    Visible="false"><i class="fa fa-close"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnEdit" title="Edit" runat="server" OnClick="btnEdit"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnUpdate" title="Update" runat="server" OnClick="btnUpdate"
                                                    Visible="false"><i class="fa fa-floppy-o"></i></asp:LinkButton>
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
                <div class="col-md-12">
                    <div class="panel">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Update Stock Quantity</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                            <div class="table-responsive">
                                <asp:GridView ID="grdStockUpdate" runat="server" Width="100%" AutoGenerateColumns="False"
                                    AllowPaging="true" OnPageIndexChanging="grdUpdateStock_PageIndexChanging" OnRowDataBound="StockRowDatabind"
                                    BorderStyle="None" PageSize="8" CssClass="table nomargin grid" DataKeyNames="MATERIAL_ID">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterialName" runat="server" Font-Bold="false" Text='<%# Eval("MATERIAL_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Font-Bold="false" Text='<%# Eval("RATE")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit" runat="server" Font-Bold="false" Text='<%# Eval("UNIT")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="TOTAL STOCK">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockQty" runat="server" Font-Bold="false" Text='<%# Eval("QTY_IN_STOCK")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="SALES QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesQty" runat="server" Font-Bold="false" Text='<%# Eval("SALES_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="AVAILABLE QTY">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAvailableQty" runat="server" Font-Bold="false" Text='<%# Eval("AVAILABLE_QTY")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="ADD QTY IN STOCK">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAddQty" runat="server" CssClass="form-control" OnTextChanged="txtUpdateStockQty" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="LOW_QTY">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLOW_QTY" runat="server" Text='<%# Eval("LOW_QTY")%>' CssClass="form-control" OnTextChanged="txtUpdatelowQty" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                   </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle CssClass="pagination" />
                                </asp:GridView>
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
            </div>
        </div>
        <!-- contentpanel -->
    </div>
</asp:Content>
