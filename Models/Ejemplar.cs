using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Ejemplar")]
    public class Ejemplar
    {
        [Key]
        public int idEjemplar { get; set; }

        public string ISBN { get; set; }

        public string descripcionEjem{ get; set; }

        public bool estatus { get; set; }

    }
}