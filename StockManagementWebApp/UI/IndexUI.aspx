﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementWebApp.UI.IndexUI" %>

<!DOCTYPE html>

<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang=""> <!--<![endif]-->
<head>
    <meta charset="utf-8">
    <!--<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Xoom Shop</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="apple-touch-icon" href="#">
    <link rel="icon" type="image/png" href="Design_Component/assets/img/xoomIcon.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="Design_Component/assets/img/xoomIcon.png" sizes="16x16" />
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/normalize.min.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/bootstrap.min.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/jquery.fancybox.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/flexslider.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/styles.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/queries.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/css/etline-font.css">
    <link rel="stylesheet" href="Design_Component/IndexTheme/bower_components/animate.css/animate.min.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
    <script src="Design_Component/IndexTheme/js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
</head>
<body id="top">
    <!--[if lt IE 8]>
    <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
    <![endif]-->
    <section class="hero">
        <section class="navigation">
            <header>
                <div class="header-content">
                    <div class="logo"><a href="IndexUI.aspx"><img src="Design_Component/IndexTheme/img/proLogo.png" alt="Xoom Shop logo"></a></div>
                    <div class="header-nav">
                        <nav>
                            <ul class="primary-nav">
							 <li><a href="#service">Service</a></li>
							<li><a href="#blog">Blog</a></li>
                                <li><a href="#team">Developers</a></li>
                               
                                
                                <li><a href="#download">Contact</a></li>
                            </ul>
                            <ul class="member-actions">
                                
                                <li><a href="LoginUI.aspx" class="btn-white btn-small">Login</a></li>
                            </ul>
                        </nav>
                    </div>
                    <div class="navicon">
                        <a class="nav-toggle" href="#"><span></span></a>
                    </div>
                </div>
            </header>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="hero-content text-center">
                        <h1>Welcome! To The Xoom Shop</h1>
                        <p class="intro">Can Think Us For Shopping</p>
                        <a href="#" class="btn btn-fill btn-large btn-margin-right">Read More</a> <a href="#" class="btn btn-accent btn-large">Contact Us</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="down-arrow floating-arrow"><a href="#"><i class="fa fa-angle-down"></i></a></div>
    </section>
    <section class="intro section-padding" id="service">
        <div class="container">
            <div class="row">
                
                <div class="col-md-4 intro-feature">
                    <div class="intro-icon">
                        <span data-icon="&#xe030;" class="icon"></span>
                    </div>
                    <div class="intro-content">
                        <h5>Super Shop</h5>
                        <p>Its a Super Shop.You are invited to visit Xoom Shop</p>
                    </div>
                </div>
                
            </div>
        </div>
    </section>
    
    <section class="hero-strip section-padding" id="team">
        <div class="container">
            <div class="col-md-12 text-center">
                <h2> <b>
                We are Team WideXoom                        
                    </b>
                </h2>
                <p>We are Leading For Software Solution and Web Learning.</p>
                <a href="#" class="btn btn-ghost btn-accent btn-large">Read More!</a>
                <div class="logo-placeholder floating-logo"><img src="Design_Component/IndexTheme/img/WideXoomLogo.jpg"/>"></div>
            </div>
        </div>
    </section>
    
    
   
    <section class="to-top">
        <div class="container">
            <div class="row">
                <div class="to-top-wrap">
                    <a href="#top" class="top"><i class="fa fa-angle-up"></i></a>
                </div>
            </div>
        </div>
    </section>
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-7">
                    <div class="footer-links">
                        <ul class="footer-group">
                            <li><a href="#">Service</a></li>
							 <li><a href="#">Portfolio</a></li>
                            <li><a href="#">Pricing</a></li>
                            <li><a href="#">Contact</a></li>
                           
                        </ul>
                        <p>Copyright © 2018 <a href="#">Xoom Shop</a><br>
                         </div>
                </div>
                <div class="social-share">
                    <p>Share Xoom Shop With Your Friends</p>
                    <a href="#" class="twitter-share"><i class="fa fa-twitter"></i></a> <a href="#" class="facebook-share"><i class="fa fa-facebook"></i></a>
                </div>
            </div>
        </div>
    </footer>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="Design_Coponent/IndexTheme/js/vendor/jquery-1.11.2.min.js"><\/script>')</script>
    <script src="Design_Component/IndexTheme/bower_components/retina.js/dist/retina.js"></script>
    <script src="Design_Component/IndexTheme/js/jquery.fancybox.pack.js"></script>
    <script src="Design_Component/IndexTheme/js/vendor/bootstrap.min.js"></script>
    <script src="Design_Component/IndexTheme/js/scripts.js"></script>
    <script src="Design_Component/IndexTheme/js/jquery.flexslider-min.js"></script>
    <script src="Design_Component/IndexTheme/bower_components/classie/classie.js"></script>
    <script src="Design_Component/IndexTheme/bower_components/jquery-waypoints/lib/jquery.waypoints.min.js"></script>
    <!-- Google Analytics: change UA-XXXXX-X to be your site's ID. -->
    <script>
        (function (b, o, i, l, e, r) {
            b.GoogleAnalyticsObject = l; b[l] || (b[l] =
            function () { (b[l].q = b[l].q || []).push(arguments) }); b[l].l = +new Date;
            e = o.createElement(i); r = o.getElementsByTagName(i)[0];
            e.src = '//www.google-analytics.com/analytics.js';
            r.parentNode.insertBefore(e, r)
        }(window, document, 'script', 'ga'));
        ga('create', 'UA-XXXXX-X', 'auto'); ga('send', 'pageview');
    </script>
</body>
</html>
