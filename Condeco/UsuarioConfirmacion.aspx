<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioConfirmacion.aspx.cs" Inherits="Condeco.UsuarioConfirmacion" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioConfirmacion">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloLabel" runat="server" Text="Confirmación de creación de la cuenta"></asp:Label></h2>
                    <hr>
                    <p>
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
                    <br />
                    </p>
            </div>
        </div>
    </section>
</asp:Content>
