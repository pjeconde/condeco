<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExploradorProducto.aspx.cs" Inherits="Condeco.ExploradorProducto" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CondecoWebForm" Namespace="CondecoWebForm" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secExploradorProducto">
        <div class="container">
            <div class="row">
                <p>
                <span class="fa fa-2x fa-list"></span>
                </p>
                <h2 class="section-heading"> <asp:Label ID="TituloPaginaLabel" runat="server" Text="Explorador de Productos"></asp:Label></h2>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                <hr>
            </div>
        </div>
        <div class="container">
            <asp:Panel ID="PanelPPal" runat="server" DefaultButton="BuscarButton">
            <div class="row">
                <div class="col-md-3">
                    <p></p>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="IdProductoRadioButton" runat="server" AutoPostBack="true" Text=" Id.Producto"
                                        GroupName="TipoBusqueda" OnCheckedChanged="TipoBusquedaRadioButton_CheckedChanged"
                                        TabIndex="1" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="reIdProductoTextBox" ControlToValidate="IdProductoTextBox"
                                        ValidationExpression="[0-9]*" ErrorMessage="Solo números" Display="Dynamic" runat="server"
                                        SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="NombreRadioButton" runat="server" AutoPostBack="true" Text=" Nombre de Producto" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="6" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="DescripcionRadioButton" runat="server" AutoPostBack="true" Text=" Descripción de Producto" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="50" TabIndex="6" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" OnClick="BuscarButton_Click" CssClass="btn btn-info" 
                                        OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" CssClass="btn btn-info" 
                                        Text="Cancelar" PostBackUrl="~/Default.aspx" />
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <p></p>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                    <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderStyle="Solid" ScrollBars="Auto"
                        Width="100%" BackImageUrl="" BorderWidth="0px">
                        <cc1:PagingGridView ID="ProductosPagingGridView" runat="server" OnPageIndexChanging="ProductosPagingGridView_PageIndexChanging"
                            OnRowDataBound="ProductosPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown"
                            OnRowEditing="ProductosPagingGridView_RowEditing" OnRowCancelingEdit="ProductosPagingGridView_RowCancelingEdit"
                            OnRowUpdating="ProductosPagingGridView_RowUpdating" OnSorting="ProductosPagingGridView_Sorting"
                            AllowPaging="True" AllowSorting="True" PageSize="5" AutoGenerateColumns="false"
                            SkinID="GrillaGuide" OnRowCommand="ProductosPagingGridView_RowCommand" OnSelectedIndexChanged="ProductosPagingGridView_SelectedIndexChanged"
                            OnSelectedIndexChanging="ProductosPagingGridView_SelectedIndexChanging" DataKeyNames="TipoDestacado">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="CambiarEstado" runat="server" CausesValidation="false" CommandName="CambiarEstado"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Cambiar estado" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Modificar" runat="server" CausesValidation="false" CommandName="Modificar"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Modificar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" HeaderStyle-Width="100px"
                                    ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="200px"
                                    ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescripcionCorta" HeaderText="Descripción Corta" SortExpression="DescripcionCorta"
                                    ReadOnly="true" HeaderStyle-Width="250px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true"
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ranking" HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="50px"
                                    ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRanking" runat="server" Text='<%# Bind("Ranking") %>' MaxLength="2"
                                            Width="50px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="retxtRanking" ControlToValidate="txtRanking"
                                            ValidationExpression="[0-9]*" ErrorMessage="Solo Numeros" Display="Dynamic" runat="server"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Ranking")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Destacado" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTipoDestacado" runat="server" DataTextField="Descr" DataValueField="Id"
                                            Width="100px">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("TipoDestacado")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Update" OnClientClick="return confirm('Update?')"
                                            ValidationGroup="Update"></asp:LinkButton>
                                        <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                            ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
            </asp:Panel>
        </div>
    </section>
 
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    PopupControlID="ConfirmacionPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="ConfirmacionPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="ConfirmacionPanel" runat="server" CssClass="ModalWindow">
        <table style="background-color:Silver; width:100%">
            <tr>
                <td colspan="2">
                    <h4><asp:Label ID="TituloConfirmacionLabel" runat="server"></asp:Label></h4>
                </td>
            </tr>
            <tr>
                <td style="padding-right:5px; padding-left:5px; text-align:left;">
                    Nombre:
                </td>
                <td style="text-align:left;">
                    <asp:Label ID="NombreLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-right:5px; padding-left:5px; text-align:left;">
                    Descripción:
                </td>
                <td style="width:250px; text-align:left;">
                    <asp:Label ID="DescripcionLabel" runat="server"></asp:Label>
                </td>
            </tr>             
            <tr>
                <td style="padding-right:5px; padding-left:5px; text-align:left;">
                    Estado:
                </td>
                <td style="text-align:left;">
                    <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px; text-align:left;">
                    <asp:Button ID="CambiarEstadoButton" runat="server" Text="Confirmar" onclick="CambiarEstadoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                </td>
                <td style="padding-top:20px; text-align:left;">
                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
