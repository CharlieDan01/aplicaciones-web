using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }

        public DateTime fecha { get; set; }

        public bool estatus { get; set; }


    }
}