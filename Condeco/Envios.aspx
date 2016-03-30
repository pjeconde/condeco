<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Envios.aspx.cs" Inherits="Condeco.Envios" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secEnvios">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p>
                    <span class="fa fa-2x fa-paper-plane wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading"> Envíos a todo el país</h2>
                    <hr>
                </div>
            </div>
            <!-- Portfolio Item Row -->
            <div class="row text-left">
                <div class="col-md-12">
                    <h3>Hacemos envíos a todo el país</h3>
                    <br />
                    <p>
                        Para adquirir cualquiera de nuestros productos, puede contactarnos por email a <a href="mailto:info@condeco.com.ar">info@condeco.com.ar</a>, dejarnos su consulta a través de la opción del menú "CONTACTO", o llamarnos telefónicamente.
                    </p>
                    <p>
                        Todos nuestros productos tienen un código de referencia para ubicarlos fácilmente.<br /> 
                        <img src="Imagenes/Envios/EnviosCodReferencia.png" alt="imagen de ejemplo"/>
                    </p>
                    <p>
                        Todos nuestros productos pueden ser retirados personalmente de nuestro depósito. De lo contrario podemos realizar un envío a través de <i><b>OCA</b></i> o <i><b>Chevallier</b></i> a cualquier parte del país que ustedes nos solicite.
                    </p>
                    <p>
                        También puedes adquirir nuestros productos a través de <i><b>Mercado Libre</b></i>, cuya plataforma brinda la posibilidad de obtener ventajas en la forma de pago. Además, al tener un sistema de reputación, podrás verificar la satisfacción de nuestros compradores.
                    </p>
                    <h4>Formas de pago:</h4>
                    <ul>
                        <li>Efectivo.</li>
                        <li>Transferencia bancaria.</li>
                        <li>Mercado Libre / Mercado pago.</li>
                    </ul>
                </div>
            </div>
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
