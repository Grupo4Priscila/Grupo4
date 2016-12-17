namespace Publicaciones.Models{
    ///<summary>
    ///Clase paper. Articulo antes de ser publicado
    ///Atributos
        ///Titulo: Nombre del paper
        ///FechaInicio:Fecha que comenzo a escribir el Articulo
        ///FechaTermino:Fecha en que se termino el articulo
        ///Abstract: Resumen del articulo
    ///<summary>
    ///<returns></returns>
    public class Paper{

        public string Titulo{set;get;}
        public string FechaInicio{set;get;}
        public string FechaTermino{set;get;}
        public string Abstract{set;get;}
    }
}