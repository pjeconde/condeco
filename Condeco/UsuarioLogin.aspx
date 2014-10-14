<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="Condeco.Ingreso" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="ppaltable" style="vertical-align:top">
        <tr>
            <td>
                 <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <h2>
                                Login
                            </h2>
                            <p>
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="Panel2" runat="server" Height="800px">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px; padding-right:10px; height: 600px; padding-top: 0px;" width="800px">
                        <tr>
                            <td align="left" rowspan="1" style="background-position: left 0px; padding: 10px; background-image: url('Imagenes/TroiloOrquesta.jpg'); background-repeat: no-repeat;" valign="top">
                                Si usted aún no posee una cuenta de usuario en nuestro Sitio Web, usted puede registrarse de forma gratuita haciendo clic en la opción 
                                &#39;Crear nueva cuenta de usuario&#39;.
                                <br />
                                <br />
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid" BorderWidth="1" BorderColor="#cccccc" Width="370px">
                                                <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px; padding-right: 10px;">
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 20px" class="style1">
                                                            <asp:Label ID="Label6" runat="server" SkinID="TituloPagina" Text="Login"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="TextoInicioMediano" style="padding-right: 10px; padding-top: 20px">
                                                            Nombre de usuario
                                                        </td>
                                                        <td align="left" style="width: 100px; padding-top: 20px">
                                                            <asp:TextBox ID="UsuarioTextBox" runat="server" MaxLength="50" OnTextChanged="UsuarioTextBox_TextChanged"
                                                                TabIndex="1" Width="114px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" rowspan="2" style="padding-right: 10px; padding-top: 20px">
                                                            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3"
                                                                Text="Login" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="TextoInicioMediano" style="padding-right: 10px; padding-top: 5px">
                                                            Clave
                                                        </td>
                                                        <td align="left" style="width: 100px; padding-right: 10px; padding-top: 5px">
                                                            <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                                                TabIndex="2" TextMode="Password" Width="114px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 10px;">
                                                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePaginaCorto" Text="&nbsp;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 10px">
                                                            <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx"
                                                                SkinID="LinkMedianoClaro">Crear nueva cuenta de usuario</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 5px; padding-bottom: 20px">
                                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx"
                                                                SkinID="LinkMedianoClaro">Olvidó su nombre de usuario ?</asp:HyperLink>&nbsp;&nbsp;
                                                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx"
                                                                SkinID="LinkMedianoClaro">Olvidó su clave ?</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-top: 20px">
                                            Esta cuenta de usuario le permitirá a usted, acceder a las novedades y promociones disponibles en nuestro sitio web.
                                            <br />
                                            <br />
                                            <font style="color: #F6B200">&gt;</font> Novedades
                                            <br />
                                            Una vez al mes actualizamos la información con las novedades o nuevos diseños que estamos desarrollando en nuestro taller.
                                            <br />
                                            <br />
                                            <font style="color: #F6B200">&gt;</font> Promociones
                                            <br />
                                            Por cada lanzamiento de un nuevo producto, tenemos reservado un precio especial para la venta de las primeras unidades.
                                            Usted contará con toda la información necesaria relacionada al lanzamiento del producto, y como usuario de nuestro sitio web podrá reservar la unidad que le sea de interes.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-top: 20px">
                                            <asp:Label ID="AclaracionTituloLabel" runat="server" Font-Bold="false" Font-Size="24px"
                                                ForeColor="#e8906e" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style2" style="padding-top: 10px">
                                            <asp:Label ID="AclaracionDetalleLabel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>

