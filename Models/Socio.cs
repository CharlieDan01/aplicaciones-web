using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Socio")]
    public class Socio
    {
        [Key]
        public int idSocio { get; set; }
        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }

        public string dirección { get; set; }

        public string telefono { get; set; }

        public string email{ get; set; }

        public bool estatus { get; set; }

    }
}