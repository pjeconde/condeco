<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="Condeco.UsuarioConsulta" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="User Permissions"></asp:Label>
            </td>
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	        </td>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="DatosPersonalesLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="PermisosGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowDataBound="PermisosGridView_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DescrTipoPermiso" HeaderText="Permission" SortExpression="DescrTipoPermiso">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Status" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Exit" TabIndex="4" PostBackUrl="~/Home.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
