namespace Publicaciones.Models{

    public class Formulario{

        public string Cpip{set;get;}
        public string Doi{set;get;}
        public string NombreIndice{set;get;}
        
        /*
            AutorPrincipal del paper
        */
        public Autor AutorPrincipal{set;get;}
        
    }
}