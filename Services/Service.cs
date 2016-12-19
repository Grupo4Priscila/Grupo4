using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Publicaciones.Backend;
using Publicaciones.Models;

namespace Publicaciones.Service
{

    /// <summary>
    /// Metodos de la interface
    /// </summary>
    public interface IMainService {
        void Add(Persona persona); 
        List < Persona > FindPersonas(string nombre);
        List <Persona> Personas();
        void AddPublicaciones(Publicacion publicacion);
        List <Publicacion> Publicaciones(string rut);
        void AddAutor(Autor autor);
        void AddPaper(Paper paper);
        List<Publicacion> Publicaciones();
        List<Autor> Autores();
        List<Paper> Papers();
        void AddEstadoDePostulaciones(EstadoDePostulacion estado);
        List<EstadoDePostulacion> EstadoDePostulaciones();


        void Initialize(); 
    }

    /// <summary>
    /// Implementacion de la interface IMainService
    /// </summary>


    public class MainService:IMainService {

        /// <summary>
        /// Acceso al Backend
        /// </summary>
        /// <returns></returns>
        private BackendContext BackendContext { get; set; }

        /// <summary>
        /// The Logger 
        /// </summary>
        /// <returns></returns>
        private ILogger Logger { get; set; }

        private Boolean Initialized { get; set; }

        /// <summary>
        /// Constructor via DI
        /// </summary>
        /// <param name="backendContext"></param>
        /// <param name="loggerFactory"></param>
         public MainService(BackendContext backendContext, ILoggerFactory loggerFactory) {

            // Inicializacion del Logger
            Logger = loggerFactory?.CreateLogger < MainService > (); 
            if (Logger == null) {
                throw new ArgumentNullException(nameof(loggerFactory)); 
            }

            // Obtengo el backend
            BackendContext = backendContext; 
            if (BackendContext == null) {
                throw new ArgumentNullException("MainService requiere del BackendService != null"); 
            }

            // No se ha inicializado
            Initialized = false;

            Logger.LogInformation("MainService created"); 
        }
        /// <summary>
        /// Add: Inserta una persona en la BD 
        /// </summary>
        /// <returns></returns>

        public void Add(Persona persona) {

            // Guardo la Persona en el Backend
            BackendContext.Personas.Add(persona); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }
        /// <summary>
        /// AddPublicaciones: Inserta una publicacion en la BD 
        /// </summary>
        /// <returns></returns>
        public void AddPublicaciones(Publicacion publicacion){
            // Guardo la Publicacion en el Backend
            BackendContext.Publicaciones.Add(publicacion); 

            // Guardo los cambios
            BackendContext.SaveChanges();
        }
        /// <summary>
        /// AddEstadoDePostulaciones: Inserta un estado en la BD 
        /// </summary>
        /// <returns></returns>
        public void AddEstadoDePostulaciones(EstadoDePostulacion estado){
            // Guardo la Publicacion en el Backend
            BackendContext.EstadoDePostulaciones.Add(estado); 

            // Guardo los cambios
            BackendContext.SaveChanges();
        }
        /// <summary>
        /// AddAutor: Inserta un autor en la BD 
        /// </summary>
        /// <returns></returns>
        public void AddAutor(Autor autor){
            BackendContext.Autores.Add(autor);
            BackendContext.SaveChanges();
        }
        /// <summary>
        /// AddPaper: Inserta un paper en la BD 
        /// </summary>
        /// <returns></returns>
        public void AddPaper(Paper paper){
            BackendContext.Papers.Add(paper);
            BackendContext.SaveChanges();
        }
        /// <summary>
        /// Obtiene una lista de personas con el mismo nombre
        /// </summary>
        /// <returns></returns>

        public List < Persona > FindPersonas(string nombre) {
            return BackendContext.Personas
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToList(); 
        }

        /// <summary>
        /// Obtiene una lista de todas personas en la BD
        /// </summary>
        /// <returns></returns>

        public List<Persona> Personas() {
            return BackendContext.Personas.ToList();
        }
        /// <summary>
        /// Obtiene una lista de todas publicaciones en la BD
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> Publicaciones()
        {
            return BackendContext.Publicaciones.ToList();
        }
        /// <summary>
        /// Obtiene una lista de todos los estados relacionados con paper
        /// </summary>
        /// <returns></returns>
        public List<EstadoDePostulacion> EstadoDePostulaciones()
        {
            return BackendContext.EstadoDePostulaciones.ToList();
        }
        /// <summary>
        /// Obtiene una lista de todos los Autores en la BD
        /// </summary>
        /// <returns></returns>
        public List<Autor> Autores()
        {
            return BackendContext.Autores.ToList();
        }
        /// <summary>
        /// Obtiene una lista de todos los papers en la BD
        /// </summary>
        /// <returns></returns>
        public List<Paper> Papers()
        {
            return BackendContext.Papers.ToList();
        }

