<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoCrear.aspx.cs" Inherits="Condeco.ProductoCrear" Theme="" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <script type="text/javascript">
        function ValidaDDL(source, arguments) {
            if (arguments.Value < 1) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        } 
    </script>
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Nuevo Producto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:2px; width:150px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NombreTextBox"
                    ErrorMessage="Name of Producto" SetFocusOnError="True">
                    <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="2" Width="400px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:2px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DescripcionTextBox"
                    ErrorMessage="Description" SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Description"></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:TextBox ID="DescripcionTextBox" runat="server" TextMode="MultiLine" CssClass="MultilineFont" style="resize: none;" MaxLength="250" Height="100px" TabIndex="2" Width="400px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:RegularExpressionValidator ID="PrecioRegularExpressionValidator"
                    runat="server" ControlToValidate="PrecioBaseTextBox"
                    ErrorMessage="Error in format price" SetFocusOnError="True"
                    ValidationExpression="[0-9]+(\.[0-9]+)?">
                    <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:Label ID="Label11" runat="server" Text="Precio ($):"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="PrecioBaseTextBox" runat="server" MaxLength="16" TabIndex="501"
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label3" runat="server" Text="Ticket Information"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="ComentarioPrecioBaseTextBox" runat="server" MaxLength="250" TextMode="MultiLine" Height="40px" TabIndex="502" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                &nbsp;(example: http://www.tangofamilyandguide.com.ar) 
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label1" runat="server" Text="Web Site"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="WebSiteTextBox" runat="server" MaxLength="60" TabIndex="502"
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                &nbsp;(example: info@tangofamilyandguide.com.ar)
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label12" runat="server" Text="Email (info) Site"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="60" TabIndex="502"
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                &nbsp;(example: https://www.facebook.com/Producto)
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label13" runat="server" Text="Facebook Address"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="FacebookTextBox" runat="server" MaxLength="60" TabIndex="502"
                     Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label14" runat="server" Text="Google Map Address"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="GoogleMapTextBox" runat="server" MaxLength="60" TabIndex="502"
                     Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 5px">
                <asp:Label ID="Label15" runat="server" Text="Type of Floor"></asp:Label>
            </td>
            <td align="left" style="padding-top: 5px">
                <asp:DropDownList ID="TipoPisoDropDownList" runat="server" TabIndex="501" Width="200px"
                    DataValueField="Id" DataTextField="Descr">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 5px">
                <asp:Label ID="Label16" runat="server" Text="Type of Producto"></asp:Label>
            </td>
            <td align="left" style="padding-top: 5px">
                <asp:DropDownList ID="TipoProductoDropDownList" runat="server" TabIndex="501" Width="200px"
                    DataValueField="Id" DataTextField="Descr">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 5px">
                <asp:Label ID="Label17" runat="server" Text="Type of Music"></asp:Label>
            </td>
            <td align="left" style="padding-top: 5px">
                <asp:DropDownList ID="TipoMusicaDropDownList" runat="server" TabIndex="501" Width="200px"
                    DataValueField="Id" DataTextField="Descr">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:Label ID="Label7" runat="server" Text="Comments"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px" valign="top">
                <asp:TextBox ID="ComentariosTextBox" runat="server" MaxLength="250" CssClass="MultilineFont" style="resize: none;" TextMode="MultiLine" Height="80px" TabIndex="502" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="502" Text="Accept" onclick="AceptarButton_Click" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="503" Text="Cancel" PostBackUrl="~/Home.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
</asp:Content>