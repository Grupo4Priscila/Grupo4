using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models{

    public class Autor{

[Key]
        public string Id{set;get;}
        public Persona Persona{set;get;}
        public Paper paper{set;get;}

        public string Fecha{set;get;}
        
    }
}