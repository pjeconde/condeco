<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebasSM.aspx.cs" Inherits="Condeco.PruebasSM" Theme="Condeco" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<meta name="description" content="Decoración en todo tipo de madera maciza, principalmente pinotea, cedro, incienso, jequitiba. Tratamos de usar materiales reciclados para cuidar el medio ambiente. También utilizamos en nuestros trabajos metal microperforado, desplegado, hierro y chapa." />
	<meta name="author" content="Conde Pablo" />
    <link href='https://fonts.googleapis.com/css?family=La+Belle+Aurore' rel='stylesheet' type='text/css'>
    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />    
    <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css" type="text/css">
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="css/creative.css" rel="stylesheet" type="text/css" />

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <script src="js/jquery.touchSwipe.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            //Enable swiping...
            $(".carousel-inner").swipe({
                //Generic swipe handler for all directions
                swipeRight: function (event, direction, distance, duration, fingerCount) {
                    $(this).parent().carousel('prev');
                },
                swipeLeft: function () {
                    $(this).parent().carousel('next');
                },
                //Default is 75px, set to 0 for demo so any distance triggers swipe
                threshold: 0
            });
        });
    </script>

    <!-- Plugin JavaScript -->
    <script src="js/jquery.easing.min.js"></script>
    <script src="js/jquery.fittext.js"></script>
    <script src="js/wow.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/creative.js"></script>
                                    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <section class="bg-primary-white" id="secUsuarioOlvidoId">
        <div class="container-fluid text-center">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-eye"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloPaginaLabel" runat="server" Text="Pruebas"></asp:Label></h2>
                    <hr>
                    <p>
                        <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                    </p>


                   
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <p></p>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="panel panel-default" style="">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="myCarousel" class="carousel slide">
                                            <!-- Indicators -->
                                            <ol class='carousel-indicators'>
                                                <li data-target='#myCarousel' data-slide-to='0' class='active'></li>
                                                <li data-target='#myCarousel' data-slide-to='1' class=''></li>
                                            </ol>
                                            <!-- Images-->
                                            <div class="carousel-inner">
                                                <div class='item active'>
                                                <img src='ImagenesProducto/12-20151002-105516.jpg' alt='Slide #1' style="margin: 0 auto">
                                                </div>
                                                <div class='item'>
                                                <img src='ImagenesProducto/12-20151002-105450.jpg' alt='Slide #2' style="margin: 0 auto">
                                                </div>
                                            </div>
                                            <!-- Controls -->
                                            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                                <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                                                    href="#myCarousel" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                                                    </span></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="504" Text="Salir" PostBackUrl="~/Default.aspx" class="btn btn-info" />
                                        <input type="button" value="Volver atrás" name="Volver" onclick="history.back()" class="btn btn-info" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <p>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>    
    </div>
    </form>
</body>
</html>
