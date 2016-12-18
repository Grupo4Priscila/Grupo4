using System.Collections.Generic;
namespace Publicaciones.Models{
    
    ///<summary>
    ///Clase paper. Articulo antes de ser publicado
    ///Atributos
        ///id: identificador del paper
        ///Titulo: Nombre del paper
        ///FechaInicio:Fecha que comenzo a escribir el Articulo
        ///FechaTermino:Fecha en que se termino el articulo
        ///Abstract: Resumen del articulo
        ///autorCorrespondiente: Autor correspondiente del articulo
        ///autorPrincipal: Autor principal del articulo
        ///cantidadRechazos: cantidad de rechazos que tiene el paper
        ///EstadoDePostulacion: lista de todos los estados de las postulaciones del paper
    ///<summary>
    ///<returns></returns>
    public class Paper{

        public string id{set;get;}
        public string Titulo{set;get;}
        public Publicacion Publicacion{get;set;}

 //       public string FechaInicio{set;get;}
 //       public string FechaTermino{set;get;}
 //       public string Abstract{set;get;}
 //       public Autor autorCorrespondiente{set;get;}
 //       public Autor autorPrincipal{set;get;}
//        public List<Autor> listaAutor;
 ///       public int cantidadRechazos{set;get;}




    }
}