<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Novedades.aspx.cs" Inherits="Condeco.Novedades" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadCPH">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainCPH">
    <section class="bg-primary-white" id="secNovedades">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <p>
                    <span class="fa fa-2x fa-magic"></span>
                    </p>
                    <h2 class="section-heading"> Novedades</h2>
                    <hr>
                    <p>En breve estaremos informando las novedades.
                    </p>
                    <a href="Default.aspx" class="btn btn-primary btn-xl page-scroll">HOME</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
