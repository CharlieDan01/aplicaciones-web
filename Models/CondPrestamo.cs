using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BIBLIOTECATEC.Models
{
    [Table("CondPrestamo")]
    public class CondPrestamo
    {
        [Key]
        public int idCondicion { get; set; }

        public string limitePrestamos { get; set; }

        public string limiteRenovaciones { get; set; }

        public bool estatus { get; set; }



    }
}