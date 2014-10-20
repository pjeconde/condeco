<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioConfirmacion.aspx.cs" Inherits="Condeco.UsuarioConfirmacion" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="padding-left:10px; text-align: left;">
        <tr>
            <td style="padding-top:20px">
                <table border="0" cellpadding="0" cellspacing="0" class="ppaltable" style="width: 100%;">
                    <tr>
                        <td>
                            <h2>
                                <asp:Label ID="TituloLabel" runat="server" Text="Confirmación de creación de la cuenta"></asp:Label>
                            </h2>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
