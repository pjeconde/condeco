<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoConsultaDetallada.aspx.cs" Inherits="Condeco.ProductoConsultaDetallada" Theme="Condeco" Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
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
                    <div class="col-lg-6 col-md-6 col-sm-6">
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
                                        <asp:Label ID="Label7" runat="server" Text="Id." Visible="false"></asp:Label>
                                        <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="4" Width="150px" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        <asp:Label ID="Label9" runat="server" Text="Producto" SkinID="TituloColor1Grande"></asp:Label>
                                        <%if (TipoProductoLabel.Text != "") {%><asp:Label ID="TipoProductoLabel" runat="server" Visible="false"></asp:Label>
                                        <%}%>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        <asp:Label ID="NombreLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                
                                    </div>
                                </div>
                                <%if (PrecioBaseLabel.Text != ""){%>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        Precio: $ <asp:Label ID="PrecioBaseLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    </div>
                                </div>
                                <%} %>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                        <asp:Label ID="DescripcionLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <%if (ComentarioPrecioBaseLabel.Text != "") {%>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        Comentario: <asp:Label ID="ComentarioPrecioBaseLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                
                                    </div>
                                </div>
                                <%} %>
                                <%if (YouTubeLabel.Text != "")
                                {%>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        YouTube: <asp:Label ID="YouTubeLabel" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    </div>
                                </div>
                                <%} %>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label ID="TituloImagenes" runat="server" Text="Imagenes" SkinID="TituloColor1Grande"></asp:Label>
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
                                        <!-- Carousel -->
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


