using PermisoAccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermisoAccesoDatos.DataAccess
{

    public class TipoPermisoDataAccess
    {
        ApplicationContextDB applicationContextDB = new ApplicationContextDB();
        public List<TipoPermiso> GetTipoPermisos() {
           return applicationContextDB.TipoPermisos.ToList();
        }
    }
}
