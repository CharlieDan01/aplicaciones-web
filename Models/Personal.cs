using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Personal")]
    public class Personal
    {
        [Key]
       public int idPersonal { get; set; }
        public string nombre { get; set; }
         public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string constraseña { get; set; }
        public string rango { get; set; }
        public bool estatus { get; set; }
    }
}