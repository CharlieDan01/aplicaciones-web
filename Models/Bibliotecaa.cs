using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BIBLIOTECATEC.Models
{
    [Table("Bibliotecaa")]
    public class Bibliotecaa
    {
        [Key]
        public int idBiblioteca { get; set; }

        public string imagenFile { get; set; }

        public string horario { get; set; }

        public string telefono { get; set; }


    }
}