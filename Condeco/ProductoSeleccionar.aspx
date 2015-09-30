<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoSeleccionar.aspx.cs" Inherits="Condeco.ProductoSeleccionar" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secUsuarioLogin">
        <div class="container">
            <div class="row">
                    <p>
                    <span class="fa fa-2x fa-search"></span>
                    </p>
                    <h2 class="section-heading"> <asp:Label ID="TituloPaginaLabel" runat="server" Text="? Producto"></asp:Label></h2>
                    <hr>
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
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="IdProductoRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="NombreRadioButton" runat="server" AutoPostBack="true" Text="Nombre" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="6" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br/>
                            <p>
                                <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" OnClick="BuscarButton_Click" CssClass="btn btn-info" 
                                    OnClientClick="BorrarMensaje()" UseSubmitBehavior="false" />
                                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" CssClass="btn btn-info" 
                                    Text="Cancelar" PostBackUrl="~/Default.aspx" />
                            </p>
                            <p>
                                <asp:GridView ID="ProductosGridView" runat="server" SkinID="GrillaExploradores" AutoGenerateColumns="false"
                                    OnRowCommand="ProductosGridView_RowCommand" OnRowDataBound="ProductosGridView_RowDataBound"
                                    CssClass="grilla">
                                    <Columns>
                                        <asp:ButtonField HeaderText="" Text="Select" CommandName="Seleccionar" ButtonType="Link"
                                            ItemStyle-ForeColor="Blue" ItemStyle-Width="90px"></asp:ButtonField>
                                        <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" SortExpression="IdProducto"
                                            Visible="True">
                                            <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                            <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                            <HeaderStyle HorizontalAlign="center" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" Wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </p>
                            <p>
                                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                            </p>
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
