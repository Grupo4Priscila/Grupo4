using System.ComponentModel.DataAnnotations;

namespace Publicaciones.Models{
    ///<summary>
    ///Clase EstadoDePostulacion
    ///Atributos
        ///IdEstado: identificador 
        ///Tipo: Aceptado, Rechazado
        ///Paper: relacion con el paper
        ///Fecha: fecha que fue aceptada o rechazada
    ///<summary>
    ///<returns></returns>
    public class EstadoDePostulacion{
        [Key]
        public string IdEstado{set;get;}
        public int Tipo{set;get;}
        public string Fecha{set;get;}
        public Paper paper{set;get;}

    }
}