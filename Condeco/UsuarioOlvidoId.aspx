<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoId.aspx.cs" Inherits="Condeco.UsuarioOlvidoId" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioOlvidoId">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloLabel" runat="server" Text="Olvidó su Nombre de Usuario ?"></asp:Label></h2>
                    <hr>
                    <p>
                        <asp:Label ID="Label8" runat="server" Text="Si usted olvidó su Nombre de Usuario, ingrese el email que registró al momento de crear la cuenta."></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Nosotros le enviaremos su Nombre de Usuario a esa dirección de email."></asp:Label>
                    </p>
            </div>
            <div class="container">
            <div class="row">
                <div class="col-lg-2">
                    <p></p>
                </div>
                <div class="col-lg-8">
                    <div class="panel panel-default" style="">
                        <div class="panel-body">
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
                                    <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="3" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="AceptarButton" runat="server" CssClass="btn btn-info" OnClick="AceptarButton_Click"
                                        TabIndex="4" Text="Solicitar Nombre de Usuario" OnClientClick="BorrarMensaje()"
                                        UseSubmitBehavior="false" />
                                    <asp:Button ID="CancelarButton" runat="server" CssClass="btn btn-info" CausesValidation="false"
                                        PostBackUrl="~/UsuarioLogin.aspx" TabIndex="5" Text="Cancelar" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
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
