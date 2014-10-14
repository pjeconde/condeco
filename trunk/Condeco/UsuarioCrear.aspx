<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioCrear.aspx.cs" Inherits="Condeco.UsuarioCrear" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 500px; width: 740px">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" class="ppaltable" style="width: 100%;">
                    <tr>
                        <td>
                            <h2>
                                <asp:Label ID="Label5" runat="server" Text="Crear Nueva Cuenta"></asp:Label>
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left:32px; padding-top:20px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr>
                                    <td align="right" colspan="2" style="width: 300px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="First and Last Name" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="First and Last Name" SetFocusOnError="True">
                                            <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="1" Width="400px"></asp:TextBox>
                                    </td>
                                    <td style="width: 200px">
                                    </td>
                                </tr>
                                <!-- Pais -->
                                <tr>
                                    <td align="right" colspan="2" style="padding-right: 5px; padding-top: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                            ControlToValidate="PaisTextBox" ErrorMessage="Pais" SetFocusOnError="True"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PaisTextBox"
                                            ErrorMessage="Pais" SetFocusOnError="True">
                                            <asp:Label ID="Label10" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label25" runat="server" Text="Pais"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 5px">
                                        <asp:TextBox ID="PaisTextBox" runat="server" MaxLength="50" TabIndex="2" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Provincia -->
                                <tr>
                                    <td align="right" colspan="2" style="padding-right: 5px; padding-top: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                            ControlToValidate="ProvinciaTextBox" ErrorMessage="Provincia" SetFocusOnError="True"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ProvinciaTextBox"
                                            ErrorMessage="Provincia" SetFocusOnError="True">
                                            <asp:Label ID="Label27" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label28" runat="server" Text="Provincia"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 5px">
                                        <asp:TextBox ID="ProvinciaTextBox" runat="server" MaxLength="50" TabIndex="3" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Ciudad o Localidad -->
                                <tr>
                                    <td align="right" colspan="2" style="padding-right: 5px; padding-top: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                            ControlToValidate="LocalidadTextBox" ErrorMessage="City" SetFocusOnError="True"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label35" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="LocalidadTextBox"
                                            ErrorMessage="City" SetFocusOnError="True">
                                            <asp:Label ID="Label36" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label29" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 5px">
                                        <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="50" TabIndex="4" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-right: 5px; padding-top: 5px">
                                        <asp:Label ID="Label30" runat="server" Text="Facebook Address"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 5px">
                                        <asp:TextBox ID="FacebookTextBox" runat="server" MaxLength="50" TabIndex="5" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TelefonoTextBox"
                                            ErrorMessage="Telefono" SetFocusOnError="True" ValidationExpression="[0-9\-]*">
                                            <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label SkinID="TextoMediano" ID="TelefonoLabel" runat="server" Text="Telefono"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="50" TabIndex="5" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="6" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td colspan="2" style="color: Gray">
                                        (Muy importante: La confirmación de la cuenta se realizara vía email, a esta misma cuenta)
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                                            ErrorMessage="User.Id" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                                            ErrorMessage="User.Id" SetFocusOnError="True">
                                            <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="IdUsuarioLabel" runat="server" Text="Usuario de Ingreso"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" colspan="2" style="padding-left: 5px; padding-top:5px; width: 330px">
                                        <asp:Button ID="ComprobarDisponibilidadButton" runat="server" CausesValidation="false"
                                            OnClick="ComprobarDisponibilidadButton_Click" Text="It is available?" ToolTip="Chequear la disponibilidad del Id. de Usuario ingresado"
                                            Width="120px" />
                                        <asp:Label SkinID="TextoMediano" ID="ResultadoComprobarDisponibilidadLabel" runat="server" Font-Bold="True"
                                            Font-Size="12px" Text="" Width="200px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Clave" SetFocusOnError="True">
                                            <asp:Label ID="Label16" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="PasswordLabel" runat="server" Text="Clave"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="50" TabIndex="8" TextMode="Password"
                                            Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" rowspan="2" style="padding-left: 5px; padding-top:5px" valign="middle">
                                        <asp:Label ID="Label4" runat="server" ForeColor="Gray" Text="(Si usted olvido el password, use la pregunta de seguridad)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                            ErrorMessage="Reingresar password" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label17" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                            ErrorMessage="Reingresar password" SetFocusOnError="True">
                                            <asp:Label ID="Label18" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="ConfirmacionPasswordLabel" runat="server" Text="Reingresar password"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="ConfirmacionPasswordTextBox" runat="server" MaxLength="50" TabIndex="9"
                                            TextMode="Password" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de Securidad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label19" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de Securidad" SetFocusOnError="True">
                                            <asp:Label ID="Label20" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="PreguntaLabel" runat="server" Text="Pregunta de Securidad"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:Label SkinID="TextoMediano" ID="Label1" runat="server" Font-Bold="true" Text="¿"></asp:Label>
                                        <asp:TextBox ID="PreguntaTextBox" runat="server" MaxLength="256" TabIndex="10" Width="400px"></asp:TextBox>
                                        <asp:Label SkinID="TextoMediano" ID="Label6" runat="server" Font-Bold="true" Text="?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                            ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                            ErrorMessage="Respuesta" SetFocusOnError="True">
                                            <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="RespuestaTextBox" runat="server" MaxLength="256" TabIndex="11" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:Label SkinID="TextoMediano" ID="LabelIdMedio" runat="server" Text="Como nos conocio ?"></asp:Label>
                                    </td>
                                    <td align="left"  colspan="2" style="padding-top:5px">
				                        <asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="501" Width="216px" DataValueField="Id" DataTextField="Descr">
				                        </asp:DropDownList>
			                        </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:5px; width: 150px" valign="bottom">
                                        <asp:Label ID="Label3" runat="server" Text="" Width="150px"></asp:Label>
                                        <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                                    </td>
                                    <td align="right" style="padding-top:5px; padding-right: 5px">
                                        <asp:Label ID="CondicionesLabel" runat="server" Text="Terms and Conditions of Service"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="CondicionesTextBox" runat="server" Font-Size="Small" Height="100px"
                                            ReadOnly="true" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:5px" valign="top">
                                        <asp:Button ID="NuevaClaveCaptchaButton" runat="server" CausesValidation="false"
                                            OnClick="NuevaClaveCaptchaButton_Click" Text="New Code" />
                                    </td>
                                    <td align="right" style="padding-top:5px; padding-right: 5px; width: 150px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                            ErrorMessage="Codigo" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                            ErrorMessage="Codigo" SetFocusOnError="True">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="ClaveLabel" runat="server" Text="Codigo"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 80px; padding-top:5px">
                                        <asp:TextBox ID="CaptchaTextBox" runat="server" MaxLength="20" TabIndex="12" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-top:5px; padding-left: 5px">
                                        <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(not case sensitive)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="padding-top: 10px">
                                        <asp:Label ID="CrearCuentaLabel" runat="server" Text="By clicking on 'Create account', you agree to the terms and conditions of service."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="CrearCuentaButton" runat="server" OnClick="CrearCuentaButton_Click"
                                            TabIndex="13" Text="Crear cuenta" Width="100px" />
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                                            TabIndex="14" Text="Cancelar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="center" colspan="2" style="padding-bottom:30px; padding-top: 20px">
                                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>