<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="Condeco.UsuarioConsulta" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioOlvidoId">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-user"></span>
                    </p>
                    <h2 class="section-heading"><asp:Label ID="TituloPaginaLabel" runat="server" Text="Datos del Usuario"></asp:Label></h2>
                    <hr>
                    <p>

                    </p>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <p></p>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="panel panel-default" style="">
                            <div class="panel-body">
                                <div class="row">
                                    <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc"
                                        ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="DatosPersonalesLabel" runat="server"></asp:Label>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="container">
                                        <asp:GridView ID="PermisosGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="PermisosGridView_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="DescrTipoPermiso" HeaderText="Permido" SortExpression="DescrTipoPermiso">
                                                    <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                                    <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" Wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:Button ID="SalirButton" runat="server" Text="Salir" TabIndex="4" PostBackUrl="~/Default.aspx" CssClass="btn btn-info" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <p>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
