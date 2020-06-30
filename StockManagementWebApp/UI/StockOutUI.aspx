<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Stock Out | Xoom Shop</title> 
    
    <link rel="apple-touch-icon" href="Design_Component/assets/img/XoomIcon.png">
    <link rel="icon" type="image/png" href="Design_Component/assets/img/XoomIcon.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="Design_Component/assets/img/XoomIcon.png" sizes="16x16" />
	<!-- BOOTSTRAP STYLES-->
    <link href="Design_Component/assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="Design_Component/assets/css/font-awesome.css" rel="stylesheet" />
        <!-- CUSTOM STYLES-->
    <link href="Design_Component/assets/css/custom.css" rel="stylesheet" />
    <link href="Design_Component/assets/css/sweetalert.css" rel="stylesheet" />
 <script src="Design_Component/assets/css/sweetalert.min.js"></script>

    
      <script>
          function QuanityVaidationMsg() {
              swal("Oops", "Please Input Positive Value in Stock Out Quanity!", "error");
          }
          function VaidationMsg(){
              swal("Oops", "Insufficient Stock!", "error");
          }
          function ErrorMsg() {
              swal("Oops", "Please Add Items into Card!", "error");

          }
          function emptyFieldMsg() {
              swal("Oops", "Please Fill All Field!", "error");

          }

          function SuccessMsg(){
              swal("Successfully Sold!", "Thank You", "success");
          }
          function LostMsg() {
              swal("Lost Items are Saved!", "Thank You", "success");
          }
          function DamageMsg() {
              swal("Damage Items are Saved!", "Thank You", "success");
          }
      </script>

     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

</head>
<body>
<div id="wrapper"/>
<nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="HomeUI.aspx">Xoom Shop</a>
    </div>
   <div style="color: white;padding: 15px 50px 5px 50px; float: right;
        font-size: 16px;">
        <asp:HyperLink NavigateUrl="AdminProfileUI.aspx" ID="userEmailLabel" ForeColor="white" runat="server" Text=""></asp:HyperLink>  &nbsp;
        <asp:HyperLink NavigateUrl="IndexUI.aspx" runat="server" class="btn btn-danger square-btn-adjust" >Logout</asp:HyperLink>
    </div>
