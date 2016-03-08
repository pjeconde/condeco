<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Maderas.aspx.cs" Inherits="Condeco.Maderas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secMaderas">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <p>
                    <span class="fa fa-2x fa-tree wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading"> Maderas</h2>
                    <hr>
                </div>
            </div>
        </div>

        <div class="container">

            <div class="row">
                <div class="col-lg-12 text-left">
                    <h3>Características <small>Principales usos</small></h3>
                    <hr class="HRnormal" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-7">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x300" alt="">
                    </a>
                </div>
                <div class="col-md-5 text-left">
                    <h4><b>Cedro</b></h4>
                    <p>
                    Es una madera de color marrón rosado a rojo claro con la albura más clara. Tiene un olor muy característico y es aclamado por tu resistencia al deterioro.
                    <br /><br />
                    Principal utilización: Muebles y ebanistería fina de interior y exterior. Escultura. Revestimientos, molduras, puertas y ventanas. Chapas decorativas y tablero contrachapado.
                    </p>
                    <a class="btn btn-primary" href="#">Ver proyecto <span class="glyphicon glyphicon-chevron-right"></span></a>
                </div>
            </div>
            <hr class="HRnormal" />

            <div class="row">
                <div class="col-md-7">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x300" alt="">
                    </a>
                </div>
                <div class="col-md-5 text-left">
                    <h4><b>Jequitibá o Yequitiba</b></h4>
                    <p>Su centro es generalmente rosado castaño o beige rosado, además, beige rosado oscuro, eventualmente con sombras morrones.
                    <br /><br />
                    Su olor es imperceptibles. Es una madera liviana y suave de cortar. En condiciones favorables la Jequitibá se considera moderadamente resistente. Por ser liviana, de color agradable, fácil de trabajar y de propiedades mecánicas medianas a bajas, puede ser usada para contrapechados, enchapados, muebles y marcos, terminaciones interna, tacos para zapatos, juguetes y lápices, etc. 
                    </p>
                    <a class="btn btn-primary" href="#">Ver proyecto <span class="glyphicon glyphicon-chevron-right"></span></a>
                </div>
            </div>
            <hr class="HRnormal" />

            <div class="row">
                <div class="col-md-7">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x300" alt="">
                    </a>
                </div>
                <div class="col-md-5 text-left">
                    <h4><b>Pinotea</b></h4>
                    <p>La madera se caracteriza por sus betas bien definidas, su tonalidad rojiza amarronada y su gran resistencia al paso del tiempo.
                    <br /><br />
                    Debido a su belleza y a su enorme fuerza estructural, se la utilizó extensivamente para la construcción de viviendas, fábricas, edificios en las ciudades, y fabricación de muebles. 
                    El lento crecimiento del árbol de Pinotea respecto de otras variedades, es la razón por la que no se la consideró para continuar su explotación comercial.
                    </p>
                    <a class="btn btn-primary" href="#">Ver proyecto <span class="glyphicon glyphicon-chevron-right"></span></a>
                </div>
            </div>
            <hr class="HRnormal" />
            <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
        </div>
    </section>
</asp:Content>
