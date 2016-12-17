namespace Publicaciones.Models{
    ///<summary>
    ///Clase Estado en que se encuentra la postulacion
    ///Atributos
        ///Tipo: Nombre de los estados por los que pasa el paper
        ///Fecha:Fecha en donde es de ese tipo
        ///revista: revista a la cual esta asociada la postulacion
    ///<summary>
    ///<returns></returns>
    public class EstadoDePostulacion{

        public string Tipo{set;get;}
        public string Fecha{set;get;}
        public Revista revista{set;get;}

    }
}