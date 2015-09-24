<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioCrear.aspx.cs" Inherits="Condeco.UsuarioCrear" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioOlvidoClave">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="Label3" runat="server" Text="Crear Nueva Cuenta"></asp:Label></h2>
                    <hr>
                    <p>
                    </p>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <p></p>
                </div>
                <div class="col-lg-8">
                <div class="panel panel-default" style="min-width:350px">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombreTextBox"
                                        ErrorMessage="First and Last Name" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox"
                                        ErrorMessage="First and Last Name" SetFocusOnError="True">
                                        <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label SkinID="TextoMediano" ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                     <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                        ControlToValidate="PaisTextBox" ErrorMessage="Pais" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PaisTextBox"
                                        ErrorMessage="Pais" SetFocusOnError="True">
                                        <asp:Label ID="Label10" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label25" runat="server" Text="Pais"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PaisTextBox" runat="server" MaxLength="50" TabIndex="2" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
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
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ProvinciaTextBox" runat="server" MaxLength="50" TabIndex="3" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
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
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="50" TabIndex="4" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="Label30" runat="server" Text="Facebook Address"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="FacebookTextBox" runat="server" MaxLength="50" TabIndex="5" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TelefonoTextBox"
                                        ErrorMessage="Telefono" SetFocusOnError="True" ValidationExpression="[0-9\-]*">
                                        <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:Label SkinID="TextoMediano" ID="TelefonoLabel" runat="server" Text="Telefono"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="50" TabIndex="5" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label SkinID="TextoMediano" ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="6" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    (Muy importante: La confirmación de la cuenta se realizara vía email, a esta misma
                                    cuenta)
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                                        ErrorMessage="User.Id" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                                        ErrorMessage="User.Id" SetFocusOnError="True">
                                        <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label SkinID="TextoMediano" ID="IdUsuarioLabel" runat="server" Text="Nombre de Usuario"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button ID="ComprobarDisponibilidadButton" runat="server" CausesValidation="false"
                                            OnClick="ComprobarDisponibilidadButton_Click" Text="Está disponible ?" ToolTip="Chequear la disponibilidad del Nombre de Usuario ingresado"
                                            Width="100%" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                     <asp:Label ID="ResultadoComprobarDisponibilidadLabel" runat="server" Font-Bold="True"
                                            Font-Size="12px" Text="" Width="100%"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                        ErrorMessage="Clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                        ErrorMessage="Clave" SetFocusOnError="True">
                                        <asp:Label ID="Label16" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label SkinID="TextoMediano" ID="PasswordLabel" runat="server" Text="Clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="50" TabIndex="8" TextMode="Password"
                                            Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                        ErrorMessage="Reingresar clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label17" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                        ErrorMessage="Reingresar clave" SetFocusOnError="True">
                                        <asp:Label ID="Label18" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="ConfirmacionPasswordLabel" runat="server" Text="Reingresar clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ConfirmacionPasswordTextBox" runat="server" MaxLength="50" TabIndex="9"
                                        TextMode="Password" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Gray" Text="(Si usted olvido la clave, use la pregunta de seguridad)"></asp:Label>                                
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                        ErrorMessage="Pregunta de Securidad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label19" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                        ErrorMessage="Pregunta de Securidad" SetFocusOnError="True">
                                        <asp:Label ID="Label20" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label SkinID="TextoMediano" ID="PreguntaLabel" runat="server" Text="Pregunta de Seguridad"></asp:Label>
                                </div>
                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 text-left">
                                    <asp:TextBox ID="PreguntaTextBox" runat="server" MaxLength="256" TabIndex="10" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1 text-left">
                                    <asp:Label SkinID="TextoMediano" ID="Label6" runat="server" Font-Bold="true" Text="?"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                        ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                        ErrorMessage="Respuesta" SetFocusOnError="True">
                                        <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label SkinID="TextoMediano" ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="RespuestaTextBox" runat="server" MaxLength="256" TabIndex="11" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label SkinID="TextoMediano" ID="LabelIdMedio" runat="server" Text="Como nos conocio ?"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="501" DataValueField="Id" DataTextField="Descr" Width="100%">
				                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button ID="NuevaClaveCaptchaButton" runat="server" CausesValidation="false" OnClick="NuevaClaveCaptchaButton_Click" Text="Nuevo código" />
                                    
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="CondicionesLabel" runat="server" Visible="false" Text="Terminos y condiciones"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="CondicionesTextBox" runat="server" Font-Size="Small" Height="100px" Visible="false" ReadOnly="true" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="CrearCuentaLabel" runat="server" Visible="false" Text="Al hacer clic en 'Crear cuenta', usted está aceptado los terminos y condiciones de la misma."></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                        ErrorMessage="Código" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                        ErrorMessage="Código" SetFocusOnError="True">
                                        <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="ClaveLabel" runat="server" Text="Ingresar el código"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="CaptchaTextBox" runat="server" MaxLength="20" TabIndex="12" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(no tiene en cuenta las mínusculas o mayúsculas)"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button ID="CrearCuentaButton" runat="server" OnClick="CrearCuentaButton_Click" CssClass="btn btn-info" 
                                        TabIndex="13" Text="Crear cuenta" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx" CssClass="btn btn-info" 
                                        TabIndex="14" Text="Cancelar" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2">
                    <p></p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>