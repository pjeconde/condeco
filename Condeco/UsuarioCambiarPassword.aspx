<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="Condeco.UsuarioCambiarPassword" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="AceptarButton">
        <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="text-align:left; padding-left:10px;">
            <tr>
                <td colspan="2" align="center" style="padding-top:20px">
                    <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Change User Password"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top:20px;">
                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="To change the password of your account, enter the information requested below:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top:10px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Current Password" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Current Password" SetFocusOnError="True">
                        <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label15" runat="server" Text="Current Password"></asp:Label>
                </td>
                <td align="left" style="padding-top:10px">
                    <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="1" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="New Password" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="New Password" SetFocusOnError="True">
                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
                </td>
                <td align="left" style="padding-right: 10px; padding-top: 5px">
                    <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="2" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Re-enter new password" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Re-enter new password" SetFocusOnError="True">
                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text="Re-enter new password"></asp:Label>
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
                        Text="Accept" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Home.aspx"
                        TabIndex="5" Text="Cancel" />
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
