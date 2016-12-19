using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Publicaciones.Backend;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Publicaciones.Models;

namespace Publicaciones.Service {

    public class MainServiceTest : IDisposable
    {
        IMainService Service { get; set; }

        ILogger Logger { get; set; }

        public MainServiceTest()
        {
            // Logger Factory
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
            Logger = loggerFactory.CreateLogger<MainServiceTest>();

            Logger.LogInformation("Initializing Test ..");

            // SQLite en memoria
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            // Opciones de inicializacion del BackendContext
            var options = new DbContextOptionsBuilder<BackendContext>()
            .UseSqlite(connection)
            .Options;

            // inicializacion del BackendContext
            BackendContext backend = new BackendContext(options);
            // Crear la base de datos
            backend.Database.EnsureCreated();

            // Servicio a probar
            Service = new MainService(backend, loggerFactory);


            Logger.LogInformation("Initialize Test ok.");
        }


        [Fact]
        public void InitializeTest()
        {
            Logger.LogInformation("Testing IMainService.Initialize() ..");
            Service.Initialize();

            // No se puede inicializar 2 veces
            Assert.Throws<Exception>( () => { Service.Initialize(); });

//PRUEBA PERSONA
            // Personas en la BD
            List<Persona> personas = Service.Personas();

            // Debe ser !=  de null
            Assert.True(personas != null);

            // Debe haber solo 3
            Assert.True(personas.Count == 3);
//PRUEBA AUTOR
            // Autor en la BD
            List<Autor> autor = Service.Autores();

            // Debe ser !=  de null
            Assert.True(autor != null);

            // Debe haber solo 4
            Assert.True(autor.Count == 4);

//PRUEBA PAPER
            // PAPER en la BD
            List<Paper> paper = Service.Papers();

            // Debe ser !=  de null
            Assert.True(paper != null);

            // Debe haber solo 4
            Assert.True(paper.Count == 2);
//PRUEBA PUBLICACIONES
            // PUBLICACIONES en la BD
            List<Publicacion> pub = Service.Publicaciones();

            // Debe ser !=  de null
            Assert.True(pub != null);

            // Debe haber solo 2
            Assert.True(pub.Count == 2);
//PRUEBA ESTADOS DE PUBLICACION
            // PUBLICACIONES en la BD
            List<EstadoDePostulacion> estado = Service.EstadoDePostulaciones();

            // Debe ser !=  de null
            Assert.True(estado != null);

            // Debe haber solo 4
            Assert.True(estado.Count == 3);


            // Print de la persona
            foreach(Persona persona in personas) {
                Logger.LogInformation("Persona: {0}", persona);
            }

            Logger.LogInformation("Test IMainService.Initialize() ok");
        }
        
        [Fact]
        public void pruebaPublicaciones(){

        Logger.LogInformation("Testing ImainService.pruebaPublicaciones().......");
        Service.Initialize();

        //La persona 1 de nombre Diego, con rut a que escribio 1 publicacion
        string rut1= Service.FindPersonas("Diego").First().Rut;
        // es el rut de Diego
        Assert.True(rut1=="a");
        List<Publicacion> lp1= Service.Publicaciones(rut1);
        // se crea una lista
        Assert.True(lp1!=null);
        //la lista contiene 1 publicacion
        Assert.True(lp1.Count==0);

         // Print de la Publicacion
            foreach(Publicacion p in lp1) {
                Logger.LogInformation("Publicacion: {0}", p.Doi);
            }



        //La persona 2 de nombre Priscila, con rut b que escribio 2 publicacion
        string rut2= Service.FindPersonas("Priscila").First().Rut;
        // es el rut de Priscila
        Assert.True(rut2=="b");
        List<Publicacion> lp2= Service.Publicaciones(rut2);
        // se crea una lista
        Assert.True(lp2!=null);
        //la lista contiene 2 publicacion
        Assert.True(lp2.Count==0);
         // Print de la Publicacion
            foreach(Publicacion p in lp2) {
                Logger.LogInformation("Publicacion: {0}", p.Doi);
            }



        //La persona 3 de nombre Pepe, con rut a que escribio 1 publicacion
        string rut3= Service.FindPersonas("Pepe").First().Rut;
        // es el rut de Pepe
        Assert.True(rut3=="c");
        List<Publicacion> lp3= Service.Publicaciones(rut3);
        // se crea una lista
        Assert.True(lp3!=null);
        //la lista contiene 1 publicacion
        Assert.True(lp3.Count==0);

         // Print de la Publicacion
            foreach(Publicacion p in lp3) {
                Logger.LogInformation("Publicacion: {0}", p.Doi);
            }

        //rut no existente
        List<Publicacion> lp4= Service.Publicaciones("d");
        // Se crea una lista vacia
        Assert.True(lp4!=null);
        //la lista no contiene publicacion
        Assert.True(lp4.Count==0);
        
        // Print de la Publicacion
            foreach(Publicacion p in lp4) {
                Logger.LogInformation("Publicacion: {0}", p.Doi);
            }


        Logger.LogInformation("Test IMainService.pruebaPublicaciones() ok");

        }

        void IDisposable.Dispose()
        {
            // Aca eliminar el Service
        }
    }

}