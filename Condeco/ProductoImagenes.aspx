<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoImagenes.aspx.cs" Inherits="Condeco.ProductoImagenes" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioLogin">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-image"></span>
                    </p>
                    <h2 class="section-heading"> <asp:Label ID="TituloPaginaLabel" runat="server" Text="Imagenes del Producto"></asp:Label></h2>
                    <hr>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <p></p>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p>
                                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccionar una imagen" Width="100%" TabIndex="1" />
                                <asp:Button ID="SubirImagenButton" runat="server" TabIndex="2" Text="Subir la imagen seleccionada" Width="100%" OnClick="SubirImagenButton_Click" CssClass="btn btn-info" />
                            </p>
                            <p>
                                <asp:Label ID="Label4" runat="server" Text="(tipo de archivos: jpg, jpeg, png o gif)"></asp:Label>
                                <asp:Label ID="MaximoPermitidoLabel" runat="server" Text="Maximum size 2Mb."></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="VistaPreviaLabel" runat="server" Text="Vista Previa"></asp:Label>
                                <asp:Image ID="ImageParaAgregar" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="3" Text="Eliminar" OnClick="BorrarImagenButton_Click" CssClass="btn btn-info" />
                            <br />
                            </p>

                            <p>
                            <asp:Button ID="AgregarPortada" runat="server" TabIndex="3" Text="Agregar foto principal" ToolTip="" Width="100%"
                                OnClick="AgregarPortadaImagenButton_Click"  CssClass="btn btn-info" />
                            </p>
                            <p>
                                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="PortadaLabel" runat="server" Text="Foto Principal"></asp:Label>
                                <asp:Image ID="ImagePortada" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                <asp:Button ID="BorrarPortadaButton" runat="server" TabIndex="3" Text="Eliminar" Width="92px" OnClick="BorrarPortadaButton_Click" CssClass="btn btn-info" />
                            </p>
                            <p>
                                <asp:Button ID="AgregarButton" runat="server" TabIndex="3" Text="Agregar foto al catálogo" CssClass="btn btn-info" 
                                ToolTip="" Width="100%" OnClick="AgregarImagenButton_Click" />
                            </p>
                            <p>
                                <asp:Label ID="TituloImagenes" runat="server" Text=""></asp:Label>
                            </p>
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
                            <p>
                                Imagen a eliminar del catálogo: <asp:DropDownList ID="EliminarImagenDropDownList" runat="server" Width="100%">
                                </asp:DropDownList>
                            <p/>
                            <p>
                                <asp:Button ID="EliminarImagenButton" runat="server" TabIndex="3" Text="Eliminar" CssClass="btn btn-info" 
                                OnClick="EliminarImagenButton_Click" />
                            </p>
                            <p>
                                <asp:Button ID="SalirButton" runat="server" Text="Salir" TabIndex="4" PostBackUrl="~/Default.aspx" CssClass="btn btn-info" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <p></p>
                </div>
            </div>
        </div>
    </section>
    </b>
</asp:Content>
