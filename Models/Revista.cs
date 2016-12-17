using System.Collections.Generic;
namespace Publicaciones.Models{

    public class Revista{

        public string Issn{set;get;}
        public string Nombre{set;get;}
        public List<Publicacion> listaPublicacion;
    }
}