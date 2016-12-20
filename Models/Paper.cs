using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models{
    
    ///<summary>
    ///Clase paper. Articulo antes de ser publicado
    ///Atributos
        ///FechaInicio:Fecha que comenzo a escribir el Articulo
        ///FechaTermino:Fecha en que se termino el articulo
        ///autorCorrespondiente: Autor correspondiente del articulo
        ///autorPrincipal: Autor principal del articulo
        ///EstadoDePostulacion: lista de todos los estados de las postulaciones del paper
    ///<summary>
    ///<returns></returns>
    public class Paper{
        [Key]
        /*
            id es el identificador del paper
        */
        public string id{set;get;}
        /*
            Titulo es el nombre del paper
        */
        public string Titulo{set;get;}

        public Publicacion Publicacion{get;set;}

        /*
            Abstract es el resumen del paper
        */
        public string Abstract{set;get;}
        //public Autor autorCorrespondiente{set;get;}
        public Autor autorPrincipal{set;get;}
        public List<Autor> listaAutor;
        /*
            cantidadRechazos que tiene el paper
        */
        public int cantidadRechazos{set;get;}
        public string FechaInicio{set;get;}
        public string FechaTermino{set;get;}

    }
}