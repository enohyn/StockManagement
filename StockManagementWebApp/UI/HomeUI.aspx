<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Inherits="StockManagementWebApp.UI.HomeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin|Xoom Shop</title>
     <link rel="apple-touch-icon" href="Design_Component/assets/img/XoomIcon.png">
    <link rel="icon" type="image/png" href="Design_Component/assets/img/XoomIcon.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="Design_Component/assets/img/XoomIcon.png" sizes="16x16" />
	<!-- BOOTSTRAP STYLES-->
    <link href="Design_Component/assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="Design_Component/assets/css/font-awesome.css" rel="stylesheet" />
        <!-- CUSTOM STYLES-->
    <link href="Design_Component/assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
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
                <a class="active-menu" href="HomeUI.aspx">
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
                <a href="StockOutUI.aspx">
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
                <h2>Welcome to The Xoom Shop Admin Section</h2>
                <h5> </h5>
            </div>
        </div>
        <!-- /. ROW -->
        <hr/>
        <div class="row">
            <div class="col-md-12">
                <!-- Form Elements -->
                <div class="panel panel-default">

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <form role="form">
                                        <div class="form-group">
                                            
                                            <h2>Category Setup</h2>
                                             <h4> Initially all category will be saved into the system. 
                                                 Category name must be unique. In this Section, all categories will be shown also. 
                                                 Please note that if you want, (s) you can be able to edit any Category by update Button. </h4>
                                            <h2>Company Setup</h2>
                                            <h4>Using this Section, You will save new company information and also view all companies’ name. 
                                                 Company name will be unique. </h4>
                                           <h2>Item Setup</h2>
                                            <h4>Item name will be save using this Section. 
                                                You will select Category and Company name, then will enter new Item name.
                                                Item name must be unique.</h4>
                                            <h2>Stock In</h2>
                                            <h4>When any items will be arrived, You will count them and enter into the system using this Section.
                                                After Item selection, then enters counted items and saves into the system. </h4>
                                            <h2>Stock Out</h2>
                                            <h4> You will enter quality and press Add button,
                                                items with quantity and company name will be added into the following grid.
                                                After adding several items into the grid, You will press Sell/Damage/Lost button and 
                                                then data will be saved into the database.</h4>

                                        </div>
                                        

                                    </form>
								</div>


											<div class="col-md-6">
                                    
                                    <form role="form">
                                       
                                            <div >
                <img src="Design_Component/assets/img/XoomThemeOne.jpg" style="width: 550px; height: 500px" />
                                                
                                                 </div>
                                            
                                       
                                    </form>
                            </div>
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


</body>
</html>

