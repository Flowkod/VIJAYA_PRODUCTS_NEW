<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PurchaseRegister.aspx.cs" Inherits="INVOICE_DEMO.PurchaseRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function SuccessOk() {
         alertify.error('Client added successfully...');
         window.location = "PurchaseRegister.aspx";
     }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="mainpanel">
        <div class="contentpanel">
            <ol class="breadcrumb breadcrumb-quirk">
                <li><a href="index.aspx"><i class="fa fa-home mr5"></i>Home</a></li>
                <li><a href="PurchaseRegister.aspx">Purchase Register</a></li>
            </ol>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                Add New Purchase details</h4>
                        </div>
                        <div class="panel-body nopaddingtop">
                           
                            <hr style="border-color: #03A9F4;" />
                            <div class="col-md-12">

                                <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                       Invoice Number <span class="text-danger"></span></label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtinvoicenumber" runat="server" class="form-control" placeholder="Invoice Number" 
                                            onchange="Saveclick(this)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtinvoicenumber"
                                            Display="None" CssClass="error" ErrorMessage=" Invoice Number required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-md-2 control-label">
                                        Invoice Date <span class="text-danger"></span> </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtinvoicedate" runat="server" class="form-control" TextMode="Date" placeholder="Invoice Date"
                                            onchange="Saveclick(this)"></asp:TextBox>                                     
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtinvoicedate"
                                            Display="None" CssClass="error" ErrorMessage=" Invoice Date required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="col-sm-2 control-label">
                                     Party Name(Purchase) <span class="text-danger"></span></label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtpartyname" runat="server" class="form-control" placeholder="Party Name(Purchase)"
                                            onchange="Saveclick(this)"></asp:TextBox>                                     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpartyname"
                                            Display="None" CssClass="error" ErrorMessage=" Party Name required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                     <label class="col-sm-2 control-label">
                                    GST No <span class="text-danger"></span></label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtgstno" runat="server" class="form-control" placeholder="GST No"
                                            onchange="Saveclick(this)"></asp:TextBox>                                     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtgstno"
                                            Display="None" CssClass="error" ErrorMessage=" GST No required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                          
                               <%-- <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Place Of Supply  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtplaceofsupply" runat="server"  class="form-control" placeholder="Place Of Supply"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtplaceofsupply"
                                            Display="None" CssClass="error" ErrorMessage="Place Of Supply required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        E Commerce GSTIN  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtecommercegstin" runat="server" class="form-control" placeholder="E Commerce GSTIN" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtecommercegstin"
                                            Display="None" CssClass="error" ErrorMessage="E Commerce GSTIN required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>--%>

                                      <%--  <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                        Category  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtCategory" runat="server"  class="form-control" placeholder="Category"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCategory"
                                            Display="None" CssClass="error" ErrorMessage="Category required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      Commodity  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtcommodity" runat="server" class="form-control" placeholder="Commodity" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcommodity"
                                            Display="None" CssClass="error" ErrorMessage="Commodity required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>--%>


                                   <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                       Unit  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtunit" runat="server"  class="form-control" placeholder="Unit"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtunit"
                                            Display="None" CssClass="error" ErrorMessage="Unit required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      Quantity  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtquantity" runat="server" class="form-control" placeholder="Quantity" TextMode="Number" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtquantity"
                                            Display="None" CssClass="error" ErrorMessage="Quantity required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                 <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                     HSN/SAC Of Supply  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtsupply" runat="server"  class="form-control" TextMode="Number" placeholder="HSN/SAC Of Supply"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtsupply"
                                            Display="None" CssClass="error" ErrorMessage="HSN/SAC Of Supply required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      Invoice Value  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtinvoicevalue" runat="server" class="form-control" placeholder="Invoice Value" TextMode="Number" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtinvoicevalue"
                                            Display="None" CssClass="error" ErrorMessage="Invoice Value required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                   <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                    Net Taxable Value  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtnettaxablevalue" runat="server"  class="form-control" TextMode="Number" placeholder="Net Taxable Value"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtnettaxablevalue"
                                            Display="None" CssClass="error" ErrorMessage=" Net Taxable Value required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      IGST Rate  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtigstrate" runat="server" class="form-control" placeholder="IGST Rate" TextMode="Number" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtigstrate"
                                            Display="None" CssClass="error" ErrorMessage="IGST Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                      <div class="form-group col-md-12">
                                   <%-- <label class="col-md-2 control-label">
                                    IGST Amount  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtigstamount" runat="server"  class="form-control" TextMode="Number" placeholder="IGST Amount"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtigstamount"
                                            Display="None" CssClass="error" ErrorMessage=" IGST Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>--%>
                                    <label class="col-md-2 control-label">
                                      CGST Rate  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtcgstrate" runat="server" class="form-control" TextMode="Number" placeholder="CGST Rate" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtcgstrate"
                                            Display="None" CssClass="error" ErrorMessage="CGST Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                    <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                     CGST Amount  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtcgstamount" runat="server"  class="form-control" TextMode="Number" placeholder="CGST Amount"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtcgstamount"
                                            Display="None" CssClass="error" ErrorMessage=" CGST Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      SGST Rate  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtsgstrate" runat="server" class="form-control" TextMode="Number" placeholder="SGST Rate" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtsgstrate"
                                            Display="None" CssClass="error" ErrorMessage="SGST Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>



                                 <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                     SGST Amount  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4"> 
                                        <asp:TextBox ID="txtsgstamount" runat="server"  class="form-control" TextMode="Number" placeholder=" SGST Amount "
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtsgstamount"
                                            Display="None" CssClass="error" ErrorMessage=" SGST Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      CESS Rate  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="TXTcessrate" runat="server" class="form-control" TextMode="Number" placeholder=" CESS Rate " onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TXTcessrate"
                                            Display="None" CssClass="error" ErrorMessage="CESS Rate required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                
                                 <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                     CESS Amount  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtcessamount" runat="server"  class="form-control" TextMode="Number" placeholder=" CESS Amount "
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtcessamount"
                                            Display="None" CssClass="error" ErrorMessage=" CESS Amount required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-md-2 control-label">
                                      Rounded Off  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtroundedoff" runat="server" class="form-control" TextMode="Number" placeholder=" Rounded Off" onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtroundedoff"
                                            Display="None" CssClass="error" ErrorMessage="Rounded Off required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                 
                                 <div class="form-group col-md-12">
                                    <label class="col-md-2 control-label">
                                     Total Invoice Value  <span class="text-danger"></span>
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txttotalinvoicevalue" runat="server"  class="form-control"  placeholder="Total Invoice Value"
                                        onchange="Saveclick(this)"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txttotalinvoicevalue"
                                            Display="None" CssClass="error" ErrorMessage="  Total Invoice Value required..." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>                                   
                                </div>
                                <div class="clearfix">
                                </div>                                
                                <div class="col-md-12">
                                    <hr style="border-color: #03A9F4;" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-wide btn-primary btn-quirk mr5" OnClick="btnSubmit_Click" />
                                    <a href="PurchaseRegister.aspx" class="btn btn-wide btn-default btn-quirk">Reset</a>
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
