using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BIBLIOTECATEC.Models
{
    [Table("TipoSocio")]
    public class TipoSocio
    {
        [Key]
        public int idTipoSocio { get; set; }

        public string descripcion { get; set; }

        public string maximoMultas { get; set; }
        public bool estatus { get; set; }
    }
}