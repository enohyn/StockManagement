<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCategoryUI.aspx.cs" Inherits="StockManagementWebApp.UI.UpdateCategoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Update Category | Xoom Shop</title> 
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
                <img src="Design_Component/assets/img/logoxoom.png" class="user-image img-responsive"/>
            </li>
            <li>
                <a href="HomeUI.aspx">
                    <i class="fa fa-home fa-3x"></i> Home
                </a>
            </li>
            <li>
                <a class="active-menu" href="UpdateCategoryUI.aspx">
                    <i class="fa fa-edit fa-3x"></i> Update Category
                </a>
            </li>
           
        </ul>
    </div>
</nav>
<!-- /. NAV SIDE -->
<div id="page-wrapper">
<div id="page-inner">
    <div class="row">
        <div class="col-md-12">
            <h2>Update Category</h2>
        </div>
    </div>
    <!-- /. ROW -->
    <div class="row">
        <div class="col-md-12">
            <!-- Form Elements -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    Please Provide a Unique Category
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <form role="form" runat="server">
                                <div class="form-group">
                                    <label>Update Category Name :</label>
                                    <asp:TextBox ID="updateCategoryNameTextBox" runat="server" class="form-control" placeholder="PLease Enter Update Category Name"></asp:TextBox>
                                </div>
                                <asp:Button ID="updateCategoryButton" runat="server" class="btn btn-primary" Text="Update Category" OnClick="updateCategoryButton_Click"/>
                                <br />
                                <br />
                                <asp:HyperLink NavigateUrl="CategoryUI.aspx" runat="server" class="btn btn-primary">Back</asp:HyperLink>
                                <br />
                                <br />
                                <asp:Label ID="outputLabel" runat="server"></asp:Label>
                                <br/>
                               
                                  
                               
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

