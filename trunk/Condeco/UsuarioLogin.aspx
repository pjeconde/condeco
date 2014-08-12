﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="Condeco.Ingreso" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="ppaltable" style="vertical-align:top">
        <tr>
            <td>
                <h2>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="24px" ForeColor="#F6B200"
                        Text="Login"></asp:Label>
                </h2>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="Panel2" runat="server" Height="600px">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:20px; padding-right:20px; height: 600px; padding-top: 0px;" width="720px">
                        <tr>
                            <td align="left" class="style3" rowspan="1" style="background-position: left -40px;
                                padding: 10px; background-image: url('Imagenes/TroiloOrquesta.jpg'); background-repeat: no-repeat;"
                                valign="top">
                                If you are NOT yet a user account on our website, you can register for free by clicking on the option 
                                &#39;Create new account&#39;.
                                <br />
                                <br />
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid"
                                                BorderWidth="1" BorderColor="#cccccc" Width="370px">
                                                <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px; padding-right: 10px;">
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 20px" class="style1">
                                                            <asp:Label ID="Label6" runat="server" SkinID="TituloPagina" Text="Login"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="TextoInicioMediano" style="padding-right: 10px; padding-top: 20px">
                                                            User.Id
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
                                                            Password
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
                                                                SkinID="LinkMedianoClaro">Create new account</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding-top: 5px; padding-bottom: 20px">
                                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx"
                                                                SkinID="LinkMedianoClaro">Forgot your User.Id ?</asp:HyperLink>&nbsp;&nbsp;
                                                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx"
                                                                SkinID="LinkMedianoClaro">Forgot your password ?</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-top: 20px">
                                            This user account will allow you to operate on our website so independent and do the activities listed below:
                                            <br />
                                            <br />
                                            <font style="color: #F6B200">&gt;</font> Milongas
                                            <br />
                                            If you, are the owner or manager of a Milonga, you can enter all the information
                                            concerning it, to exhibit in our search engine. Thus, display all the Ballroom features, amenities, services, location
                                            and schedules among other things.
                                            <br />
                                            <br />
                                            <font style="color: #F6B200">&gt;</font> Teachers or Taxi Dancers<br />
                                            If you are a teacher of Tango, you can leave your data available and the services offered.
                                            <br />
                                            <br />
                                            <font style="color: #F6B200">&gt;</font> Festivals
                                            <br />
                                            If you are organizing a festival or event of Tango, you can enter all the information regarding the same, to convey our search and thus
                                            give full features of the event, inform the orchestra and dancers involved, amenities, location, duration and schedules among other things.
                                            <br />
                                            <br />
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
