<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="Condeco.UsuarioCambiarPassword" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioCambiarClave">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloLabel" runat="server" Text="Cambiar la clave"></asp:Label></h2>
                    <hr>
                    <p>
                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para cambiar la clave de su cuenta, ingrese la información requerida a continuación:"></asp:Label>
                    </p>
            </div>
            <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <p></p>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                        ErrorMessage="Clave Actual" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                        ErrorMessage="Clave Actual" SetFocusOnError="True">
                                        <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label15" runat="server" Text="Clave Actual"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                        TabIndex="1" TextMode="Password" Width="120px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                        ErrorMessage="Nueva Clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                        ErrorMessage="Nueva Clave" SetFocusOnError="True">
                                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label1" runat="server" Text="Nueva Clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                        TabIndex="2" TextMode="Password" Width="120px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                        ErrorMessage="Reingresar nueva clave" SetFocusOnError="True">
                                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label2" runat="server" Text="Reingresar nueva clave"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                        TabIndex="3" TextMode="Password" Width="120px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4" CssClass="btn btn-info" 
                                        Text="Aceptar" OnClientClick="BorrarMensaje();" />
                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Default.aspx" CssClass="btn btn-info"
                                        TabIndex="5" Text="Cancelar" />
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
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
