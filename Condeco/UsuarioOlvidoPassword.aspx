<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoPassword.aspx.cs" Inherits="Condeco.UsuarioOlvidoPassword" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <script type="text/javascript">
    function ValidateButtonOnClick()
    {
        var isValid = Page_ClientValidate();
        if (isValid == true) {
            return true;
        }
        else {
            return false;
        }
    }
    </script>
    <section class="bg-primary-white" id="secUsuarioOlvidoClave">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="Label7" runat="server" Text="Olvidó su clave ?"></asp:Label></h2>
                    <hr>
                    <p>
                        <asp:Label ID="Label8" runat="server" Text="Para definir una nueva clave en su cuenta, siguir las instrucciones que figuran a continuación:"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="1) Ingrese su Id. de Usuario y su email (a continuación hacer clic en el botón 'Solicitar Pregunta de Seguridad')."></asp:Label>
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox" ValidationGroup="Grupo1" 
                                        ErrorMessage="Id. de Usuario" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox" ValidationGroup="Grupo1"
                                        ErrorMessage="Id. de Usuario" SetFocusOnError="True">
                                        <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="IdUsuarioLabel" runat="server" Text="Id. de Usuario"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox"  ValidationGroup="Grupo1" 
                                        ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                        <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox" ValidationGroup="Grupo1" 
                                        ErrorMessage="Email" SetFocusOnError="True">
                                        <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="SolicitarPreguntaButton" runat="server" Width="100%" CssClass="btn btn-info" ValidationGroup="Grupo1" OnClick="SolicitarPreguntaButton_Click" TabIndex="3" Text="Solicitar Pregunta de Seguridad" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="Label10" runat="server" Text="2) Responder la pregunta de seguridad (a continuación hacer clic en el botón 'Solicitar nueva clave')."></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="PreguntaLabel" runat="server" Enabled="false" Text="Pregunta de Seguridad"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"  ValidationGroup="Grupo2" 
                                        ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox" ValidationGroup="Grupo2" 
                                        ErrorMessage="Respuesta" SetFocusOnError="True">
                                        <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="RespuestaTextBox" runat="server" Enabled="false" MaxLength="256" TabIndex="4" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="SolicitarNuevaPasswordButton" runat="server" CssClass="btn btn-info" ValidationGroup="Grupo2"  
                                        Enabled="false" OnClick="SolicitarNuevaPasswordButton_Click" TabIndex="5" Text="Solicitar el ingreso de la nueva clave" OnClientClick="BorrarMensaje();"
                                        Width="100%" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="Label11" runat="server" Text="3) Confirmar su nueva clave (hacer clic en 'Aceptar')."></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox" ValidationGroup="Grupo3" 
                                        ErrorMessage="Nueva clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox" ValidationGroup="Grupo3" 
                                        ErrorMessage="Nueva clave" SetFocusOnError="True">
                                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label1" runat="server" Text="Nueva clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Enabled="false" OnTextChanged="TextBox_TextChanged"
                                        TabIndex="6" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox" ValidationGroup="Grupo3" 
                                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox" ValidationGroup="Grupo3" 
                                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True">
                                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label2" runat="server" Text="Reingresar nueva clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Enabled="false"
                                        OnTextChanged="TextBox_TextChanged" TabIndex="7" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="AceptarButton" runat="server" Enabled="false" OnClick="AceptarButton_Click" CssClass="btn btn-info" 
                                        TabIndex="8" Text="Aceptar" ValidationGroup="Grupo3" />
                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx" CssClass="btn btn-info" 
                                        TabIndex="9" Text="Cancelar" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    <asp:ValidationSummary ID="VSGrupo1" runat="server" SkinID="MensajeValidationSummary" ValidationGroup="Grupo1" />
                                    <asp:ValidationSummary ID="VSGrupo2" runat="server" SkinID="MensajeValidationSummary" ValidationGroup="Grupo2" />
                                    <asp:ValidationSummary ID="VSGrupo3" runat="server" SkinID="MensajeValidationSummary" ValidationGroup="Grupo3" />
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
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
