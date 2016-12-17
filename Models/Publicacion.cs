namespace Publicaciones.Models
{
        ///<summary>
    ///Clase Publicacion, paper publicado
    ///Atributos
        ///Doi: Identificador de la publicacion
        ///Titulo: Nombre de la publicacion
        ///Volumen: Numero de la edicion de la publicacion
        ///PaginaInicio: Numero de la pagina Inicial
        ///PaginaFinal: Numero de la pagina final
        ///CAntidadRechazos: Numero de veces que fue rechazada
        ///NumeroDePagina: Numero total de paginas de la publicacion
    ///<summary>
    ///<returns></returns>
             public class Publicacion
    {
        public string Doi { get; set; }
        public string Titulo { get; set; }
        public string Volumen { get; set; }
        public string PaginaInicio  { get; set; }
        public string PaginaFinal { get; set; }
        public string ContidadRechazos { get; set; }
        public string NumeroDePagina{get; set;}
    }

}