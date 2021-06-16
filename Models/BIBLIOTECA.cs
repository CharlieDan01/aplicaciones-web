using System;
using System.Data.Entity;

namespace BIBLIOTECATEC.Models
{
    public class BIBLIOTECA: DbContext
    {
        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Autor>Autors { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Bibliotecaa> Bibliotecaas { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Clasificacion> Clasificacions { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Coleccion> Coleccions { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.CondPrestamo> CondPrestamoes { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Ejemplar> Ejemplars { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Personal> Personals { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Prestamo> Prestamoes { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Recurso> Recursoes { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Reserva> Reservas { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Socio> Socios { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.Subclasificacion> Subclasificacions { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.TipoEjemplar> TipoEjemplars { get; set; }

        public System.Data.Entity.DbSet<BIBLIOTECATEC.Models.TipoSocio> TipoSocios { get; set; }
    }
}