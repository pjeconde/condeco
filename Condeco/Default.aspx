<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Condeco.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="no-padding" id="portfolio">
        <div class="container-fluid">
            <div class="row no-gutter">
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="PecesLinkButton" class="portfolio-box" runat="server" CommandName="Peces" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PortfolioPeces.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Peces
                                </div>
                                <div class="project-name">
                                    madera y metal
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="CarasLinkButton" class="portfolio-box" runat="server" CommandName="Caras" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PorfolioCaras.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Caras
                                </div>
                                <div class="project-name">
                                    madera y metal
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="MueblesLinkButton" class="portfolio-box" runat="server" CommandName="Muebles" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PorfolioMuebles.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Muebles
                                </div>
                                <div class="project-name">
                                    madera maciza
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="CartelesLinkButton" class="portfolio-box" runat="server" CommandName="Carteles" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PorfolioCarteles.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Carteles
                                </div>
                                <div class="project-name">
                                    madera añejada
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="BarcosLinkButton" class="portfolio-box" runat="server" CommandName="Barcos" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PorfolioBarcos.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Barcos
                                </div>
                                <div class="project-name">
                                    madera y metal
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:LinkButton ID="MarcosLinkButton" class="portfolio-box" runat="server" CommandName="Marcos" OnClick="BuscarDirectoButton_Click">
                        <img src="imagenes/portfolio/PorfolioMarcos.jpg" class="img-responsive" alt="">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">
                                    Marcos
                                </div>
                                <div class="project-name">
                                    pinotea y cedro
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
