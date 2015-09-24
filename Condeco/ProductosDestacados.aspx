<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ProductosDestacados.aspx.cs" Inherits="Condeco.ProductosDestacados" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secProductosDestacados">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <p>
                    <span class="fa fa-2x fa-diamond wow bounceIn text-primary" data-wow-delay=".1s"></span>
                    </p>
                    <h2 class="section-heading"> Productos Destacados</h2>
                    <hr>
                    <p>En breve estaremos informando los productos destacados.
                    </p>
                    <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
