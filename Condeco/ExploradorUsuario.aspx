<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExploradorUsuario.aspx.cs" Inherits="Condeco.ExploradorUsuario" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CondecoWebForm" Namespace="CondecoWebForm" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <section class="bg-primary-white" id="secExploradorUsuario">
        <div class="container">
            <div class="row">
                <p>
                <span class="fa fa-2x fa-users"></span>
                </p>
                <h3><asp:Label ID="TituloPaginaLabel" runat="server" Text="Explorador de Usuarios"></asp:Label></h3>
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
                                    <asp:RadioButton ID="IdUsuarioRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="7" Width="100%"></asp:TextBox>
                                    <asp:RegularExpressionValidator id="reIdUsuarioTextBox" ControlToValidate="IdUsuarioTextBox" ValidationExpression="[A-Za-z\- ,.0-9]*" ErrorMessage="Solo números" Display="Dynamic" runat="server" SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
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
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RadioButton ID="EmailRadioButton" runat="server" AutoPostBack="true" Text="Email" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="50" TabIndex="6" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="BorrarMensaje()" UseSubmitBehavior="false" CssClass="btn btn-info" />
                                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" PostBackUrl="~/Default.aspx" CssClass="btn btn-info" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderStyle="Solid" ScrollBars="Auto"
                                        Width="100%" BackImageUrl="" BorderWidth="0px">
                                        <cc1:PagingGridView ID="UsuariosPagingGridView" runat="server" OnPageIndexChanging="UsuariosPagingGridView_PageIndexChanging"
                                            OnRowDataBound="UsuariosPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown"
                                            OnRowEditing="UsuariosPagingGridView_RowEditing" OnRowCancelingEdit="UsuariosPagingGridView_RowCancelingEdit"
                                            OnRowUpdating="UsuariosPagingGridView_RowUpdating" OnSorting="UsuariosPagingGridView_Sorting"
                                            AllowPaging="True" AllowSorting="True" PageSize="5" AutoGenerateColumns="false"
                                            SkinID="GrillaGuide" OnRowCommand="UsuariosPagingGridView_RowCommand" BorderColor="Gray"
                                            OnSelectedIndexChanged="UsuariosPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="UsuariosPagingGridView_SelectedIndexChanging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle BorderColor="Gray" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                                            Text="Detalle" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle BorderColor="Gray" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="CambiarEstado" runat="server" CausesValidation="false" CommandName="CambiarEstado"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                                            Text="Cambiar estado" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle BorderColor="Gray" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Modificar" runat="server" CausesValidation="false" CommandName="Modificar"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>"
                                                            Text="Modificar" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="200px"
                                                    ReadOnly="true">
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderColor="Gray" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="true"
                                                    HeaderStyle-Width="250px">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderColor="Gray" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true"
                                                    HeaderStyle-Width="100px">
                                                    <HeaderStyle Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderColor="Gray" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" />
                                        </cc1:PagingGridView>
                                    </asp:Panel>
                                </div>
                            </div>
                            <br />
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
        <table style="width:100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="TituloConfirmacionLabel" runat="server"></asp:Label>
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
                    Email:
                </td>
                <td style="width:250px; text-align:left;">
                    <asp:Label ID="EmailLabel" runat="server"></asp:Label>
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
                <td style="padding-top:20px;text-align:left;">
                    <asp:Button ID="CambiarEstadoButton" runat="server" Text="Confirmar" onclick="CambiarEstadoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                </td>
                <td style="padding-top:20px;text-align:left;">
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
