<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="Condeco.UsuarioCambiarPassword" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="AceptarButton">
        <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="text-align:left; padding-left:10px;">
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" class="ppaltable" style="width: 100%;">
                        <tr>
                            <td>
                                <h2>
                                    <asp:Label ID="TituloLabel" runat="server" Text="Cambiar la clave"></asp:Label>
                                </h2>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top:20px;">
                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para cambiar la clave de su cuenta, ingrese la información requerida a continuación:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top:10px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Clave Actual" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Clave Actual" SetFocusOnError="True">
                        <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label15" runat="server" Text="Clave Actual"></asp:Label>
                </td>
                <td align="left" style="padding-top:10px">
                    <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="1" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="Nueva Clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="Nueva Clave" SetFocusOnError="True">
                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text="Nueva Clave"></asp:Label>
                </td>
                <td align="left" style="padding-right: 10px; padding-top: 5px">
                    <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="2" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True">
                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text="Reingresar nueva clave"></asp:Label>
                </td>
                <td align="left" style="padding-right:10px; padding-top: 5px">
                    <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="3" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                        Text="Aceptar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Default.aspx"
                        TabIndex="5" Text="Cancelar" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
