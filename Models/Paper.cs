using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models{

    public class Paper{

    [Key]
        public string IdPaper{set;get;}
        public string Titulo{set;get;}
        public Publicacion Publicacion{set;get;}
//        public string FechaInicio{set;get;}

//        public string FechaTermino{set;get;}
//        public string Abstract{set;get;}
    }
}