<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoSeleccionar.aspx.cs" Inherits="Condeco.ProductoSeleccionar" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <asp:Panel ID="Panel2" runat="server" DefaultButton="BuscarButton">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? Producto"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="IdProductoRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1"/>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="7" Width="300px"></asp:TextBox>
                </td>        
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="NombreRadioButton" runat="server" AutoPostBack="true" Text="Nombre" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2"/>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
                </td>        
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:20px">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Search" 
                        onclick="BuscarButton_Click" OnClientClick="BorrarMensaje()" 
                        UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" 
                        TabIndex="9" Text="Cancel" PostBackUrl="~/Default.aspx" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px;" colspan="3">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="None">
                        <asp:GridView ID="ProductosGridView" runat="server" SkinID="GrillaExploradores" 
                            AutoGenerateColumns="false" onrowcommand="ProductosGridView_RowCommand" 
                            OnRowDataBound="ProductosGridView_RowDataBound" CssClass="grilla">
                            <Columns>
                                <asp:ButtonField HeaderText="" Text="Select" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" SortExpression="IdProducto" Visible="True">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
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
