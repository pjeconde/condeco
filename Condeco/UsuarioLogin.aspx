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
                <div class="col-md-3">
                    <p></p>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid" BorderWidth="0" BorderColor="#cccccc">
                            <h4><asp:Label ID="Label6" runat="server" Text="Login de Usuario"></asp:Label></h4>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    Nombre de usuario
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="UsuarioTextBox" runat="server" MaxLength="50" OnTextChanged="UsuarioTextBox_TextChanged" 
                                        TabIndex="1"></asp:TextBox>
                                </div>
                            </div><!-- /.row -->
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                     Clave
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                     <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                         TabIndex="2" TextMode="Password"></asp:TextBox>
                                </div>
                            </div><!-- /.row -->
                            <br/>
                            <p>
                                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-info" OnClick="LoginButton_Click" TabIndex="3"
                                        Text="Login" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                            </p>
                            <p>                                            
                                    <asp:Label ID="MensajeLabel" runat="server" CssClass="text-danger" Text=""></asp:Label>
                            </p>
                            <p>
                                    <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx">Crear nueva cuenta de usuario</asp:HyperLink>  
                                        <br />
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx">Olvidó su nombre de usuario ?</asp:HyperLink>&nbsp;&nbsp;
                                
                                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx">Olvidó su clave ?</asp:HyperLink>
                            </p>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <p></p>
                </div>
            </div>
            <div class="jumbotron" style="background-color: #dadada">
              <h4>Información</h4>
              <p class="text-left">
                    <h5>
                    Esta cuenta de usuario le permitirá a usted, acceder a las novedades y promociones
                    disponibles en nuestro sitio web.
                    </h5>
                    <br />
                    <div class="col-lg-6">
                        <div class="panel panel-info">
                          <div class="panel-heading"><font style="color: #F6B200"><b>&gt;</b></font> Novedades</div>
                          <div class="panel-body">
                                <h6>
                                Una vez al mes actualizamos la información con las novedades o nuevos diseños que
                                estamos desarrollando en nuestro taller.
                                </h6>
                          </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="panel panel-info">
                          <div class="panel-heading"><font style="color: #F6B200"><b>&gt;</b></font> Promociones</div>
                          <div class="panel-body">
                                <h6>
                                    Por cada lanzamiento de un nuevo producto, tenemos reservado un precio especial
                                    para la venta de las primeras unidades. Usted contará con toda la información necesaria
                                    relacionada al lanzamiento del producto, y como usuario de nuestro sitio web podrá
                                    reservar la unidad que le sea de interes.
                                </h6>
                          </div>
                        </div>
                    </div>
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

