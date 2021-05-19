namespace PermisoAccesoDatos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoPermiso")]
    public partial class TipoPermiso
    { 
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripción { get; set; }
        public virtual ICollection<Permiso> Permisoes { get; set; }

    }
}
