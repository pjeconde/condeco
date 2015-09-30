<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Contacto.aspx.cs" Inherits="Condeco.Contacto" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secContacto">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <p>
                        <span class="fa fa-2x fa-pencil"></span>
                    </p>
                    <h2 class="section-heading">
                        Contacto</h2>
                    <hr>
                </div>
                <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                    <p>
                        Usted puede dejarnos un mensaje o inquietud. Trataremos de contestar a la brevedad. 
                    </p>
                    <!-- Contact Form - Enter your email address on line 19 of the mail/contact_me.php file to make this form work. -->
                    <!-- WARNING: Some web hosts do not allow emails to be sent through forms to common mail hosts like Gmail or Yahoo. It's recommended that you use a private domain email address! -->
                    <!-- NOTE: To use the contact form, your site must be on a live web host with PHP! The form will not work locally! -->
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Nombre</label>
                            <input type="text" runat="server" class="form-control" placeholder="Nombre" id="ContactoNombre" required 
                                data-validation-required-message="Por favor ingrese su nombre.">
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Email</label>
                            <input type="text" runat="server" class="form-control" placeholder="Email" id="ContactoEmail" required
                                data-validation-required-message="Por favor ingrese su email.">
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Teléfono</label>
                            <input type="text" runat="server" class="form-control" placeholder="Teléfono" id="ContactoTelefono" required 
                                data-validation-required-message="Por favor ingrese número de telefono.">
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Asunto</label>
                            <input type="text" runat="server" class="form-control" placeholder="Asunto" id="ContactoAsunto" required 
                                data-validation-required-message="Por favor ingrese número de telefono.">
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Mensaje</label>
                            <textarea rows="5" runat="server" class="form-control" placeholder="Mensaje" id="ContactoMensaje" required
                                data-validation-required-message="Por favor ingrese un mensaje." style="resize: none;"></textarea>
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label hidden="hidden">Código de control</label>
                            <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                            <asp:Button ID="NuevaClaveCaptchaButton" runat="server" class="btn btn-info" TabIndex="7"
                                OnClick="NuevaClaveCaptchaButton_Click" Text="Nuevo código" OnClientClick="this.disabled = true; BorrarMensaje()"
                                UseSubmitBehavior="false" />
                            <br />
                            <input type="text" runat="server" class="form-control" placeholder="Ingresar el Código"
                                id="ContactoCodigo" required data-validation-required-message="Por favor ingrese el código.">
                            <asp:Label ID="Label1" runat="server" ForeColor="gray" Text="(NO se distinguen mayúsculas de minúsculas)"></asp:Label>
                            <p class="help-block text-danger">
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <asp:Button ID="EnviarButton" runat="server" class="btn btn-info" OnClick="EnviarButton_Click" TabIndex="8" Text="Enviar" OnClientClick="BorrarMensaje()" UseSubmitBehavior="true" />
                            <asp:Button ID="BorrarDatosButton" runat="server" class="btn btn-info" OnClick="BorrarDatosButton_Click" Text="Borrar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                            <asp:Button ID="SalirButton" runat="server" class="btn btn-info" CausesValidation="false" TabIndex="13" Text="Salir" PostBackUrl="~/Default.aspx" />
                        </div>
                    </div>
                    <div id="success">
                        <p class="bg-info">
                            <asp:Label ID="MensajeOKLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                        </p>
                    </div>
                    <div id="notsuccess">
                        <p class="bg-danger">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                        </p>
                    </div>
                    <p>
                        <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
                    </p>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=BorrarDatosButton.ClientID%>').enabled = false;
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
