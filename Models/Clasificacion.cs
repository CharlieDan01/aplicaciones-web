using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Clasificacion")]
    public class Clasificacion
    {
        [Key]
        public int idClasificacion { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public bool estatus { get; set; }

    }
}