namespace Publicaciones.Models
{
    ///<summary>
    ///Clase Persona
    ///Atributos
        ///Rut: Rut de la persona
        ///Nombre: Nombre de la persona
        ///Apellido: Apellido de la persona
        //Email: Correo de la persona
        ///FechaNacimiento: Fecha de nacimiento de la persona
        ///Nacionalidad: Nacionalidad de la persona
        ///Genero: genero de la persona, femenino o masculino
    ///<summary>
    ///<returns></returns>

    public class Persona
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email{get; set; }
        public string FechaNacimiento{get; set;}
        public string Nacionalidad{get; set;}
        public string Genero{get; set;}
        }

    }