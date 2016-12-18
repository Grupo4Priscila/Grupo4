using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models{
    ///<summary>
    ///Clase Autor
    ///Atributos
        ///Id: identificador 
        ///Persona: Relacion, es la persona
        ///Paper: el paper que escribe:
        ///Fecha: Fecha en que se escribe
    ///<summary>
    ///<returns></returns>
    public class Autor{

[Key]
        public string Id{set;get;}
        public Persona Persona{set;get;}
        public Paper paper{set;get;}
        public string Fecha{set;get;}
        
    }
}