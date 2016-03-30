<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Producto.aspx.cs" Inherits="Condeco.Producto" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

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
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left" style="padding-bottom:10px">
                                        <div class="row">
                                            <table style="padding: 20px; width: 100%;">
                                                <tr>
                                                    <td style="text-align: left; min-width: 200px;">
                                                        <ct:ASTreeView ID="astvMyTree" runat="server" BackColor="Gray" BasePath="~/Javascript/astreeview/"
                                                            DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="false" EnableCheckbox="true"
                                                            EnableDragDrop="false" EnableTreeLines="true" EnableNodeIcon="false" EnableCustomizedNodeIcon="true"
                                                            EnableContextMenu="true" EnableDebugMode="false" EnableContextMenuAdd="false" Visible="false"
                                                            OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                                                            OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                                                            EnableEscapeInput="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center" style="padding-bottom:10px;">
                                        <div class="row">
                                            <asp:LinkButton ID="MarcosLinkButton" class="btn btn-xs" runat="server" CommandName="Marcos" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Marcos&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="CartelesLinkButton" class="btn btn-xs" runat="server" CommandName="Carteles" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Carteles&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="MesasLinkButton" class="btn btn-xs" runat="server" CommandName="Mesas" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Mesas&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="CarasLinkButton" class="btn btn-xs" runat="server" CommandName="Caras" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Caras&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="PecesLinkButton" class="btn btn-xs" runat="server" CommandName="Peces" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Peces&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="BarcosLinkButton" class="btn btn-xs" runat="server" CommandName="Barcos" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Barcos&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="CuadrosLinkButton" class="btn btn-xs" runat="server" CommandName="Cuadros" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Cuadros&nbsp;</asp:LinkButton>
                                            <asp:LinkButton ID="OtrosObjetosLinkButton" class="btn btn-xs" runat="server" CommandName="OtrosObjetos" OnClick="BuscarDirectoButton_Click" style="">&nbsp;Otros&nbsp;Objetos&nbsp;</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center" style="padding-bottom:10px;">
                                        <div class="row">
                                            <div class="input-group" style="padding-left: 10px">
                                                <input id="DescripcionTextBox" runat="server" type="text" class="form-control" placeholder="Buscar texto...">
                                                <span class="input-group-btn">
                                                    <button id="BuscarBtn" runat="server" class="btn btn-link" type="button" onserverclick="BuscarButton_Click"><span class="fa fa-search"></span></button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" TabIndex="8"
                                        Text="Buscar" ToolTip="Muestra los productos acorde a los filtros seleccionados"
                                        OnClick="BuscarButton_Click" UseSubmitBehavior="false" />
                                    <asp:Button ID="ClearButton" runat="server" CssClass="btn btn-info" TabIndex="9"
                                        Text="Ver Todo" ToolTip="Muestra todos los productos" OnClick="ClearButton_Click"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div ID="divVistas" runat="server" class="row">
                                    <br />
                                    <asp:RadioButton ID="Vista1RadioButton" runat="server" AutoPostBack="True" Text="Vista 1"
                                        GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" Checked="true" />&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="Vista2RadioButton" runat="server" AutoPostBack="True" Text="Vista 2"
                                        GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Panel ID="PanelPagingGridView" runat="server">
                        <table style="padding: 20px; width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderColor="white" BorderStyle="None"
                                        BorderWidth="0px" ScrollBars="Auto">
                                        <cc1:PagingGridView ID="ProductoPagingGridView" runat="server" OnPageIndexChanging="ProductoPagingGridView_PageIndexChanging"
                                            OnRowDataBound="ProductoPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown"
                                            OnSorting="ProductoPagingGridView_Sorting" AllowPaging="True" AllowSorting="True"
                                            PageSize="10" AutoGenerateColumns="false" SkinID="GrillaGuide" OnRowCommand="ProductoPagingGridView_RowCommand"
                                            OnSelectedIndexChanged="ProductoPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ProductoPagingGridView_SelectedIndexChanging"
                                            BackColor="white">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top" HeaderText="Ver">
                                                    <HeaderStyle BackColor="white" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip='<%# String.Format("{0}{1}", "Ver Detalle Fila ", ((GridViewRow) Container).RowIndex + 1)%>'
                                                            Text="Detalle" BorderColor="Gray" ForeColor="Black" Width="60px" Font-Bold="False"
                                                            CssClass="TextoCenter" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top" HeaderText="Imagen">
                                                    <HeaderStyle BackColor="white" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image" runat="server" ImageUrl=<%# "ImagenesProducto/Portada/" + Eval("Id") + ".jpg" %> width="100px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="10%" BorderColor="Gray" ForeColor="Black" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="30%" BorderColor="Gray" ForeColor="Black" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" HtmlEncode="false">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="60%" BorderColor="Gray" ForeColor="Black" />
                                                </asp:BoundField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="true" BackColor="white" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Modificar" runat="server" CausesValidation="false" CommandName="Modificar"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip='<%# String.Format("{0}{1}", "Modificar Fila ", ((GridViewRow) Container).RowIndex + 1)%>'
                                                            Text="Clonar" BorderColor="Gray" ForeColor="Black" Width="60px" Font-Bold="False"
                                                            CssClass="TextoCenter">
                                                            <span class='fa fa-1-5x fa-edit' style='padding-right:5px'></span>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="true" BackColor="white" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Clonar" runat="server" CausesValidation="false" CommandName="Clonar"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip='<%# String.Format("{0}{1}", "Clonar Fila ", ((GridViewRow) Container).RowIndex + 1)%>'
                                                            Text="Clonar" BorderColor="Gray" ForeColor="Black" Width="60px" Font-Bold="False"
                                                            CssClass="TextoCenter">
                                                            <span class='fa fa-1-5x fa-copy' style='padding-right:5px'></span>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" />
                                        </cc1:PagingGridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Panel ID="PanelListView" runat="server" BackColor="white">
                        <asp:ListView ID="ProductoListView" runat="server" OnPagePropertiesChanging="ProductoListView_PagePropertiesChanging">
                            <LayoutTemplate>
                                <div class="container-fluid">
                                    <div class="row">
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="col-lg-4 col-sm-6 col-xs-12" runat="server">
                                    <div class="panel panel-default" runat="server">
                                        <div class="panel-body" runat="server">
                                            <div class="row" style="min-height: 280px;">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left" style="padding-bottom: 10px">
                                                    <asp:Image ID="ImagenRecomendada" runat="server" ImageUrl='<%# Eval("TipoDestacado").ToString()=="02" ? "~/Imagenes/Estrella.jpg" : "~/Imagenes/Iconos/PuntoW.jpg"%>'
                                                        Width="5px" />
                                                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' CssClass='<%# Eval("TipoDestacado").ToString()=="01" || Eval("TipoDestacado").ToString()=="02" ? "myClass01" : "myClass"%>' />
                                                    <font style="font-family: Sans-Serif; font-size: smaller"><b>&nbsp;&nbsp;
                                                    <asp:Label ID="CodLabel" runat="server" Text='<%# "(cod."+Eval("Id")+")"%>'></asp:Label>
                                                    </b></font>
                                                </div>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left" style="padding-bottom: 10px">
                                                    <asp:LinkButton ID="lportada" runat="server" OnClick="lportada_Click" CommandArgument='<%# Eval("Id") %>'
                                                        ToolTip='<%# Eval("Id") %>'>
                                                        <asp:Image ID="ImagenPortada" runat="server" ImageUrl='<%# String.Format("~/ImagenesProducto/Portada/{0}", Eval("NombreImagenPortada"))%>'
                                                            Style="width: 100%;" />
                                                    </asp:LinkButton>
                                                </div>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left">
                                                    <table style="padding: 0px;">
                                                        <tr>
                                                            <td style="padding-left: 0px; padding-right: 20px; vertical-align: text-top">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("DescripcionCorta") %>' CssClass='<%# Eval("TipoDestacado").ToString()=="02" ? "myClass02" : "myClass"%>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-footer" runat="server">
                                            <div class="container" runat="server">
                                                <div Id="ProdFooter" class="row text-left" runat="server">
                                                    Precio: <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("PrecioBase").ToString()=="0" ? "consultar precio" : "$ "+Eval("PrecioBase") %>'
                                                    CssClass='<%# Eval("TipoDestacado").ToString()=="02" ? "myClass02" : "myClass"%>' />
                                                    &nbsp;
                                                    <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                                                </div>
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
                        <br />
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ProductoListView" 
                            PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="false"
                                    PreviousPageText="<" FirstPageText="<<" />
                                <asp:NumericPagerField ButtonType="Link" />
                                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="false"
                                    NextPageText=">" LastPageText=">>" />
                            </Fields>
                        </asp:DataPager>
                    </asp:Panel>
                </div>
            </div>
            <table style="padding-left: 10px;border: 0;">
                <tr>
                    <td style="padding-top: 20px; text-align: center">
                        <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <p>
                <a href="Default.aspx" class="btn btn-primary btn-xl">Home</a>
            </p>
        </div>
    </section>
</asp:Content>
