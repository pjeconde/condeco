<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Contacto.aspx.cs" Inherits="Condeco.Contacto" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <table class="ppaltable" width="100%">
        <tr>
            <td>
                <h2>
                    Contacto
                </h2>
                <table border="0" cellpadding="0" cellspacing="0" style="background-position: left; padding-left:10px; background-image: url('Imagenes/Violin.jpg'); background-repeat: no-repeat; width: 580px">
                    <tr>
                        <td align="right" colspan="4" style="padding-top:20px">
                            <asp:Label ID="CorreoElectronicoLabel" runat="server" Text="Email: "></asp:Label>
                            <asp:HyperLink ID="eMailInfoHyperLink" runat="server" 
                                NavigateUrl='mailto:info@condeco.com.ar' ForeColor="#FF6037">info@condeco.com.ar</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-right: 5px">
                        </td>
                        <td align="right" style="width: 60px; padding-top: 10px; padding-right: 5px">
                            <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding-top: 10px">
                            <asp:TextBox ID="NombreTextBox" runat="server" TabIndex="1" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right" style="padding-top: 3px; padding-right: 5px">
                            <asp:Label ID="TelefonoLabel" runat="server" Text="Telefono"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding-top: 3px">
                            <asp:TextBox ID="TelefonoTextBox" runat="server" TabIndex="2" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right" style="padding-top: 3px; padding-right: 5px">
                            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding-top: 3px">
                            <asp:TextBox ID="EmailTextBox" runat="server" TabIndex="3" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 3px">
                        </td>
                        <td align="right" style="padding-top: 3px; padding-right: 5px">
                            <asp:Label ID="MotivoLabel" runat="server" Text="Asunto"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding-top: 3px">
                            <asp:TextBox ID="MotivoTextBox" runat="server" TabIndex="4" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top: 3px" valign="bottom">
                            <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                        </td>
                        <td align="right" style="padding-top: 3px; padding-right: 5px">
                            <asp:Label ID="Label2" runat="server" Text="Mensaje"></asp:Label>
                        </td>
                        <td align="left" colspan="2" style="padding-top: 3px">
                            <asp:TextBox ID="MensajeTextBox" runat="server" Height="100px" TabIndex="5" style="resize: none;" TextMode="MultiLine" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top: 3px" valign="top">
                            <asp:Button ID="NuevaClaveCaptchaButton" runat="server" TabIndex="7" OnClick="NuevaClaveCaptchaButton_Click" Text="Nuevo código" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                        </td>
                        <td align="right" style="padding-top: 3px; padding-right: 5px">
                            <asp:Label ID="ClaveLabel" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td align="left" style="width: 80px; padding-top: 3px">
                            <asp:TextBox ID="CaptchaTextBox" runat="server" TabIndex="6" Width="80px"></asp:TextBox>
                        </td>
                        <td align="left" style="padding-top: 3px; padding-left: 3px; " class="style1">
                            <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(not case sensitive / no se distinguen mayúsculas de minúsculas)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="left" style="padding-top: 10px" class="style2">
                            <asp:Button ID="EnviarButton" runat="server" OnClick="EnviarButton_Click" TabIndex="8" Text="Enviar" Width="80px" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                        </td>
                        <td align="right" style="padding-top: 10px; padding-right: 0px" class="style1">
                            <asp:Button ID="BorrarDatosButton" runat="server" OnClick="BorrarDatosButton_Click" Text="Borrar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="right" style="padding-top: 5px" class="style2">
                            <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="13" Text="Salir" PostBackUrl="~/Default.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="padding-bottom: 30px; padding-top: 20px">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <script type="text/javascript">
                    function BorrarMensaje() {
                        {
                            document.getElementById('<%=BorrarDatosButton.ClientID%>').enabled = false;
                            document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
                        }
                    }
                </script>
            </td>
        </tr>
    </table>
</asp:Content>
