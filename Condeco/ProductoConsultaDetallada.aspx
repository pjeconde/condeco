﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoConsultaDetallada.aspx.cs" Inherits="Condeco.ProductoConsultaDetallada" Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <script src="js/jquery.js"></script>
    <script src="js/jquery.touchSwipe.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            //Enable swiping...
            $(".carousel-inner").swipe({
                //Generic swipe handler for all directions
                swipeLeft: function (event, direction, distance, duration, fingerCount) {
                    $(this).parent().carousel('prev');
                },
                swipeRight: function () {
                    $(this).parent().carousel('next');
                },
                //Default is 75px, set to 0 for demo so any distance triggers swipe
                threshold: 0
            });
        });
    </script>
    <section class="bg-primary-white" id="secUsuarioOlvidoId">
        <div class="container-fluid">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-eye"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloPaginaLabel" runat="server" Text="Detalles del Producto"></asp:Label></h2>
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
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="4" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 text-left" style="">
                                        <h4><asp:Label ID="Label9" runat="server" Text="Producto"></asp:Label>&nbsp;&nbsp;<font style="font-family: Sans-Serif; font-size:small"><b>cod.<%=IdProductoTextBox.Text%></b></font></h4>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 text-right" style="" >
                                        <h4><span class="label label-primary"><span class="fa fa-tag"></span>&nbsp;
                                        <%if (TipoProductoLabel.Text != "") {%><asp:Label ID="TipoProductoLabel" runat="server" Visible="true"></asp:Label><%}%></span></h4>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        <asp:Label ID="NombreLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <%if (PrecioBaseLabel.Text != ""){%>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        Precio: $ <asp:Label ID="PrecioBaseLabel" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <%} %>
                                <%if (ComentarioPrecioBaseLabel.Text != "") {%>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        Comentario: <asp:Label ID="ComentarioPrecioBaseLabel" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <%} %>
                                <br />
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        <asp:Label ID="DescripcionLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <%if (YouTubeLabel.Text != "")
                                {%>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        YouTube: <asp:Label ID="YouTubeLabel" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <%} %>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <h4><asp:Label ID="TituloImagenes" runat="server" Text="Imagenes"></asp:Label></h4>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                            <!-- Indicators -->
                                            <asp:Literal ID="ltlCarouselIndicators" runat="server" />
                                            <!-- Images-->
                                            <div class="carousel-inner">
                                                <asp:Literal ID="ltlCarouselImages" runat="server" />
                                            </div>
                                            <!-- Controls -->
                                            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                                <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                                                    href="#myCarousel" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                                                    </span></a>
                                        </div>
                                    </div>
                                </div>
                                <br />
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


