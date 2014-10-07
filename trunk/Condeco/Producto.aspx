<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Producto.aspx.cs" Inherits="Condeco.Producto" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>

<%@ Register Assembly="CondecoWebForm" Namespace="CondecoWebForm" TagPrefix="cc1" %>

<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: none;">
        <tr>
            <td>
                <asp:Panel runat="server" ID="Buscador" DefaultButton="BuscarButton">
                <table border="0" class="ppaltable" cellpadding="0" cellspacing="0" style="background-position: 0px; background-image: url('Imagenes/Productos.jpg'); width: 820px; background-repeat: no-repeat;">
                    <tr>
                        <td colspan="5">
                            <table border="0" cellpadding="0" cellspacing="0" width="780">
                                <tr>
                                    <td>
                                        <h2>
                                            Catálogo de Productos
                                        </h2>
                                        <p> </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-right: 5px; padding-top: 2px">
                            <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="text-align: left">
                            <div>
		                        <ct:ASTreeView ID="astvMyTree" 
				                    runat="server"
				                    BasePath="~/Javascript/astreeview/"
				                    DataTableRootNodeValue="0"
				                    EnableRoot="false" 
				                    EnableNodeSelection="false" 
				                    EnableCheckbox="true" 
				                    EnableDragDrop="false" 
				                    EnableTreeLines="true"
				                    EnableNodeIcon="false"
				                    EnableCustomizedNodeIcon="true"
				                    EnableContextMenu="true"
				                    EnableDebugMode="false"
				                    EnableContextMenuAdd="false"
				                    OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
				                    OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
				                    OnNodeDragAndDropStartScript="dndStartHandler( elem )"
				                    EnableMultiLineEdit="false"
				                    EnableEscapeInput="false" />
                            </div>
                            </td>
                            </tr>
                            </table>
                        </td>
                        <td style="padding-right: 30px">
                        </td>
                        <td colspan="2" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 2px">
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="6" Width="280px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 2px">
                                        <asp:Label ID="DescripcionLabel" runat="server" Text="Descripción"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="50" TabIndex="6" Width="280px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="right" style="height: 24px; padding-top: 20px; text-align: center">
                            <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Aplicar filtro" ToolTip="Muestra los productos acorde a los filtros seleccionados" OnClick="BuscarButton_Click" UseSubmitBehavior="false" />
                            <asp:Button ID="ClearButton" runat="server" TabIndex="8" Text="Limpiar filtro" ToolTip="Muestra todos los productos" OnClick="ClearButton_Click"  UseSubmitBehavior="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px; padding-right: 30px; width: 100%">
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td align="right">
                                        <asp:RadioButton ID="Vista1RadioButton" runat="server" AutoPostBack="True"
                                            Text="Vista 1" GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" />&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="Vista2RadioButton" runat="server" AutoPostBack="True" Text="Vista 2" Checked="true"
                                            GroupName="Vistas" OnCheckedChanged="VistaRadioButton_CheckedChanged" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
        <tr>
            <td>
                <asp:Panel ID="PanelPagingGridView" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px; width: 800px;">
                        <tr>
                            <td style="padding-top: 0px; padding-bottom: 10px">
                                <hr noshade="noshade" size="1" color="gray" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderColor="white" BorderStyle="Solid"
                                    BorderWidth="0px" ScrollBars="Auto" Width="800px" BackImageUrl="">
                                    <cc1:PagingGridView ID="ProductoPagingGridView" runat="server" OnPageIndexChanging="ProductoPagingGridView_PageIndexChanging"
                                        OnRowDataBound="ProductoPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown"
                                        OnSorting="ProductoPagingGridView_Sorting" AllowPaging="True" AllowSorting="True" 
                                        PageSize="5" AutoGenerateColumns="false" SkinID="GrillaGuide" OnRowCommand="ProductoPagingGridView_RowCommand"
                                        OnSelectedIndexChanged="ProductoPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ProductoPagingGridView_SelectedIndexChanging"
                                        BackColor="white" CssClass="TextDecorationNone">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                <HeaderStyle Wrap="False" BackColor="white"  />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip='<%# String.Format("{0}{1}", "Row ", ((GridViewRow) Container).RowIndex + 1)%>'
                                                        Text="Detalle"  BorderColor="Gray" ForeColor="Black" Width="50px" Font-Bold="False"
                                                        CssClass="TextoCenter" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="200px">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" BackColor="white" CssClass="TextDecorationNone" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" CssClass="TextDecorationNone" BorderColor="Gray" ForeColor="Black"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" Width="100%"  BackColor="white" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" CssClass="TextDecorationNone" BorderColor="Gray" ForeColor="Black" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" />
                                    </cc1:PagingGridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <asp:Panel ID="PanelListView" runat="server" BackColor="White">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px; vertical-align: top">
                        <tr>
                            <td style="padding-bottom: 10px; background-color:white">
                                <hr noshade="noshade" size="1" color="gray" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-bottom: 10px; width: 800px; vertical-align: top">
                                <asp:ListView ID="ProductoListView" runat="server" OnPagePropertiesChanging="ProductoListView_PagePropertiesChanging"
                                    GroupItemCount="2">
                                    <LayoutTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table style="text-align: left; vertical-align: top">
                                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <tr id="groupPlaceHolder">
                                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                                        </tr>
                                    </GroupTemplate>
                                    <ItemTemplate>
                                        <td id="itemPlaceHolder" style="text-align: left; vertical-align: top;">
                                            <table border="0" cellspacing="0px">
                                                <tr>
                                                    <td style="width: 380px; vertical-align: top">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="NombreLabel" runat="server" SkinID="TituloColor1Grande" Text='<%# Eval("Nombre") %>'
                                                                        CssClass='<%# Eval("TipoDestacado").ToString()=="01" || Eval("TipoDestacado").ToString()=="02" ? "myClass01" : "myClass"%>'
                                                                        Width="300px" />
                                                                </td>
                                                                <td style="padding-top: 5px">
                                                                    <asp:Image ID="ImagenRecomendada" runat="server" ImageUrl='<%# Eval("TipoDestacado").ToString()=="02" ? "~/Imagenes/Estrella.jpg" : "~/Imagenes/Iconos/PuntoW.jpg"%>'
                                                                        Width="25px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table border="0">
                                                            <tr>
                                                                <td class="TituloMediano" style="width: 100px" rowspan="4" valign="top">
                                                                    <asp:LinkButton ID="lportada" runat="server" OnClick="lportada_Click" CommandArgument='<%# Eval("Id") %>'
                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                        <asp:Image ID="ImagenPortada" runat="server" ImageUrl='<%# String.Format("~/ImagenesProducto/Portada/{0}", Eval("NombreImagenPortada"))%>'
                                                                            Width="100px" />
                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top">
                                                                    <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>'
                                                                        Width="280px" CssClass='<%# Eval("TipoDestacado").ToString()=="02" ? "myClass02" : "myClass"%>' />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: bottom">
                                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </ItemTemplate>
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
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px">
        <tr>
            <td align="center" style="padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
