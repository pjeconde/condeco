<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoConsultaDetallada.aspx.cs" Inherits="Condeco.ProductoConsultaDetallada" Theme="Condeco" Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainCPH" runat="server">
    <script type='text/javascript'>
    //<![CDATA[

        /* Expando Image Script 2008 John Davenport Scheuer
        as first seen in http://www.dynamicdrive.com/forums/
        username: jscheuer1 - This Notice Must Remain for Legal Use
        */
        if (document.images) 
        {
            (function () {
                var cos, a = /Apple/.test(navigator.vendor), times = a ? 20 : 40, speed = a ? 40 : 20;
                var expConIm = function (im) {
                    im = im || window.event;
                    if (!expConIm.r.test(im.className))
                        im = im.target || im.srcElement || null;
                    if (!im || !expConIm.r.test(im.className))
                        return;
                    var e = expConIm,
                    widthHeight = function (dim) {
                        return dim[0] * cos + dim[1] + 'px';
                    },
                    resize = function () {
                        cos = (1 - Math.cos((e.ims[i].jump / times) * Math.PI)) / 2;
                        im.style.width = widthHeight(e.ims[i].w);
                        im.style.height = widthHeight(e.ims[i].h);
                        if (e.ims[i].d && times > e.ims[i].jump) {
                            ++e.ims[i].jump;
                            e.ims[i].timer = setTimeout(resize, speed);
                        }
                        else if (!e.ims[i].d && e.ims[i].jump > 0) {
                            --e.ims[i].jump;
                            e.ims[i].timer = setTimeout(resize, speed);
                        }
                    }, d = document.images, i = d.length - 1;
                    for (i; i > -1; --i)
                        if (d[i] == im) break;
                    i = i + im.src;
                    if (!e.ims[i]) {
                        im.title = '';
                        e.ims[i] = { im: new Image(), jump: 0 };
                        e.ims[i].im.onload = function () {
                            e.ims[i].w = [e.ims[i].im.width - im.width, im.width];
                            e.ims[i].h = [e.ims[i].im.height - im.height, im.height];
                            e(im);
                        };
                        e.ims[i].im.src = im.src;
                        return;
                    }
                    if (e.ims[i].timer) clearTimeout(e.ims[i].timer);
                    e.ims[i].d = !e.ims[i].d;
                    resize();
                };

                expConIm.ims = {};

                expConIm.r = new RegExp('\\bexpando\\b');

                if (document.addEventListener) {
                    document.addEventListener('mouseover', expConIm, false);
                    document.addEventListener('mouseout', expConIm, false);
                }
                else if (document.attachEvent) {
                    document.attachEvent('onmouseover', expConIm);
                    document.attachEvent('onmouseout', expConIm);
                }
            })();
        }
    //]]>
    </script>
    <table border="0" cellpadding="0" cellspacing="0" 
        style="padding-left:10px; vertical-align:top; background-image: url('Imagenes/Detallada.jpg'); background-repeat: no-repeat;">
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Detalle del Producto"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top: 10px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="vertical-align: top; padding-left: 20px;">
                <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top">
                    <tr>
                        <td align="right" style="padding-right: 5px; vertical-align: top">
                            <asp:Label ID="Label7" runat="server" Text="Id." Visible="false"></asp:Label>
                        </td>
                        <td align="left" style="padding-top: 5px; vertical-align: top">
                            <asp:TextBox ID="IdProductoTextBox" runat="server" MaxLength="50" TabIndex="4" Width="150px"
                                Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-right: 5px; padding-top: 5px">
                            <asp:Label ID="Label9" runat="server" Text="Producto" SkinID="TituloColor1Grande"></asp:Label>
                            <%if (TipoProductoLabel.Text != "") {%><asp:Label ID="TipoProductoLabel" runat="server" Visible="false"></asp:Label>
                            <%}%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-top: 2px;">
                            <b>
                            <asp:Label ID="NombreLabel" runat="server" Text=""></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-top: 2px;">
                            <asp:Label ID="DescripcionLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <%if (PrecioBaseLabel.Text != "")
                      {%>
                    <tr>
                        <td align="left" colspan="2" style="padding-right: 5px; padding-top: 5px">
                            Precio: $ 
                            <asp:Label ID="PrecioBaseLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%} %>
                    <%if (ComentarioPrecioBaseLabel.Text != "") 
                      {%>
                    <tr>
                        <td align="left" colspan="2" style="padding-right: 5px; padding-top: 5px">
                            Comentario:
                            <asp:Label ID="ComentarioPrecioBaseLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%} %>
                    <!-- Info.Web -->
                    <%if (YouTubeLabel.Text != "")
                      {%>
                    <tr>
                        <td align="left" colspan="2" style="padding-top: 5px" valign="top">
                            YouTube:
                            <asp:Label ID="YouTubeLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="vertical-align: top; padding-left: 20px;" class="style2">
                <!-- Imagenes -->
                <table border="0" cellpadding="0" cellspacing="0" style="padding-left:0px">
                    <tr>
                        <td align="left" style="padding-right: 5px; padding-top: 5px; vertical-align: top">
                            <asp:Label ID="Label4" runat="server" Text="Imagenes" SkinID="TituloColor1Grande"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 0px">
                                <tr>
                                    <td align="left" style="padding-right: 25px; padding-top: 5px; vertical-align: top">
                                        <a id="linkPortada" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg" target="_blank">
                                            <asp:Image ID="ImagePortada" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                                <span><asp:Image ID="ImagePortadaAmpliada" runat="server" BorderStyle="Solid" BorderWidth="1px"  
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg"  Width="290px" /></span>
                                        </a>
                                    </td>
                                    <td align="left" style="padding-right: 25px; padding-top: 5px; vertical-align: top">
                                        <a id="linkImage1" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg" target="_blank">
                                            <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px"  
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                                <span><asp:Image ID="Image1Ampliada" runat="server" BorderStyle="Solid" BorderWidth="1px"  
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg"  Width="290px" /></span>
                                        </a>
                                    </td>
                                    <td align="left" style="padding-right: 25px; padding-top: 5px; vertical-align: top">
                                        <a id="linkImage2" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg" target="_blank">
                                            <asp:Image ID="Image2" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                                <span><asp:Image ID="Image2Ampliada" runat="server" BorderStyle="Solid" BorderWidth="1px"  
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg"  Width="290px" /></span>
                                        </a>
                                    </td>
                                    <td align="left" style="padding-right: 25px; padding-top: 5px; vertical-align: top">
                                        <a id="linkImage3" class="thumbnail" runat="server" href="Imagenes/Interrogacion.jpg" target="_blank">
                                            <asp:Image ID="Image3" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg" Width="90px" />
                                                <span><asp:Image ID="Image3Ampliada" runat="server" BorderStyle="Solid" BorderWidth="1px"  
                                                BorderColor="#cccccc" ImageUrl="~/Imagenes/Interrogacion.jpg"  Width="290px" /></span>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="504" Text="Salir" PostBackUrl="~/Default.aspx" />
                <input type="button" value="Volver atrás" name="Volver" onclick="history.back()" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pHeader" runat="server" CssClass="collapsePanelHeader">
                                <asp:Label ID="lblText" runat="server" Text="Comentarios" Font-Size="16px" />
                                <asp:Image ID="imageCE" runat="server" ImageUrl="~/Imagenes/Iconos/icon_expand.gif" style="vertical-align:text-bottom" />
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; vertical-align: top">
                                    <tr>
                                        <td style="">
                                            <hr noshade="noshade" size="1" color="#cccccc" />
                                        </td>
                                    </tr>
                                </table>
                        </asp:Panel>
                        <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; vertical-align: top">
                                <tr>
                                    <td style="padding-top: 10px; width: 500px; vertical-align: top">
                                        <asp:ListView ID="ComentarioListView" runat="server" OnPagePropertiesChanging="ComentarioListView_PagePropertiesChanging"
                                            GroupItemCount="1">
                                            <LayoutTemplate>
                                                <table>
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
                                                    <asp:Panel Id="pComentarioOrig" runat="server" Visible='<%# !EsReplica((int)Eval("IdReplica")) %>'>
                                                    <table border="0" cellspacing="0px">
                                                        <tr>
                                                            <td style="width: 500px; vertical-align: top">
                                                                <table border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="NombreUsuarioLabel" runat="server" SkinID="TituloColor1Grande" Text='<%# Eval("NombreUsuario") %>' Width="500px" ToolTip="" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td style="vertical-align:top;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 40px;">
                                                                                <tr>
                                                                                    <td style="height: 3px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="background-color: Silver; text-align: right; color: Maroon;
                                                                                        padding-right: 2px; padding-left: 2px" valign="top">
                                                                                        <asp:Label ID="LabelId" runat="server" Text='<%# Eval("Id") %>' Style="" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="TextoResaltado" style="width: 10px;" valign="top">
                                                                        </td>
                                                                        <td class="TituloMediano" style="width: 100px;" valign="top">
                                                                            <table border="0">
                                                                                <tr>
                                                                                    <td class="TextoResaltado" style="width: 100px;" valign="top">
                                                                                        <asp:Image ID="ImagenPortada" runat="server" ImageUrl='<%# NombreImagen(String.Format("{0}", Eval("IdUsuario")))%>'
                                                                                            Width="60px" ToolTip="" Style="border: 0" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="LabelFecha" runat="server" Text='<%# Eval("Fecha") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="TituloMediano" style="" valign="top">
                                                                            <table border="0">
                                                                                <tr>
                                                                                    <td class="TextoResaltado" style="width: 10px;" valign="top">
                                                                                       
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top; width: 400px;">
                                                                                        <asp:Label ID="LabelContenido" runat="server" Text='<%# ComentarioEstado(String.Format("{0}", Eval("Contenido").ToString().Replace("\r\n","<br>")), String.Format("{0}", Eval("Estado"))) %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="vertical-align: top">
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="vertical-align: top">
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top">
                                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; padding-right: 10px">
                                                                                                    <asp:LinkButton ID="lManoOk" runat="server" OnClick="ManoOk_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>' Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado"))) %>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="ManoOk" runat="server" ToolTip="Me gusta" ImageUrl="Imagenes/Iconos/PulgarArriba.jpg" Width="25px"></asp:Image>
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeManoOk" runat="server" ConfirmText="Confirm ?" TargetControlID="lManoOk" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px">
                                                                                                    <asp:LinkButton ID="lManoNoOk" runat="server" OnClick="ManoNoOk_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>' Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image4" runat="server" ToolTip="No me gusta" ImageUrl="Imagenes/Iconos/PulgarAbajo.jpg" Width="25px"></asp:Image> 
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeManoNoOk" runat="server" ConfirmText="Confirm ?" TargetControlID="lManoNoOk" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                                <td align="left" style="vertical-align: top; padding-right: 10px"">
                                                                                                    <asp:LinkButton ID="lAbusoContenido" runat="server" OnClick="AbusoContenido_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>' Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image5" runat="server" ToolTip="reporte abuso del lenguaje" ImageUrl="Imagenes/Iconos/AbusoSimple.jpg" Width="25px"></asp:Image>
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeAbuso" runat="server" ConfirmText="Confirma ?" TargetControlID="lAbusoContenido" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px">
                                                                                                    <asp:LinkButton ID="lReplicarComentario" runat="server" OnClick="ReplicarComentario_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image6" runat="server" ToolTip="Responder comentario" ImageUrl="Imagenes/Iconos/CommentR.jpg" Width="25px"></asp:Image> 
                                                                                                    </asp:LinkButton>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="labelManoOk" runat="server">(<%# Eval("ManoOk") %>)</asp:Label>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="labelManoNoOk" runat="server">(<%# Eval("ManoNoOk") %>)</asp:Label>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="labelAbusoContenido" runat="server">(<%# Eval("AbusoContenido") %>)</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                    </asp:Panel>
                                                    <asp:Panel ID="pComentarioReplica" runat="server" Visible='<%# EsReplica((int)Eval("IdReplica")) %>'>
                                                        <table border="0" cellspacing="0px">
                                                        <tr>
                                                            <td style="width: 500px; vertical-align: top; padding-left:55px">
                                                                <table border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label8" runat="server" SkinID="TituloColor1Grande" Text='<%# Eval("NombreUsuario") %>' Width="500px" ToolTip="" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td style="vertical-align:top;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 40px;">
                                                                                <tr>
                                                                                    <td style="height: 3px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="background-color: Silver; text-align: right; color: Maroon;
                                                                                        padding-right: 2px; padding-left: 2px" valign="top">
                                                                                        <asp:Label ID="Label10" runat="server" Text='<%# String.Format("#{0}", Eval("IdReplica")) %>' Style="" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="TextoResaltado" style="width: 10px;" valign="top">
                                                                        </td>
                                                                        <td class="TituloMediano" style="width: 100px;" valign="top">
                                                                            <table border="0">
                                                                                <tr>
                                                                                    <td class="TextoResaltado" style="width: 100px;" valign="top">
                                                                                        <asp:Image ID="Image7" runat="server" ImageUrl='<%# NombreImagen(String.Format("{0}", Eval("IdUsuario")))%>'
                                                                                            Width="60px" ToolTip="" Style="border: 0" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("Fecha") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="TituloMediano" style="" valign="top">
                                                                            <table border="0">
                                                                                <tr>
                                                                                    <td class="TextoResaltado" style="width: 10px;" valign="top">
                                                                                       
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top; width: 400px;">
                                                                                        <asp:Label ID="Label12" runat="server" Text='<%# ComentarioEstado(String.Format("{0}", Eval("Contenido").ToString().Replace("\r\n","<br>")), String.Format("{0}", Eval("Estado"))) %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="vertical-align: top">
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TituloMediano" style="vertical-align: top">
                                                                                    </td>
                                                                                    <td align="left" style="vertical-align: top">
                                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; padding-right: 10px">
                                                                                                    <asp:LinkButton ID="lRManoOk" runat="server" OnClick="ManoOk_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>' Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado"))) %>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image8" runat="server" ToolTip="Me gusta" ImageUrl="Imagenes/Iconos/PulgarArriba.jpg" Width="25px"></asp:Image>
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeRManoOk" runat="server" ConfirmText="Confirm ?" TargetControlID="lRManoOk" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px">
                                                                                                    <asp:LinkButton ID="lRManoNoOk" runat="server" OnClick="ManoNoOk_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>'  Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image9" runat="server" ToolTip="No me gusta" ImageUrl="Imagenes/Iconos/PulgarAbajo.jpg" Width="25px"></asp:Image> 
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeRManoNoOk" runat="server" ConfirmText="Confirm ?" TargetControlID="lRManoNoOk" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                                <td align="left" style="vertical-align: top; padding-right: 10px"">
                                                                                                    <asp:LinkButton ID="lRAbusoContenido" runat="server" OnClick="AbusoContenido_Click" CommandArgument='<%# String.Format("{0}-{1}", Eval("Id"), Eval("IdReplica")) %>' Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'
                                                                                                        ToolTip='<%# Eval("Id") %>'>
                                                                                                        <asp:Image ID="Image10" runat="server" ToolTip="Reportar abuso del lenguaje" ImageUrl="Imagenes/Iconos/AbusoSimple.jpg" Width="25px"></asp:Image>
                                                                                                    </asp:LinkButton>
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeRAbusoContenido" runat="server" ConfirmText="Confirmar ?" TargetControlID="lRAbusoContenido" Enabled='<%# EstadoOk(String.Format("{0}", Eval("Estado")))%>'></ajaxToolkit:ConfirmButtonExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="label13" runat="server">(<%# Eval("ManoOk") %>)</asp:Label>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="label14" runat="server">(<%# Eval("ManoNoOk") %>)</asp:Label>
                                                                                                </td>
                                                                                                <td style="vertical-align: top; padding-right: 10px; text-align:center">
                                                                                                    <asp:Label ID="label15" runat="server">(<%# Eval("AbusoContenido") %>)</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                    </asp:Panel>
                                                </td>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ComentarioListView" PageSize="5">
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
                        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody" 
                            CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="false" TextLabelID="lblText" CollapsedText="Presione para ver los comentarios" ExpandedText="Presione para ocultar los comentarios"  ImageControlID="imageCE" ExpandedImage="~/Imagenes/Iconos/icon_collapse.gif"
                            CollapsedImage="~/Imagenes/Iconos/icon_expand.gif"
                            CollapsedSize="0">
                        </ajaxToolkit:CollapsiblePanelExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top: 10px">
                <asp:Panel ID="pComentarioCrear" runat="server" CssClass="cpBody" Style="padding-top: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; vertical-align: top">
                        <tr>
                            <td style="padding-top: 10px; width: 500px; vertical-align: top">
                                <asp:Label ID="LabelComentario" runat="server" Text="Ingresar comentario."></asp:Label>
                                <asp:Label ID="LabelComentario2" runat="server" Text="  (para ingresar un comentario, debe ser usuario del sitio)"
                                    CssClass="MultilineFontCh"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; width: 500px; vertical-align: top">
                                <asp:TextBox ID="txtComentario" runat="server" Text="" MaxLength="500" CssClass="MultilineFontCh"
                                    TextMode="MultiLine" Width="500px" Height="60px" Style="resize: none;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-bottom: 10px; width: 500px; vertical-align: top">
                                <asp:Button ID="AceptarButton" runat="server" TabIndex="502" Text="Confirmar" OnClick="AceptarButton_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
            </td>
        </tr>
    </table>
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
                    <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina" Text="Responder comentario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-top:20px; padding-right:5px; padding-left:5px; vertical-align: top">
                    Id:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="IdComentarioReplicaLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right" style="padding-right:5px; padding-left:5px; vertical-align: top">
                    Comentario:
                </td>
                <td align="left">
                    <asp:TextBox ID="ComentarioReplicaTextBox" runat="server" Text="" MaxLength="500" CssClass="MultilineFontCh" TextMode="MultiLine" Width="500px" Height="60px" style="resize: none;"></asp:TextBox>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="AceptarReplicaButton" runat="server" Text="Confirmar" onclick="AceptarReplicaComentario_Click" UseSubmitBehavior="false" />
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarReplicaButton" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadCPH">
    <style type="text/css">
        .style2
        {
            width: 244px;
        }
    </style>
</asp:Content>

