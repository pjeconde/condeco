<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExploradorProducto.aspx.cs" Inherits="Condeco.ExploradorProducto" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CondecoWebForm" Namespace="CondecoWebForm" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <asp:Panel ID="PanelPPal" runat="server" DefaultButton="BuscarButton">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Productos"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                <asp:RadioButton ID="IdProductoRadioButton" runat="server" AutoPostBack="true" Text="Id.Producto" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1"/>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="7" Width="300px"></asp:TextBox>
                <asp:RegularExpressionValidator id="reIdProductoTextBox" ControlToValidate="IdProductoTextBox" ValidationExpression="[0-9]*" ErrorMessage="Solo números" Display="Dynamic" runat="server" SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
            </td>        
            <td>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                <asp:RadioButton ID="NombreRadioButton" runat="server" AutoPostBack="true" Text="Nombre de Producto" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
            </td>        
            <td>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                <asp:RadioButton ID="DescripcionRadioButton" runat="server" AutoPostBack="true" Text="Descripción de Producto" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="DescripcionTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
            </td>        
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" BackColor="white" BorderStyle="Solid"  
                        ScrollBars="Auto" Width="800px" BackImageUrl="" BorderWidth="0px">
                        <cc1:PagingGridView ID="ProductosPagingGridView" runat="server" OnPageIndexChanging="ProductosPagingGridView_PageIndexChanging"
                            OnRowDataBound="ProductosPagingGridView_RowDataBound" FooterStyle-ForeColor="Brown" OnRowEditing="ProductosPagingGridView_RowEditing" OnRowCancelingEdit="ProductosPagingGridView_RowCancelingEdit"
                            OnRowUpdating="ProductosPagingGridView_RowUpdating" OnSorting="ProductosPagingGridView_Sorting" AllowPaging="True" AllowSorting="True" PageSize="5" 
                            AutoGenerateColumns="false" SkinID="GrillaGuide" OnRowCommand="ProductosPagingGridView_RowCommand"
                            OnSelectedIndexChanged="ProductosPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ProductosPagingGridView_SelectedIndexChanging"
                            DataKeyNames="TipoDestacado">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton Id="CambiarEstado" runat="server" CausesValidation="false" CommandName="CambiarEstado"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Cambiar estado" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton Id="Modificar" runat="server" CausesValidation="false" CommandName="Modificar"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Modificar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="200px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescripcionCorta" HeaderText="Descripción Corta" SortExpression="DescripcionCorta" ReadOnly="true" 
                                    HeaderStyle-Width="250px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ranking" HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="50px" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRanking" runat="server" Text='<%# Bind("Ranking") %>'
                                            MaxLength="2" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator id="retxtRanking" ControlToValidate="txtRanking" ValidationExpression="[0-9]*" ErrorMessage="Solo Numeros" Display="Dynamic" runat="server" SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Ranking")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Destacado" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTipoDestacado" runat="server" DataTextField="Descr" DataValueField="Id" Width="100px">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("TipoDestacado")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                    <HeaderStyle Wrap="False" Font-Bold="false" />
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  
                                            Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                                        <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                            ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </cc1:PagingGridView>
                    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    PopupControlID="ConfirmacionPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="ConfirmacionPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="ConfirmacionPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nombre:
                </td>
                <td align="left">
                    <asp:Label ID="NombreLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Descripción:
                </td>
                <td align="left" style="width:250px">
                    <asp:Label ID="DescripcionLabel" runat="server"></asp:Label>
                </td>
            </tr>             
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Estado:
                </td>
                <td align="left">
                    <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CambiarEstadoButton" runat="server" Text="Confirmar" onclick="CambiarEstadoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                </td>
                <td align="left" style="padding-top:20px">
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
