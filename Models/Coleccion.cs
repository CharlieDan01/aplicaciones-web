using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("Coleccion")]
    public class Coleccion

    {
        [Key]
        public int idColeccion { get; set; }
        public string descripcion { get; set; }
    }
}