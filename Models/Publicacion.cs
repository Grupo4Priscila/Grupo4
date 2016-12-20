using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models
{
    ///<summary>
    ///Clase Publicaciones. Articulo publicado
    ///Atributos
        ///Doi: identificador 
        ///Titulo: Nombre del paper
        ///Volumen:Version de modificacion
        ///PaginaInicio: Muestra la pagina inicia
        ///PaginaTermino: Muestra la pagina final
        ///cantidadRechazos: cantidad de rechazos que tiene la publicacion
        ///NumeroDePagina: cantidad de paginas de la publicacion
    ///<summary>
    ///<returns></returns>
    public class Publicacion
    {
        [Key]
        public string Doi { get; set; }
        public string Titulo { get; set; }
        public int Volumen { get; set; }
        //public string PaginaInicio  { get; set; }
        //public string PaginaFinal { get; set; }

        public int NumeroDePagina{get; set;}
    }

}