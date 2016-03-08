<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Novedades.aspx.cs" Inherits="Condeco.Novedades" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secNovedades">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p>
                    <span class="fa fa-2x fa-magic wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading"> Novedades</h2>
                    <hr>
                </div>
            </div>

            <!-- Portfolio Item Heading -->
            <div class="row">
                <div class="col-lg-12 text-left">
                    <h3 class="page-header">Cuadros
                    <small>realizados en madera</small>
                    </h3>
                </div>
            </div>
            <!-- /.row -->

            <!-- Portfolio Item Row -->
            <div class="row text-left">
                <div class="col-md-8">
                    <a href="Imagenes/Novedades/IMG_20151214_134016812.jpg" target="_blank">
                        <img class="img-responsive" src="Imagenes/Novedades/IMG_20151214_134016812.jpg" alt="" title="Código: C100">
                    </a>
                </div>

                <div class="col-md-4">
                    <h4>Descripción</h4>
                    <p>Estamos comenzando el desarrollo de cuadros a partir de sobrantes de maderas, aprovechando las diversas formas y texturas. En cuanto al color, agregamos solo lo necesario para resaltar la obra, pero siempre tratamos de aprovechar las maderas recicladas con el desgaste su natural.<br /> 
                    En una segunda etapa, iremos agregando otros objetos principalmente de metal. También utilizaremos partes de herramientas e insumos que se encuentran en desuso. 
                    </p>
                    <h4>Detalles</h4>
                    <ul>
                        <li>Relieves</li>
                        <li>Texturas</li>
                        <li>Colores</li>
                        <li>Formas</li>
                    </ul>
                </div>
            </div>
            <!-- /.row -->
            <style>
            [class*="col-"] {
                margin-bottom: 25px;
            }
            </style>
            <!-- Related Projects Row -->
            <div class="row">
                <div class="col-lg-12 text-left">
                    <h4 class="page-header">Trabajos realizados</h4>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134100862.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134100862.jpg" alt="" title="Código: C101">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134139107.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134139107.jpg" alt="" title="Código: C102">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134304725.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134304725.jpg" alt="" title="Código: C103">
                    </a>
                </div>
                
                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134406475.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134406475.jpg" alt="" title="Código: C104">
                    </a>
                </div>

                 <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134442487.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134442487.jpg" alt="" title="Código: C105">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_134902505.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_134902505.jpg" alt="" title="Código: C106">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_135002576.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_135002576.jpg" alt="" title="Código: C107">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Novedades/IMG_20151214_135024941.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Novedades/IMG_20151214_135024941.jpg"  alt="" title="Código: C108">
                    </a>
                </div>
            </div>
            <!-- /.row -->
            
            <!-- Footer -->
            <footer>
                <div class="row">
                    <div class="col-lg-12">
                        <br />
                        <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
                    </div>
                </div>
                <!-- /.row -->
            </footer>
        </div>
    </section>
</asp:Content>
