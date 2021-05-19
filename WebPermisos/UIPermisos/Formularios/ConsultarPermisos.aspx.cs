using PermisoAccesoDatos.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIPermisos.Formularios
{
    public partial class ConsultarPermisos : System.Web.UI.Page
    {
        PermisoDataAccess permisoDataAccess = new PermisoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridPermisos.DataSource = permisoDataAccess.ObtenerPermisos();
                this.GridPermisos.DataBind();
            }

        }

        protected void GridPermisos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "Actualizar":
                        Response.Redirect("RegistroPermisos.aspx?Codigo=" + codigo, false);
                        break;
                    case "Eliminar":
                        permisoDataAccess.Eliminar(codigo);
                        Response.Redirect("ConsultarPermisos.aspx", false);
                        break;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}