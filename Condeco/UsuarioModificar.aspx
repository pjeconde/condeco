<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioModificar.aspx.cs" Inherits="Condeco.UsuarioModificar" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioModificar">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="Label3" runat="server" Text="Modificar Cuenta"></asp:Label></h2>
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
                                    <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
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
                                    <asp:Label ID="Label28" runat="server" Text="Provincia"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ProvinciaTextBox" runat="server" MaxLength="50" TabIndex="3" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
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
                                    <asp:Label ID="TelefonoLabel" runat="server" Text="Telefono"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="50" TabIndex="5" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
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
                                    <asp:Label ID="IdUsuarioLabel" runat="server" Text="Nombre de Usuario"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="PasswordLabel" runat="server" Text="Clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="50" TabIndex="8" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Gray" Text="(Si usted olvido la clave, use la pregunta de seguridad)"></asp:Label>                                
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="PreguntaLabel" runat="server" Text="Pregunta de Seguridad"></asp:Label>
                                </div>
                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 text-left">
                                    <asp:TextBox ID="PreguntaTextBox" runat="server" MaxLength="256" TabIndex="10" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1 text-left">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="?"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="RespuestaTextBox" runat="server" MaxLength="256" TabIndex="11" Width="100%" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="LabelIdMedio" runat="server" Text="Como nos conocio ?"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="501" DataValueField="Id" DataTextField="Descr" Width="100%">
				                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Button ID="ModificarButton" runat="server" OnClick="ModificarCuentaButton_Click" CssClass="btn btn-info" 
                                        TabIndex="13" Text="Modificar" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Default.aspx" CssClass="btn btn-info" 
                                        TabIndex="14" Text="Cancelar" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
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