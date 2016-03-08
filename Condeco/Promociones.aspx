<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Promociones.aspx.cs" Inherits="Condeco.Promociones" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secPromociones">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <p>
                        <span class="fa fa-2x fa-usd wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading">
                        Promociones</h2>
                        <span class="fa fa-1-5x fa-binoculars"></span>&nbsp;Busque la promoción que mas se ajuste a su necesidades.<br /><br />   
                </div>
            </div>
            <div class="well well-sm">
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#home">Decoración</a></li>
                    <li><a data-toggle="tab" href="#menu1">Marco con lámina</a></li>
                    <li><a data-toggle="tab" href="#menu2">Descuento 2da Unidad</a></li>
                </ul>
                <div class="tab-content text-left">
                    <div id="home" class="tab-pane fade in active">
                        <h3>Pez rústico</h3>
                        <p>
                            Objeto de decoración, listo para colgar.
                        </p>
                        <div class="row">
                            <div class="col-sm-6">
                                <a href="Imagenes/Promociones/IMG_20160220_114852433.jpg" target="_blank">
                                    <img class="img-responsive portfolio-item" src="Imagenes/Promociones/IMG_20160220_114852433.jpg" alt="" title="Código: P102">
                                </a>
                                Medidas: 75 cm de largo aproximadamente.
                                <br />  
                            </div>
                                <div class="col-sm-6">
                                <a href="Imagenes/Promociones/IMG_20160220_114734992.jpg" target="_blank">
                                    <img class="img-responsive portfolio-item" src="Imagenes/Promociones/IMG_20160220_114734992.jpg" alt="" title="Código: P101">
                                </a>
                                Medidas: 50 cm de largo aproximadamente.
                                <br />  
                            </div>
                        </div>                  
                        <p>
                            <br />
                            Principales materiales utilizados:
                            <ul>
                                <li>Madera envejecida por el paso del tiempo.</li>
                                <li>Metal microperforado de 3mm.</li>
                                <li>Chapa color verde ingles.</li>
                            </ul>
                        </p>
                        <div class="success">
                            <span class="fa fa-1-5x fa-check" aria-hidden="true"></span>&nbsp;Precio pago efectivo: <b>$ 900</b>  (<del>antes $ 1200</del>)
                        </div>
                    </div>
                    <div id="menu1" class="tab-pane fade">
                        <h3>Marco de pinotea con lámina.</h3>
                        <p>
                        Listo para colgar.
                        </p>
                        <div class="row">
                            <div class="col-sm-6">
                                <a href="Imagenes/Promociones/IMG_20160302_173734345.jpg" target="_blank">
                                    <img class="img-responsive portfolio-item" src="Imagenes/Promociones/IMG_20160302_173734345.jpg"
                                        alt="" title="Código: MLA101" />
                                </a>
                            </div>
                            <div class="col-sm-6">
                                <a href="Imagenes/Promociones/IMG_20160302_173743634.jpg" target="_blank">
                                    <img class="img-responsive portfolio-item" src="Imagenes/Promociones/IMG_20160302_173743634.jpg"
                                        alt="" title="Código: MLA101" />
                                </a>
                            </div>
                        </div>
                        <p>Medidas: 53 x 38 cm.</p>
                        <p>
                        Materiales utilizados:
                        </p>
                        <ul>
                            <li>Madera de pinotea recuperada, pintado con laca poliuretánica transparente satinada.</li>
                            <li>Lamina de 50 x 35 cm. Este marco permite cambiar la lámina cuando usted lo desee y las mismas se pueden comprar en el Puerto de Frutos (TIGRE).</li>
                        </ul>
                        <div class="success">
                            <span class="fa fa-1-5x fa-check" aria-hidden="true"></span>&nbsp;Precio pago efectivo: <b>$ 500</b>  (precio de lista $ 560)
                        </div>
                    </div>
                    <div id="menu2" class="tab-pane fade">
                        <p>
                            <h3>Descuento del 20 % en la segunda unidad.</h3>
                        </p>
                        <p>
                            <span class="fa fa-1-5x fa-hand-o-right"></span>&nbsp; Comprando dos productos similares obtiene un descuento del 20% en la segunda unidad.
                        </p>
                        <p>
                            <i>No combinable con otras promociones.</i>
                        </p>
                    </div>
                </div>
            </div>
            <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
        </div>
    </section>
</asp:Content>
