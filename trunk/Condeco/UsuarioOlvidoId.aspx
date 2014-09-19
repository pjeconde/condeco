﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoId.aspx.cs" Inherits="Condeco.UsuarioOlvidoId" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <!-- @@@ TITULO DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" align="center" style="padding-top:20px">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Forgot your User.Id ?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top:20px;">
                <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="If you forget your User.Id, enter the eMail that recorded at the time of creating your account."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top:10px;">
                <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="We will send your User.Id through an email to that address."></asp:Label>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td align="right" style="padding-top:20px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                    <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True">
                    <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top:20px">
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="3" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                    Text="Solicit User.Id" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
            <td align="right" style="padding-top:20px">
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                    TabIndex="5" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
            </td>
        </tr>
        <!-- @@@ @@@-->
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>