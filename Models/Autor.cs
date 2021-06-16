using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int idAutor { get; set; }

        public string nombre { get; set; }

        public string pais { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public bool estatus { get; set; }

    }
}