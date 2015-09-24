using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Condeco
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CondecoEntidades.Sesion sesion = (CondecoEntidades.Sesion)Session["Sesion"];
                string[] segmentosURL = HttpContext.Current.Request.Url.Segments;
                string pagina = segmentosURL[segmentosURL.Length - 1];                
                if (pagina != null)
                {
                    Control c;
                    switch (pagina)
                    {
                        case "Default.aspx":
                            //c = (Control)this.FindControl("secHeader");
                            //c.Visible = true;
                            c = (Control)this.FindControl("secAcerca");
                            c.Visible = true;
                            c = (Control)this.FindControl("secServicios");
                            c.Visible = true;
                            break;
                        case "UsuarioLogin.aspx":
                            if (HttpContext.Current.Request.Url.Query.ToUpper() == "?CERRAR")
                            {
                                if (sesion != null && sesion.Usuario.Id != null)
                                {
                                    CondecoRN.Sesion.Cerrar(sesion);
                                }
                            }
                            c = (Control)this.FindControl("secAcerca");
                            c.Visible = false;
                            c = (Control)this.FindControl("secServicios");
                            c.Visible = false;
                            break;
                        default:
                            //c = (Control)this.FindControl("secHeader");
                            //c.Visible = false;
                            c = (Control)this.FindControl("secAcerca");
                            c.Visible = false;
                            c = (Control)this.FindControl("secServicios");
                            c.Visible = false;
                            break;
                    }
                }
                Funciones.PersonalizarControlesMaster(this, true, sesion);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Visible = false;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}