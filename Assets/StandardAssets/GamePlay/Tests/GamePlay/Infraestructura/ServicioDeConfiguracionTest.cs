using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace StandardAssets.GamePlay.Tests.GamePlay.Infraestructura
{
    public class ServicioDeConfiguracionTest
    {
        ServicioDeConfiguracion servicio;
        RepositorioConfiguracion repositorio;
        ConfiguracionDelNivel configuracionDelNivel;
        ConfiguracionDePersona configuracionDePersona;
        Persona persona;

        [SetUp]
        public void setup()
        {
            repositorio = Substitute.For<RepositorioConfiguracion>();
            servicio = new ServicioDeConfiguracion(repositorio);
            configuracionDelNivel = Substitute.For<ConfiguracionDelNivel>();
            configuracionDePersona = Substitute.For<ConfiguracionDePersona>();
            persona = Substitute.For<Persona>();

            var listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>();
            listaDeConfiguracionDePersonas.Add(configuracionDePersona);
            configuracionDelNivel.DarConfiguracionesDePersona().Returns(listaDeConfiguracionDePersonas);
        }

        [Test]
        public void dar_tiempo_del_nivel()
        {
            var tiempoDelNivel = 10;
            configuracionDelNivel.TiempoDelNivel().Returns(tiempoDelNivel);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);
            servicio.DarNivelActual();

            var resultado = servicio.DarTiempoDelNivel();

            Assert.AreEqual(tiempoDelNivel, resultado);
        }

        [Test]
        public void obtener_una_persona()
        {
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);
            servicio.DarNivelActual();

            var resultado = servicio.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(configuracionDePersona, resultado);
        }
        
        
        [Test]
        public void dar_limite_de_poblacion_con_covid()
        {
            var limiteDePoblacionConCovid = 10;
            configuracionDelNivel.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);
            servicio.DarNivelActual();

            var resultado = servicio.DarLimiteDePoblacionConCovid();

            Assert.AreEqual(limiteDePoblacionConCovid, resultado);
        }

        [Test]
        public void decir_que_el_nivel_es_ganador()
        {
            var esGanador = true;
            repositorio.DarCantidadDeInfectadosConCovid().Returns(3);
            var limiteDePoblacionConCovid = 10;
            configuracionDelNivel.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);
            servicio.DarNivelActual();

            var resultado = servicio.EsGanadorDelNivel();

            Assert.IsTrue(resultado);
        }

        [Test]
        public void decir_que_el_nivel_no_es_ganador()
        {
            var esGanador = false;
            repositorio.DarCantidadDeInfectadosConCovid().Returns(10);
            var limiteDePoblacionConCovid = 10;
            configuracionDelNivel.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);
            servicio.DarNivelActual();

            var resultado = servicio.EsGanadorDelNivel();

            Assert.IsFalse(resultado);
        }

        [Test]
        [Ignore("No se puede mockear un scriptableObject")]
        public void dar_primer_nivel()
        {
            var listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>();
            listaDeConfiguracionDePersonas.Add(configuracionDePersona);
            configuracionDelNivel.DarConfiguracionesDePersona().Returns(listaDeConfiguracionDePersonas);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionDelNivel);

            servicio.DarPrimerNivel();

            repositorio.Received(1).DarPrimerNivel();
        }

        [Test]
        public void hay_otro_nivel()
        {
            repositorio.TotalDeNiveles().Returns(5);
            repositorio.NumeroDeNivelActual().Returns(4);

            var resultado = servicio.HayUnSiguienteNivel();

            Assert.IsTrue(resultado);
        }

        [Test]
        public void no_hay_otro_nivel()
        {
            repositorio.TotalDeNiveles().Returns(5);
            repositorio.NumeroDeNivelActual().Returns(5);

            var resultado = servicio.HayUnSiguienteNivel();

            Assert.IsFalse(resultado);
        }
    }
}