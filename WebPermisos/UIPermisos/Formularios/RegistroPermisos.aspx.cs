using PermisoAccesoDatos.DataAccess;
using PermisoAccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIPermisos
{
    public partial class Register : System.Web.UI.Page
    {
        PermisoDataAccess permisoDataAccess = new PermisoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoPermisoDataAccess _tipoPermisoDataAccess = new TipoPermisoDataAccess();
                this.droTipoPermisos.Items.Clear();
                this.droTipoPermisos.Items.Add(new ListItem { Value = "0", Text = "Seleccionar Tipo Permiso", Selected = true });
                foreach (var tipoPermiso in _tipoPermisoDataAccess.GetTipoPermisos())
                {
                    droTipoPermisos.Items.Add(new ListItem { Value = Convert.ToString(tipoPermiso.Id), Text = tipoPermiso.Descripción });
                }

                try
                {
                    int Codigo = Convert.ToInt32(Request.QueryString["Codigo"]);
                    if (Codigo > 0)
                    {
                        getPropiedades(Codigo);

                    }
                    btnEliminar.Enabled = true;
                }
                catch (Exception)
                {

                    throw;
                }
              

            }
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar() {
            txtCodigo.Text = "NUEVO";
            txtNombres.Text ="";
            txtApellidos.Text = "";
            droTipoPermisos.SelectedValue = "0";
            txtFechaPermiso.Text = "";
            btnEliminar.Enabled = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    var p = setPropiedades();

                    if (this.txtCodigo.Text== "NUEVO")
                    {
                        if (permisoDataAccess.Insertar(p))
                        {
                            AlertSuccess.Visible = true;
                            AlertSuccess.InnerText = "Registro Guardado Correctamente";
                            AlertDanger.Visible = false;
                        }
                        else
                        {
                            AlertDanger.Visible = true;
                        }
                    }
                    else
                    {
                        if (permisoDataAccess.Actualizar(p))
                        {
                            AlertSuccess.Visible = true;
                            AlertSuccess.InnerText = "Registro Actualizado Correctamente";
                            AlertDanger.Visible = false;
                        }
                        else
                        {
                            AlertDanger.Visible = true;
                            AlertDanger.InnerText = "Se produjo un error";
                        }
                    }
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                AlertDanger.Visible = true;
                AlertDanger.InnerText = ex.Message;
                throw;
            }
        }

        public Permiso setPropiedades() {
            Permiso _permiso = new Permiso();
            try
            {
                _permiso.Id = txtCodigo.Text == "NUEVO" ? 0 : Convert.ToInt32(this.txtCodigo.Text);
                _permiso.NombreEmpleado = this.txtNombres.Text;
                _permiso.ApellidosEmpleado = this.txtApellidos.Text;
                _permiso.TipoPermisoId = Convert.ToInt32(this.droTipoPermisos.SelectedValue);
                _permiso.FechaPermiso = Convert.ToDateTime(txtFechaPermiso.Text);
            }
            catch (Exception  ex)
            {

                throw;
            }

            return _permiso;
            
        }

        public void getPropiedades(int Id)
        {
            try
            {
                Permiso permiso = permisoDataAccess.ObtenerPermisos(Id);

                txtCodigo.Text = permiso.Id.ToString();
                txtNombres.Text = permiso.NombreEmpleado;
                txtApellidos.Text = permiso.ApellidosEmpleado;
                txtFechaPermiso.Text = permiso.FechaPermiso.ToString();
                droTipoPermisos.SelectedValue = permiso.TipoPermisoId.ToString();
                txtFechaPermiso.Text = permiso.FechaPermiso.ToString("MM/dd/yyyy");
                UpdatePanelPermiso.Update();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Validar() {

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                AlertDanger.Visible = true;
                AlertSuccess.Visible = false;
                AlertDanger.InnerText = "El Nombre del Empleado es obligatorio";
                txtNombres.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                AlertDanger.Visible = true;
                AlertSuccess.Visible = false;
                AlertDanger.InnerText = "El Apellido del Empleado es obligatorio";
                txtApellidos.Focus();
                return false;
            }
            else if (droTipoPermisos.SelectedValue == "0")
            {
                AlertDanger.Visible = true;
                AlertSuccess.Visible = false;
                AlertDanger.InnerText = "El Tipo de Permiso es obligatorio";
                droTipoPermisos.Focus();
                    return false;
            }
            else if (string.IsNullOrWhiteSpace(txtFechaPermiso.Text))
            {
                AlertDanger.Visible = true;
                AlertSuccess.Visible = false;
                AlertDanger.InnerText = "La Fecha de Permiso es obligatorio";
                txtFechaPermiso.Focus();
                return false;

            }
            return true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int Codigo = Convert.ToInt32(txtCodigo.Text);
                if (permisoDataAccess.Eliminar(Codigo))
                {
                    AlertSuccess.Visible = true;
                    AlertSuccess.InnerText = "Registro eliminado Correctamente";
                    Limpiar();
                }
            }
            catch (Exception ex )
            {
                AlertDanger.Visible = true;
                AlertDanger.InnerText = "Se produjo un error";
                throw;
            }
           
        }
    }
}