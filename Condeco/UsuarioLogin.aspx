<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="Condeco.Ingreso" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
     <section class="bg-primary-white" id="secUsuarioLogin">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"> Login</h2>
                    <hr>
                    <p>
                        Si usted aún no posee una cuenta de usuario en nuestro Sitio Web, usted puede registrarse
                        de forma gratuita haciendo clic en la opción &#39;Crear nueva cuenta de usuario&#39;.
                    <br />
                    </p>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <p>...</p>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default" style="max-width: 400px; min-width: 380px;">
                        <div class="panel-body">
                            <p>
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid" BorderWidth="0" BorderColor="#cccccc">
                                <p>
                                    <h4><asp:Label ID="Label6" runat="server" SkinID="TituloPagina" Text="Login de Usuario"></asp:Label></h4>
                                </p>                                       
                                <div class="row control-group">
                                    <div class="form-group col-xs-6">
                                    <div class="input-group">
                                        Nombre de usuario
                                    </div><!-- /input-group -->
                                    </div><!-- /.col-lg-6 -->
                                    <div class="form-group col-xs-6">
                                    <div class="input-group">
                                        <asp:TextBox ID="UsuarioTextBox" runat="server" MaxLength="50" OnTextChanged="UsuarioTextBox_TextChanged" 
                                        TabIndex="1"></asp:TextBox>
                                    </div><!-- /input-group -->
                                    </div><!-- /.col-lg-6 -->
                                </div><!-- /.row -->
                                <div class="row control-group">
                                    <div class="form-group col-xs-6">
                                        <div class="input-group">
                                            Clave
                                        </div>
                                        <!-- /input-group -->
                                    </div>
                                    <!-- /.col-lg-6 -->
                                    <div class="form-group col-xs-6">
                                        <div class="input-group">
                                            <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                            TabIndex="2" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <!-- /input-group -->
                                    </div>
                                    <!-- /.col-lg-6 -->
                                </div><!-- /.row -->
                                <p>
                                        <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-info" OnClick="LoginButton_Click" TabIndex="3"
                                            Text="Login" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                </p>
                                <p>                                            
                                        <asp:Label ID="MensajeLabel" runat="server" CssClass="text-danger" Text=""></asp:Label>
                                </p>
                                <p>
                                        <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx"
                                            SkinID="LinkMedianoClaro">Crear nueva cuenta de usuario</asp:HyperLink>  
                                            <br />
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx"
                                            SkinID="LinkMedianoClaro">Olvidó su nombre de usuario ?</asp:HyperLink>&nbsp;&nbsp;
                                
                                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx"
                                            SkinID="LinkMedianoClaro">Olvidó su clave ?</asp:HyperLink>
                                </p>
                                </asp:Panel>
                            </p>    
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <p>...</p>
                </div>
            </div>
            <div class="jumbotron">
              <h4>Información</h4>
              <p class="text-left">
                    <h5>
                    Esta cuenta de usuario le permitirá a usted, acceder a las novedades y promociones
                    disponibles en nuestro sitio web.
                    </h5>
                    <br />
                    <font style="color: #F6B200"><b>&gt;</b></font> Novedades
                    <br />
                    <h6>
                    Una vez al mes actualizamos la información con las novedades o nuevos diseños que
                    estamos desarrollando en nuestro taller.
                    </h6>
                    <br />
                    <font style="color: #F6B200"><b>&gt;</b></font> Promociones
                    <br />
                    <h6>
                    Por cada lanzamiento de un nuevo producto, tenemos reservado un precio especial
                    para la venta de las primeras unidades. Usted contará con toda la información necesaria
                    relacionada al lanzamiento del producto, y como usuario de nuestro sitio web podrá
                    reservar la unidad que le sea de interes.
                    </h6>
                </p>
                <p><a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a></p>
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

