<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Condeco.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <table class="ppaltable" width="100%">
        <tr>
            <td>
                <h2>
                    Bienvenidos<br />
                </h2>
                <p>
                    <font style="font-style: normal; font-style: italic; font-weight:bold"> Usted podrá encontrar en nuestro sitio web, los distintos tipos de productos y objetos de decoración ofrecidos, visualizando detalladamente los mismos.</font>
                    <br />
                </p>
                <h4 style="font-weight:bold">Muebles</h4>
                <p>
                    Principalmente trabajamos productos desarrollados en madera, con acabados en laca poliuretánica de alta calidad.
                    <br />
                    También realizamos productos tipo vintage o retro, con terminaciones manuales que hacen único al producto.
                </p>
                <asp:Image ID="ImageProductosRusticos" runat="server" ImageUrl="~/Imagenes/Productos.jpg" />
                <br />
                <p>&nbsp;</p>
                <h4 style="font-weight:bold">Pisos</h4>
                <p>
                    Realizamos todo tipo de <i><b>reparación de pisos de madera, plastificado o hidrolaqueado</b></i> de los mismos.<br />
                    Contamos con personal altamente capacitado para realizar dicha tarea. <br />
                    Si usted desea una hacer una consulta, cotización o presupuesto, haga <asp:HyperLink ID="HyperLink1" runat="server" Target="_self" NavigateUrl="~/Contacto.aspx">clic aquí</asp:HyperLink> y le contestaremos a la brevedad.
                </p>
                <asp:Image ID="ImageProductosPlastificados" runat="server" ImageUrl="~/Imagenes/Plastificados.jpg" />
                <br />
                <p>&nbsp;</p>
                <h4 style="font-weight:bold">Carteles</h4>
                <p>
                    Fabricamos <i><b>carteles para decoración en madera maciza tipo vintage</b></i>, a los cuales les hacemos un desgastado manual para simular el paso del tiempo. <br />
                    Utilizamos la madera con su tonalidad natural u oscurecida con tintes y diversos colores pasteles para darle calidez a los mismos. <br />
                    <br />
                    Realizamos además, algunos carteles con efecto similar al camuflado en diversas tonalidades y otros estilos como el <i><b>campestre</b></i> o el <i><b>shabby chic</b></i> que es una mezcla de elementos antiguos con modernos.<br />
                </p>
                <asp:Image ID="ImageProductosCarteles" runat="server" ImageUrl="~/Imagenes/Home.jpg" />
                <br />  
                <p>
                    La señalización decorativa no sólo luce bien en la oficina sino que también funciona muy bien en una casa. <br />
                    La creación de un cartel para la cocina con el menú, o un afiche para la sala con una cita conmovedora puede resultar muy atractivo. <br />
                    Hacer una señal con un aspecto envejecido consiste simular una pieza antigua mostrando las imperfecciones como parte de su encanto. <br />
                    <br />  
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
