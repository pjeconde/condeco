<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoPassword.aspx.cs" Inherits="Condeco.UsuarioOlvidoPassword" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <!-- @@@ TITULO DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" align="center" style="padding-top: 20px;">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Forgot your Password ?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top:20px;">
                <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="To set a new password for your account, follow the instructions below:"></asp:Label>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" style="padding-top:10px" valign="middle" align="left">
                <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="1) Enter User.Id and Email (then click the button 'Solicit Security Question')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:5px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                    ErrorMessage="User.Id" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                    <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                    ErrorMessage="User.Id" SetFocusOnError="True">
                    <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="IdUsuarioLabel" runat="server" Text="User.Id"></asp:Label>
            </td>
            <td  colspan="2" align="left" style="padding-top:5px">
                <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                    <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True">
                    <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td colspan="2" align="left" style="padding-top:5px">
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top:5px">
                <asp:Button ID="SolicitarPreguntaButton" runat="server" CausesValidation="false"
                    OnClick="SolicitarPreguntaButton_Click" TabIndex="3" Text="Solicit Security Question"
                    Width="100%" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="padding-top:5px">
                <asp:Label ID="Label10" runat="server" SkinID="TextoMediano" Text="2) Answer the Security Question (then click the button 'Solicit new password income')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top:5px;">
                <asp:Label ID="PreguntaLabel" runat="server" Enabled="false" SkinID="TituloMediano"
                    Text="Security Question"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:5px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                    ErrorMessage="Answer" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                    <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                    ErrorMessage="Answer" SetFocusOnError="True">
                    <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="RespuestaLabel" runat="server" Text="Answer"></asp:Label>
            </td>
            <td colspan="2" align="left" style="padding-top:5px">
                <asp:TextBox ID="RespuestaTextBox" runat="server" Enabled="false" MaxLength="256"
                    TabIndex="4" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top:5px">
                <asp:Button ID="SolicitarNuevaPasswordButton" runat="server" CausesValidation="false"
                    Enabled="false" OnClick="SolicitarNuevaPasswordButton_Click" TabIndex="5" Text="Solicit new password entry"
                    Width="100%" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="padding-top:5px">
                <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="3) Enter, and confirm your new password (then click 'Accept')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px; padding-top:5px">
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
            <td colspan="2" align="left" style="padding-right: 10px; padding-top:5px">
                <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Enabled="false" OnTextChanged="TextBox_TextChanged"
                    TabIndex="6" TextMode="Password" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px; padding-top:5px">
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
            <td colspan="2" align="left" style="padding-right: 10px; padding-top:5px">
                <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Enabled="false"
                    OnTextChanged="TextBox_TextChanged" TabIndex="7" TextMode="Password" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="padding-top:20px; width: 160px">
                <asp:Button ID="AceptarButton" runat="server" Enabled="false" OnClick="AceptarButton_Click"
                    TabIndex="8" Text="Accept" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
            <td align="right" style="padding-top:20px; width: 200px">
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                    TabIndex="9" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="padding-top:20px;">
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
