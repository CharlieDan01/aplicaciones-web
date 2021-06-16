using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Recurso")]
    public class Recurso
    {
        [Key]
        public int idRecurso { get; set; }

        public string titulo { get; set; }

        public string descripcion { get; set; }
        public bool estatus { get; set; }
        public int precio { get; set; }

    }
}