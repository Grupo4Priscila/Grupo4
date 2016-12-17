using Microsoft.EntityFrameworkCore; 
using Publicaciones.Models; 

namespace Publicaciones.Backend {

    /// <summary>
    /// Representacion de la base de datos.
    /// </summary>
    public class BackendContext : DbContext {

        /// <summary>
        /// Constructor vacio para pruebas
        /// </summary>
        public BackendContext() {
            
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        public BackendContext(DbContextOptions < BackendContext > options) : base(options) {
        }

        /// <summary>
        /// Representacion de las Personas del Backend
        /// </summary>
        /// <returns>Link a la BD de Personas</returns>
        public DbSet < Persona > Personas {get; set; }
       
        /// <summary>
        /// Representacion de las Publicaciones del Backend
        /// </summary>
        /// <returns>Link a la BD de Publicaciones</returns>
        public DbSet <Publicacion> Publicaciones{get;set;}
       
        /// <summary>
        /// Representacion del Paper del Backend
        /// </summary>
        /// <returns>Link a la BD de Papers</returns>
        public DbSet <Paper> Papers{get;set;}
       
        /// <summary>
        /// Representacion del Estado de la publicacion del Backend
        /// </summary>
        /// <returns>Link a la BD de EstadosdePostulaciones</returns>
        public DbSet <EstadoDePostulacion> EstadosdePostulaciones{get;set;}
       
        /// <summary>
        /// Representacion del Autor del Backend
        /// </summary>
        /// <returns>Link a la BD de Autores</returns>
        public DbSet <Autor> Autores{get;set;}
    }

}