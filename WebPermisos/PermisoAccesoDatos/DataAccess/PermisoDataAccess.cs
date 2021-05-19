using PermisoAccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermisoAccesoDatos.DataAccess
{
    public class PermisoDataAccess
    {
        ApplicationContextDB applicationContextDB = new ApplicationContextDB();
        public bool Insertar(Permiso permiso)
        {
            bool result = false;
            try
            {
                applicationContextDB.Permisos.Add(permiso);
                result = Convert.ToBoolean(applicationContextDB.SaveChanges());
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Actualizar(Permiso permiso)
        {
            try
            {
                var value = applicationContextDB.Permisos.Find(permiso.Id);
                applicationContextDB.Entry(value).CurrentValues.SetValues(permiso);
                applicationContextDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Permiso> ObtenerPermisos()
        {
            return applicationContextDB.Permisos.ToList();
        }

        public Permiso ObtenerPermisos(int Id)
        {
            Permiso permiso = new Permiso();
            try
            {
                permiso = applicationContextDB.Permisos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return permiso;
        }

        public bool Eliminar(int Id)
        {
  
            try
            {
                var value = applicationContextDB.Permisos.Find(Id);
                applicationContextDB.Permisos.Remove(value);
                applicationContextDB.SaveChanges();
                return true;
             
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
