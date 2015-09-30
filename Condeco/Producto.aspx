<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Producto.aspx.cs" Inherits="Condeco.Producto" Culture="en-GB" UICulture="en-GB" %>

<%@ Register Assembly="CondecoWebForm" Namespace="CondecoWebForm" TagPrefix="cc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-info" style="background-color: White" id="secProductos">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                    <p>
                    <span class="fa fa-2x fa-list-alt"></span>
                    </p>
                    <h2 class="section-heading"> Catálogo de Productos</h2>
                    <hr>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <asp:Panel runat="server" ID="Buscador" DefaultButton="BuscarButton">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 text-left">
                                        <div class="row">
                                            <table style="border: 0; padding: 20px; width: 100%;">
                                                <tr>
                                                    <td style="text-align: left; min-width: 200px;">
                                                        <ct:ASTreeView ID="astvMyTree" runat="server" BackColor="Gray" BasePath="~/Javascript/astreeview/"
                                                            DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="false" EnableCheckbox="true"
                                                            EnableDragDrop="false" EnableTreeLines="true" EnableNodeIcon="false" EnableCustomizedNodeIcon="true"
                                                            EnableContextMenu="true" EnableDebugMode="false" EnableContextMenuAdd="false"
                                                            OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                                                            OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                                                            EnableEscapeInput="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                                <br />
                                                <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                                <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" Width="100%" TabIndex="6"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                                <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                                <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="50" Width="100%" TabIndex="7"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row control-group">
                                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                                <input type="text" runat="server" class="form-control" placeholder="Nombre" id="ContactoNombre"
                                                    required data-validation-required-message="Por favor ingrese su nombre." visible="false">
                                                <p class="help-block text-danger">
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    <div class="row">
                                        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" TabIndex="8"
                                            Text="Aplicar filtro" ToolTip="Muestra los productos acorde a los filtros seleccionados"
                                            OnClick="BuscarButton_Click" UseSubmitBehavior="false" />
                                        <asp:Button ID="ClearButton" runat="server" CssClass="btn btn-info" TabIndex="9"
                                            Text="Limpiar filtro" ToolTip="Muestra todos los productos" OnClick="ClearButton_Click"
                                            UseSubmitBehavior="false" />
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:RadioButton ID="Vista1RadioButton" runat="server" AutoPostBack="True" Text="Vista 1"
                                            GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" Checked="true" />&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="Vista2RadioButton" runat="server" AutoPostBack="True" Text="Vista 2"
                                            GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" />
                                    </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <asp:Panel ID="PanelPagingGridView" runat="server">
                        <table class="table" style="padding: 20px;">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderColor="white" BorderStyle="None"
                                        BorderWidth="0px" ScrollBars="Auto">
                                        <cc1:PagingGridView ID="ProductoPagingGridView" runat="server" OnPageIndexChanging="ProductoPagingGridView_PageIndexChanging"
                                            OnRowDataBound="ProductoPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown"
                                            OnSorting="ProductoPagingGridView_Sorting" AllowPaging="True" AllowSorting="True"
                                            PageSize="5" AutoGenerateColumns="false" SkinID="GrillaGuide" OnRowCommand="ProductoPagingGridView_RowCommand"
                                            OnSelectedIndexChanged="ProductoPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ProductoPagingGridView_SelectedIndexChanging"
                                            BackColor="white">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="true" BackColor="white" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip='<%# String.Format("{0}{1}", "Row ", ((GridViewRow) Container).RowIndex + 1)%>'
                                                            Text="Detalle" BorderColor="Gray" ForeColor="Black" Width="60px" Font-Bold="False"
                                                            CssClass="TextoCenter" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="30%" BorderColor="Gray" ForeColor="Black" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="70%" BorderColor="Gray" ForeColor="Black" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" />
                                        </cc1:PagingGridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelListView" runat="server" BackColor="white">
                        <table style="border:0; padding: 20px;">
                            <tr>
                                <td style="padding-top: 10px; padding-bottom: 10px; vertical-align: top">
                                    <asp:ListView ID="ProductoListView" runat="server" OnPagePropertiesChanging="ProductoListView_PagePropertiesChanging" GroupItemCount="2">
                                        <LayoutTemplate>
                                            <div>
                                                <asp:PlaceHolder runat="server" ID="groupPlaceholder"></asp:PlaceHolder>
                                            </div>
                                        </LayoutTemplate>
                                        <GroupTemplate>
                                            <div class="row">
                                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                            </div>
                                        </GroupTemplate>
                                        <ItemTemplate>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <div class="panel panel-default">
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 text-right">
                                                                <asp:LinkButton ID="lportada" runat="server" OnClick="lportada_Click" CommandArgument='<%# Eval("Id") %>'
                                                                    ToolTip='<%# Eval("Id") %>'>
                                                                    <asp:Image ID="ImagenPortada" runat="server" ImageUrl='<%# String.Format("~/ImagenesProducto/Portada/{0}", Eval("NombreImagenPortada"))%>'
                                                                        style="width:100%" />
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 text-left">
                                                                <asp:Image ID="ImagenRecomendada" runat="server" ImageUrl='<%# Eval("TipoDestacado").ToString()=="02" ? "~/Imagenes/Estrella.jpg" : "~/Imagenes/Iconos/PuntoW.jpg"%>'
                                                                Width="5px" />
                                                                <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' CssClass='<%# Eval("TipoDestacado").ToString()=="01" || Eval("TipoDestacado").ToString()=="02" ? "myClass01" : "myClass"%>' />
                                                                <br />
                                                                Precio: <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("PrecioBase").ToString()=="0" ? "consultar precio" : "$ "+Eval("PrecioBase") %>'
                                                                    CssClass='<%# Eval("TipoDestacado").ToString()=="02" ? "myClass02" : "myClass"%>' />
                                                            </div>
                                                        </div>
                                                        <div class="row text-left">
                                                            <table style="padding:20px;">
                                                                <tr>
                                                                    <td style="padding-left: 20px; padding-right: 20px; padding-top: 10px;">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("DescripcionCorta") %>' CssClass='<%# Eval("TipoDestacado").ToString()=="02" ? "myClass02" : "myClass"%>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <div>
                                                No hay productos disponibles con ese filtro.
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ProductoListView">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="false"
                                                PreviousPageText="<" FirstPageText="<<" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="false"
                                                NextPageText=">" LastPageText=">>" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table style="padding-left: 10px;border: 0;">
                        <tr>
                            <td align="center" style="padding-top: 20px">
                                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <p>
                        <a href="Default.aspx" class="btn btn-primary btn-xl">Home</a>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
