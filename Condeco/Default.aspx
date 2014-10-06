<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Condeco.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <table class="ppaltable" width="100%">
        <tr>
            <td>
                <h2>
                    Bienvenidos
                </h2>
                <p>
                    Usted podrá encontrar aquí, los distintos tipos de productos y objetos de decoración ofrecidos, y visualizar detalladamente los mismos.  
                    <br /> 
                    <br /> 
                    Principalmente trabajamos productos desarrollados en madera, con acabados en pintura poliuretánica de alta calidad.
                    <br />
                    También realizamos productos tipo vintage o retro, con terminaciones manuales que hacen único al producto.
                </p>
                <br />
                <p>
                    Realizamos todo tipo de reparación de pisos de madera, plastificado o hidrolaqueado de los mismos.<br />
                    Contamos con personal altamente capacitado para realizar dicha tarea. <br />
                    Si usted desea una hacer una consulta, cotización o presupuesto, haga <asp:HyperLink ID="HyperLink1" runat="server" Target="_self" NavigateUrl="~/Contacto.aspx">clic aqui</asp:HyperLink> y le contestaremos a la brevedad.
                </p>
                <p>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
