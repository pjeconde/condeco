<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Empresa.aspx.cs" Inherits="Condeco.Empresa" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
     <section class="bg-primary" id="empresa">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <p>
                    <span class="fa fa-2x fa-building-o"></span>
                    </p>
                    <h2 class="section-heading"> Empresa</h2>
                    <hr>
                    <p>Nuestra empresa esta ubicada en el barrio de Villa del Parque y cuenta con talleres propios.
                    <br />Nos dedicamos al diseño y fabricación de objetos de decoración realizados principalmente en madera.
                    </p>
                    <p>
                        Nuestro objetivo fundamental es satisfacer al cliente ofreciendo productos innovadores con personalidad propia y que al mismo tiempo nos permita cuidar el medio ambiente.
                        <br />
                        Es por eso que desarrollamos, en la medida de lo posible, productos con maderas recuperadas en demoliciones y otros materiales descartados por individuos o empresas.
                        Reciclamos materiales que nos permitan generar objetos funcionales con un diseño actual.
                    </p>
                    <a href="Default.aspx" class="btn btn-default btn-xl">Home</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>