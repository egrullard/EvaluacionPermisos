namespace PermisoAccesoDatos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permiso")]
    public partial class Permiso
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NombreEmpleado { get; set; }
        [StringLength(50)]
        public string ApellidosEmpleado { get; set; }

        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }
        public virtual TipoPermiso TipoPermiso { get; set; }

    }
}
