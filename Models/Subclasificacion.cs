using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Subclasificacion")]
    public class Subclasificacion
    {
        [Key]
        public int idSubclasficacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public bool estatus { get; set; }


    }
}