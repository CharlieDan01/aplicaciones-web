using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIBLIOTECATEC.Models
{
    [Table("TipoEjemplar")]
    public class TipoEjemplar
    {
        [Key]
        public int idTipoEjemplar { get; set; }
        public string descripcion { get; set; }

        public string ImagenFile { get; set; }
        public bool estatus { get; set; }



    }
}