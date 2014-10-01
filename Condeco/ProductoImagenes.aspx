<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoImagenes.aspx.cs" Inherits="Condeco.ProductoImagenes" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px;">
        <tr>
            <td align="center" colspan="2" style="padding-top: 20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Imagenes del Producto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="bottom" style="padding-right: 5px; padding-top: 20px">
                <asp:Label ID="VistaPreviaLabel" runat="server" Text="Vista Previa"></asp:Label>
            </td>
            <td valign="bottom">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right: 5px; padding-top: 20px" width="90px">
                <asp:Image ID="ImageParaAgregar" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
            </td>
            <td align="left" valign="top" style="padding-top: 20px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="(tipo de archivos: jpg, jpeg, png o gif)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="MaximoPermitidoLabel" runat="server" Text="Maximum size 2Mb."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccionar una imagen"
                                Width="350px" TabIndex="1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="SubirImagenButton" runat="server" TabIndex="2" Text="Subir la imagen seleccionada"
                                Width="350px" OnClick="SubirImagenButton_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 5px">
                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="3" Text="Delete" Width="90px"
                    OnClick="BorrarImagenButton_Click" />
            </td>
            <td align="left" style="padding-top: 5px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" style="padding-right: 5px">
                            <asp:Button ID="AgregarPortada" runat="server" TabIndex="3" Text="Agregar foto principal"
                                ToolTip="" Width="132px"
                                OnClick="AgregarPortadaImagenButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="AgregarButton" runat="server" TabIndex="3" Text="Agregar foto al catálogo de imagenes"
                                ToolTip=""
                                Width="150px" OnClick="AgregarImagenButton_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" colspan="4" style="padding-top: 30px">
                            <asp:Label ID="Label1" runat="server" SkinID="TituloPaginaClaro" Text="Imagenes"></asp:Label>
                            <hr noshade="noshade" size="1" color="#cccccc" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 10px">
                        </td>
                        <td align="center" colspan="3" valign="top" style="padding-top: 10px">
                            <asp:Label ID="CatalogoLabel" runat="server" Text="Catálogo de Imagenes"></asp:Label>
                            <hr noshade="noshade" size="1" color="#cccccc" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 10px">
                            <asp:Label ID="PortadaLabel" runat="server" Text="Foto Principal"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 10px">
                            <asp:Label ID="Imagen1Label" runat="server" Text="Imagen 1"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 10px">
                            <asp:Label ID="Imagen2Label" runat="server" Text="Imagen 2"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="padding-top: 10px">
                            <asp:Label ID="Imagen3Label" runat="server" Text="Imagen 3"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-right: 25px; padding-top: 20px; vertical-align: top">
                            <asp:Image ID="ImagePortada" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                        </td>
                        <td align="left" style="padding-right: 25px; padding-top: 20px; vertical-align: top">
                            <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc"
                                ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                        </td>
                        <td align="left" style="padding-right: 25px; padding-top: 20px; vertical-align: top">
                            <asp:Image ID="Image2" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc"
                                ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                        </td>
                        <td align="left" style="padding-top: 20px; vertical-align: top">
                            <asp:Image ID="Image3" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc"
                                ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 20px">
                            <asp:Button ID="BorrarPortadaButton" runat="server" TabIndex="3" Text="Eliminar" Width="92px"
                                OnClick="BorrarPortadaButton_Click" />
                        </td>
                        <td align="left" valign="top" style="padding-right: 25px; padding-top: 20px">
                            <asp:Button ID="BorrarImagen1Button" runat="server" TabIndex="3" Text="Eliminar" Width="92px"
                                OnClick="BorrarImagen1Button_Click" />
                        </td>
                        <td align="left" style="padding-right: 5px; padding-top: 20px" width="90px">
                            <asp:Button ID="BorrarImagen2Button" runat="server" TabIndex="3" Text="Eliminar" Width="92px"
                                OnClick="BorrarImagen2Button_Click" />
                        </td>
                        <td align="left" valign="top" style="padding-top: 20px">
                            <asp:Button ID="BorrarImagen3Button" runat="server" TabIndex="3" Text="Eliminar" Width="92px"
                                OnClick="BorrarImagen3Button_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-top: 20px" colspan="4">
                            <asp:Button ID="SalirButton" runat="server" Text="Exit" TabIndex="4" PostBackUrl="~/Default.aspx" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
