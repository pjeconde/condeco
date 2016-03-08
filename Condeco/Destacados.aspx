<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Destacados.aspx.cs" Inherits="Condeco.Destacados" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secNovedades">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p>
                    <span class="fa fa-2x fa-diamond wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading"> Destacados</h2>
                    <hr>
                </div>
            </div>

            <!-- Portfolio Item Heading -->
            <div class="row">
                <div class="col-lg-12 text-left">
                    <h3 class="page-header">Cuadro
                    <small>realizado en madera</small>
                    </h3>
                </div>
            </div>
            <!-- /.row -->

            <!-- Portfolio Item Row -->
            <div class="row text-left">
                <div class="col-md-8">
                    <a href="Imagenes/Destacados/Cuadro/IMG_20160220_115012212.jpg" target="_blank">
                        <img class="img-responsive" src="Imagenes/Destacados/Cuadro/IMG_20160220_115012212.jpg" alt="" title="Código: C100">
                    </a>
                </div>

                <div class="col-md-4">
                    <h4>Descripción</h4>
                    <p>
                    Cuadro realizado con sobrantes de maderas, aprovechando las diversas formas y texturas. Siempre tratando de utilizar las maderas recicladas con el desgaste y su color natural. Además, la obra tiene unos insertos de metal. 
                    </p>
                </div>
            </div>
            <!-- /.row -->
            <style>
            [class*="col-"] {
                margin-bottom: 20px;
            }
            </style>
            <!-- Related Projects Row -->
            <div class="row">
                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Cuadro/IMG_20160220_115005735.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Cuadro/IMG_20160220_115005735.jpg" alt="" title="Código: C101">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Cuadro/IMG_20160220_115001725.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Cuadro/IMG_20160220_115001725.jpg" alt="" title="Código: C102">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Cuadro/IMG_20160220_114954685.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Cuadro/IMG_20160220_114954685.jpg" alt="" title="Código: C103">
                    </a>
                </div>
                
                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Cuadro/IMG_20160220_114949815.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Cuadro/IMG_20160220_114949815.jpg" alt="" title="Código: C104">
                    </a>
                </div>
            </div>
            <p>
                <br />
            </p>

            <!-- Portfolio Item Heading -->
            <div class="row">
                <div class="col-lg-12 text-left">
                    <h3 class="page-header">Pez
                    <small>realizado en madera</small>
                    </h3>
                </div>
            </div>
            <!-- /.row -->

            <!-- Portfolio Item Row -->
            <div class="row text-left">
                <div class="col-md-8">
                    <a href="Imagenes/Destacados/Peces/IMG_20160301_115240293.jpg" target="_blank">
                        <img class="img-responsive" src="Imagenes/Destacados/Peces/IMG_20160301_115240293.jpg" alt="" title="Código: C100">
                    </a>
                </div>

                <div class="col-md-4">
                    <h4>Descripción</h4>
                    <p>
                    Pez realizado en pinotea y cedro, pintado con laca poliuretánica transparente satinada, para resaltar el color natural de la madera. La obra tiene detalles en metal microperforado. 
                    </p>
                </div>
            </div>
            
            <!-- Related Projects Row -->
            <div class="row">
                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Peces/IMG_20160301_125448239.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Peces/IMG_20160301_125448239.jpg" alt="" title="Código: C101">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Peces/IMG_20160301_115245116.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Peces/IMG_20160301_115245116.jpg" alt="" title="Código: C102">
                    </a>
                </div>

                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Peces/IMG_20160301_115248230.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Peces/IMG_20160301_115248230.jpg" alt="" title="Código: C103">
                    </a>
                </div>
                
                <div class="col-sm-3 col-xs-6">
                    <a href="Imagenes/Destacados/Peces/IMG_20160301_125454353.jpg" target="_blank">
                        <img class="img-responsive portfolio-item" src="Imagenes/Destacados/Peces/IMG_20160301_125454353.jpg" alt="" title="Código: C104">
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
