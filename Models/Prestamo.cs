using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Prestamo")]
    public class Prestamo
    {
        [Key]
        public int idPrestamo { get; set; }

        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public DateTime fechaPrevistaDev { get; set; }



    }
}