﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoModificar.aspx.cs" Inherits="Condeco.ProductoModificar" Theme="Condeco" Culture="en-GB" UICulture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <script type="text/javascript">
        function ValidaDDL(source, arguments) {
            if (arguments.Value < 1) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        } 
    </script>
    <section class="bg-primary-white" id="secProductoCrear">
    <div class="container-fluid">
        <div class="row">
            <p>
                <span class="fa fa-2x fa-eye"></span>
            </p>
            <h2 class="section-heading">
                <asp:Label ID="TituloPaginaLabel" runat="server" Text="Modificación de Producto"></asp:Label></h2>
            <hr>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <p></p>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="panel panel-default" style="">
                        <div class="panel-body">
                            <div class="row">
                                <b>Id. <asp:Label ID="IdProductoLabel" runat="server"></asp:Label></b>
                                <asp:Label ID="EstadoActualLabel" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                            </div>
                            <hr class="HRnormal" />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NombreTextBox"
                                        ErrorMessage="Nombre" SetFocusOnError="True">
                                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="2" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DescripcionCortaTextBox"
                                        ErrorMessage="Descripción Corta" SetFocusOnError="True">
                                        <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label2" runat="server" Text="Descripción Corta"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <div class="containerClass">
                                        <asp:TextBox ID="DescripcionCortaTextBox" runat="server" TextMode="MultiLine" MaxLength="500"
                                            Height="200px" TabIndex="2" Width="100%"></asp:TextBox>
                                        <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="DescripcionCortaTextBox"
                                            runat="server" EnableSanitization="false" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DescripcionTextBox"
                                        ErrorMessage="Descripción" SetFocusOnError="True">
                                        <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="Label9" runat="server" Text="Descripción"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <div class="containerClass">
                                        <asp:TextBox ID="DescripcionTextBox" runat="server" TextMode="MultiLine" MaxLength="2000"
                                            Height="300px" TabIndex="2" Width="100%"></asp:TextBox>
                                        <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender2" TargetControlID="DescripcionTextBox"
                                            runat="server" EnableSanitization="false" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:RegularExpressionValidator ID="PrecioRegularExpressionValidator" runat="server"
                                        ControlToValidate="PrecioBaseTextBox" ErrorMessage="Error en el formato del precio"
                                        SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">
                                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:Label ID="Label11" runat="server" Text="Precio ($):"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="PrecioBaseTextBox" runat="server" MaxLength="16" TabIndex="501"
                                        Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="Label3" runat="server" Text="Información del precio"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="ComentarioPrecioBaseTextBox" runat="server" MaxLength="250" TextMode="MultiLine" Height="60px" TabIndex="502" Width="100%" style="resize: none;"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                                    &nbsp;(example: https://www.youtube.com/Condeco)
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="Label14" runat="server" Text="YouTube Dirección"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:TextBox ID="YouTubeTextBox" runat="server" MaxLength="60" TabIndex="502" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="Label15" runat="server" Text="Tipo de Producto"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:Panel ID="TipoProductoPanel" runat="server">
                                        <div id="TipoProductoDiv" runat="server">
                                            <ct:ASTreeView ID="astvMyTree" runat="server" BasePath="~/Javascript/astreeview/"
                                                DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="false" EnableCheckbox="true"
                                                EnableDragDrop="false" EnableTreeLines="true" EnableNodeIcon="false" EnableCustomizedNodeIcon="true"
                                                EnableContextMenu="false" EnableDebugMode="false" EnableContextMenuAdd="false"
                                                OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                                                OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                                                EnableEscapeInput="false" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                    <asp:Label ID="Label17" runat="server" Text="Estado"></asp:Label>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                                    <asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="501" Width="100%"
                                        DataValueField="Id" DataTextField="Descr">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Button ID="AceptarButton" runat="server" TabIndex="502" Text="Aceptar" OnClick="AceptarButton_Click" CssClass="btn btn-info" />
                                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="503" CssClass="btn btn-info" 
                                        Text="Cancelar" PostBackUrl="~/Default.aspx" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
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
    <table>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 5px">
                
            </td>
            <td align="left" style="padding-top: 5px">

            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
               
            </td>
        </tr>
    </table>
</asp:Content>