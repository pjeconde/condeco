<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Condeco.Pruebas" Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
     <script src="js/jquery.mobile-1.4.5.min.js" type="text/javascript"></script>
     <script>
         $(document).ready(function () {
             $("#myCarousel").swiperight(function () {
                 $("#myCarousel").carousel('prev');
             });
             $("#myCarousel").swipeleft(function () {
                 $("#myCarousel").carousel('next');
             });
         });  
    </script> 
    <section class="bg-primary-white" id="secUsuarioOlvidoId">
        <div class="container-fluid">
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
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="panel panel-default" style="">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                            <!-- Indicators -->
                                            <ol class='carousel-indicators'>
                                                <li data-target='#myCarousel' data-slide-to='0' class='active'></li>
                                                <li data-target='#myCarousel' data-slide-to='1' class=''></li>
                                            </ol>
                                            <!-- Images-->
                                            <div class="carousel-inner">
                                                <div class='item active'>
                                                <img src='ImagenesProducto/12-20151002-105516.jpg' alt='Slide #1'>
                                                </div>
                                                <div class='item'>
                                                <img src='ImagenesProducto/12-20151002-105450.jpg' alt='Slide #2'>
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
    <style type="text/css">
        .carousel-inner img
        {
            margin: auto;
        }
    </style>
</asp:Content>