        /// <summary>
        /// Obtiene una lista de todas las publicaciones asociadas a un rut
        /// </summary>
        /// <returns></returns>
         public List<Publicacion> Publicaciones(string rut){

         //Lista de todos los estados de postulaciones
         List<EstadoDePostulacion> listaEstadoPost= EstadoDePostulaciones();
          //   Lista de el autor participante en distintas Publicaciones
          List<Autor> autores =
          BackendContext.Autores
          .Where(a =>a.Id.Equals(rut))
          .ToList();

          ///lista donde estaran las publicaciones escritas por dicho Autor
          List <Publicacion> publicacionesPorAutor= new List<Publicacion>();


          //Para cada autor donde el estado de su paper sea Aceptada (para que exista la publicacion)
          foreach(Autor autor in autores)
          {  
            Publicacion  publicacion = 
            BackendContext.Publicaciones
            .Where(p=> p.Equals(autor.paper.Publicacion))
            .SingleOrDefault();
              
            
       //       foreach(EstadoDePostulacion estado in listaEstadoPost){

         //         if(autor.paper==estado.paper && estado.Tipo==1){
                /// La publicacion, que primero fue un paper Aceptada escrita por el autor
                    publicacionesPorAutor.Add(publicacion);
            //          }
              //    }
              }
              
          //Retorna la lista con las publicaciones (si existen) si no, retorna una lista vacia
             return publicacionesPorAutor;
         }


        public void Initialize() {

            if (Initialized) {
                throw new Exception("Solo se permite llamar este metodo una vez");
            }

            Logger.LogDebug("Realizando Inicializacion .."); 

            // Persona por defecto
            Persona persona1 = new Persona(); 
            persona1.Nombre = "Diego"; 
            persona1.Apellido = "Urrutia"; 
            persona1.Rut="a";

            Persona persona2 = new Persona(); 
            persona2.Nombre = "Priscila"; 
            persona2.Apellido = "Gonzalez";
            persona2.Rut="b"; 

            Persona persona3 = new Persona(); 
            persona3.Nombre = "Pepe"; 
            persona3.Apellido = "Lota";
            persona3.Rut="c"; 

            // Agrego la persona al backend
            this.Add(persona1); 
            this.Add(persona2);
            this.Add(persona3);

            //Publicacion por defecto
            Publicacion publi1=new Publicacion();
            publi1.Doi="a1";
            publi1.Titulo="p1";
            Publicacion publi2=new Publicacion(); 
            publi2.Doi="a2";
            publi1.Titulo="p2";
            //Agrego las publicaciones al backend
            this.AddPublicaciones(publi1);
            this.AddPublicaciones(publi2);


            // Paper por defecto
            Paper paper1 = new Paper();
            paper1.id="p1";
            paper1.Titulo="p1";
            paper1.Publicacion=publi1;
            Paper paper2 = new Paper();
            paper2.id="p2";
            paper2.Titulo="p2";
            paper2.Publicacion=publi2;

            // Agrego los paper al backend
            this.AddPaper(paper1); 
            this.AddPaper(paper2);
        
            // Autores por defecto
            Autor autor1 = new Autor();
            autor1.Persona=persona1;
            autor1.paper=paper1;
            Autor autor2 = new Autor();
            autor2.Persona=persona2;
            autor2.paper=paper1;
            Autor autor3 = new Autor();
            autor3.Persona=persona2;
            autor3.paper=paper2;
            Autor autor4 = new Autor();
            autor4.Persona=persona3;
            autor4.paper=paper2;

            // Agrego los Autores al backend
            this.AddAutor(autor1); 
            this.AddAutor(autor2);
            this.AddAutor(autor3);
            this.AddAutor(autor4);

            //EstadoDePostulacion por defecto
            EstadoDePostulacion estado1 = new EstadoDePostulacion();
            estado1.IdEstado="estado1";
            estado1.Tipo=1;
            estado1.paper=paper1;
            EstadoDePostulacion estado2 = new EstadoDePostulacion();
            estado2.IdEstado="estado2";
            estado2.Tipo=2;
            estado2.paper=paper2;
            EstadoDePostulacion estado3 = new EstadoDePostulacion();
            estado3.IdEstado="estado3";
            estado3.Tipo=1;
            estado3.paper=paper2;
            // Agregar EstadoDePostulacion al backend
            this.AddEstadoDePostulaciones(estado1);
            this.AddEstadoDePostulaciones(estado2);
            this.AddEstadoDePostulaciones(estado3);

            foreach (Persona p in BackendContext.Personas) {
                Logger.LogDebug("Persona: {0}", p); 
            }

            Initialized = true;

            Logger.LogDebug("Inicializacion terminada :)");
        }
    }

}