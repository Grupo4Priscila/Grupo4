using System; 
using System.Collections.Generic; 
using System.Linq; 
using Microsoft.Extensions.Logging; 
using Publicaciones.Backend; 
using Publicaciones.Models; 

namespace Publicaciones.Service {

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
              foreach(EstadoDePostulacion estado in listaEstadoPost){
                  if(autor.paper.id==estado.paper.id && estado.Tipo=="Aceptada"){
                /// La publicacion, que primero fue un paper Aceptada escrita por el autor
                    publicacionesPorAutor.Add(autor.paper.Publicacion);
                      }
                  }
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

            Persona persona2 = new Persona(); 
            persona2.Nombre = "Priscila"; 
            persona2.Apellido = "Gonzalez"; 

            Persona persona3 = new Persona(); 
            persona3.Nombre = "Pepe"; 
            persona3.Apellido = "Lota"; 

            // Agrego la persona al backend
            this.Add(persona1); 
            this.Add(persona2);
            this.Add(persona3);

            // Paper por defecto
            
            Paper paper1 = new Paper();
            Paper paper2 = new Paper();


            // Agrego los Autores al backend
            this.AddPaper(paper1); 
            this.AddPaper(paper2);

            //Publicacion por defecto
            Publicacion publi1=new Publicacion();
            Publicacion publi2=new Publicacion(); 
            //Agrego las publicaciones al backend
            this.AddPublicaciones(publi1);
            this.AddPublicaciones(publi2);


            // Autores por defecto
            Autor autor1 = new Autor();
            Autor autor2 = new Autor();
            Autor autor3 = new Autor();
            Autor autor4 = new Autor();

            // Agrego los Autores al backend
            this.AddAutor(autor1); 
            this.AddAutor(autor2);
            this.AddAutor(autor3);
            this.AddAutor(autor4);











            foreach (Persona p in BackendContext.Personas) {
                Logger.LogDebug("Persona: {0}", p); 
            }

            Initialized = true;

            Logger.LogDebug("Inicializacion terminada :)");
        }
    }

}