</nav>
<!-- /. NAV TOP -->
<nav class="navbar-default navbar-side" role="navigation">
    <div class="sidebar-collapse">
        <ul class="nav" id="main-menu">
            <li class="text-center">
                <img src="Design_Component/assets/img/logoXoom.png" class="user-image img-responsive"/>
            </li>
            <li>
                <a href="HomeUI.aspx">
                    <i class="fa fa-home fa-3x"></i> Home
                </a>
            </li>
            <li>
                <a href="#">
                    <i class="fa fa-sitemap fa-3x"></i> Setup
                    <span class="fa arrow"></span>
                </a>
                <ul class="nav nav-second-level">
                    <li>
                        <a href="CategoryUI.aspx">
                            <i class="fa fa-plus-square fa-3x"></i>Setup Category
                        </a>
                    </li>
                    <li>
                        <a href="CompanyUI.aspx">
                            <i class="glyphicon glyphicon-plus fa-3x"></i> Setup Company
                        </a>
                    </li>
                    <li >
                        <a href="ItemUI.aspx">
                            <i class="glyphicon glyphicon-plus-sign fa-3x"></i> Setup Item
                        </a>
                    </li>
                </ul>
            </li>
            <li >
                <a href="StockInUI.aspx">
                    <i class="fa fa-truck fa-3x"></i> Stock In
                </a>
            </li>
            <li >
                <a  class="active-menu" href="StockOutUI.aspx">
                    <i class="	fa fa-shopping-cart fa-3x"></i> Stock Out
                </a>
            </li>
            <li >
                <a href="SearchAndViewItemUI.aspx">
                    <i class="	fa fa-search fa-3x"></i> Search & View
                </a>
            </li>
            <li >
                <a href="ViewSalesUI.aspx">
                    <i class="fa fa-file fa-3x"></i> Report
                </a>
            </li>
            <li>
                <a href="#">
                    <i class="fa fa-dashboard fa-3x"></i> Dashboard                    
                    <span class="fa arrow"></span>
                </a>
                <ul class="nav nav-second-level">
                    <li>
                        <a href="AdminProfileUI.aspx">
                            <i class="fa fa-plus-square fa-3x"></i>Profile
                        </a>
                    </li>
                    <li>
                        <a href="AdminSignUpUI.aspx">
                            <i class="glyphicon glyphicon-plus fa-3x"></i> Admin Sign Up
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</nav>
<!-- /. NAV SIDE -->
<div id="page-wrapper">
<div id="page-inner">
    <div class="row">
        <div class="col-md-12">
            <h2>Stock Out</h2>
        </div>
    </div>
    <!-- /. ROW -->
    <div class="row">
        <div class="col-md-12">
            <!-- Form Elements -->
            <div class="panel panel-default">
                
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <form role="form" runat="server">
                                <div class="form-group">
                                     <asp:Label ID="Label3" runat="server"  Text="Company Name :"></asp:Label> 
                                    <asp:DropDownList ID="companyDropDownList" class="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                     <asp:Label ID="Label4" runat="server" Text="Item Name :"></asp:Label> 
                                    <asp:DropDownList ID="itemNameDropDownList" class="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="itemNameDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                      <asp:Label ID="Label1" runat="server" Text="Reorder Level :"></asp:Label> 
                                     <asp:TextBox ID="recorderLevelTextBox" runat="server" Enabled="False" Cssclass="form-control" placeholder="<view>"></asp:TextBox>
                                     <asp:Label ID="Label2" runat="server" Text="Available Quantity :"></asp:Label> 
                                     <asp:TextBox ID="availableQuantityTextBox" runat="server" Enabled="False" Cssclass="form-control" placeholder="<view>"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity :"></asp:Label> 
                                     <asp:TextBox ID="stockOutQuantityTextBox" runat="server" class="form-control" placeholder="<view>"></asp:TextBox>
                                    
       
                                     </div>
                                      <asp:Button ID="addButton" runat="server" class="btn btn-primary" Text="Add" OnClick="addButton_Click"/>
                                         <br/>
                                        <br/>
                                        <asp:Label ID="outputLabel" runat="server" Text=""></asp:Label>
                                        <br/>
                                        <div class="col-md-6">
                                    <br/> 
                                          <asp:GridView ID="allItemGridView"  runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="604px" GridLines="Vertical" ForeColor="Black">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Serial">
                                                        <ItemTemplate>
                                                            <asp:Label Height="35px" Width="100px" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<% #Eval("ItemId") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Name">
                                                        <ItemTemplate>
                                                            <asp:Label Height="35px" Width="120px"  runat="server" Text='<% #Eval("ItemName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Company Name">
                                                        <ItemTemplate>
                                                            <asp:Label Height="35px" Width="120px"  runat="server" Text='<% #Eval("CompanyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label Height="35px" Width="120px"  runat="server" Text='<% #Eval("Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC"/>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"/>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"/>
                                                <SortedAscendingCellStyle BackColor="#F1F1F1"/>
                                                <SortedAscendingHeaderStyle BackColor="#808080"/>
                                                <SortedDescendingCellStyle BackColor="#CAC9C9"/>
                                                <SortedDescendingHeaderStyle BackColor="#383838"/>
                                            </asp:GridView>
                                            <br/>
                                      <asp:Button ID="sellButton" runat="server" class="btn btn-primary" Text="SELL" BorderColor="#000066" Font-Bold="True" ForeColor="#000066" OnClick="sellButton_Click"/>
                                      <asp:Button ID="damageButton" runat="server" class="btn btn-primary" Text="Damage" BorderColor="Maroon" Font-Bold="True" ForeColor="Maroon" OnClick="damageButton_Click" />
                                      <asp:Button ID="lostButton" runat="server" class="btn btn-primary" Text="Lost" BorderColor="Red" Font-Bold="True" ForeColor="#660033" OnClick="lostButton_Click" />




                                </div>
                                  
                               
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /. PAGE INNER -->
    </div>
    <!-- /. PAGE WRAPPER -->
</div>
<!-- /. WRAPPER -->
<!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
<!-- JQUERY SCRIPTS -->
<script src="Design_Component/assets/js/jquery-1.10.2.js"></script>
<!-- BOOTSTRAP SCRIPTS -->
<script src="Design_Component/assets/js/bootstrap.min.js"></script>
<!-- METISMENU SCRIPTS -->
<script src="Design_Component/assets/js/jquery.metisMenu.js"></script>
<!-- CUSTOM SCRIPTS -->
<script src="Design_Component/assets/js/custom.js"></script>
  
</div>


</body>
</html>

