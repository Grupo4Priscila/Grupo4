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

            // Debe haber solo 4
            Assert.True(pub.Count == 2);
//PRUEBA ESTADOS DE PUBLICACION
            // PUBLICACIONES en la BD
            List<EstadoDePostulacion> estado = Service.EstadoDePostulaciones();

            // Debe ser !=  de null
            Assert.True(estado != null);

            // Debe haber solo 4
            Assert.True(estado.Count == 0);


            // Print de la persona
            foreach(Persona persona in personas) {
                Logger.LogInformation("Persona: {0}", persona);
            }

            Logger.LogInformation("Test IMainService.Initialize() ok");
        }

        void IDisposable.Dispose()
        {
            // Aca eliminar el Service
        }
    }

}