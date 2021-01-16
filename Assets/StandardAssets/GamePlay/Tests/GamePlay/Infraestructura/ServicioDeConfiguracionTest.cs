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
        
        [SetUp]
        public void setup()
        {
            repositorio = Substitute.For<RepositorioConfiguracion>();
            servicio = new ServicioDeConfiguracion(repositorio);
            configuracionDelNivel = Substitute.For<ConfiguracionDelNivel>();
            configuracionDePersona = Substitute.For<ConfiguracionDePersona>();

            var listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>();
            listaDeConfiguracionDePersonas.Add(configuracionDePersona);
            configuracionDelNivel.DarConfiguracionesDePersona().Returns(listaDeConfiguracionDePersonas);            
        }

        [Test]
        public void obtener_una_persona()
        {
            repositorio.DarConfiguracionDelSiguienteNivel().Returns(configuracionDelNivel);
            servicio.DarSiguienteNivel();

            var resultado = servicio.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(configuracionDePersona, resultado);
        }

        [Test]
        public void decir_que_el_nivel_es_ganador()
        {
            var esGanador = true;
            repositorio.DarCantidadDeInfectadosConCovid().Returns(3);
            var limiteDePoblacionConCovid = 10;
            configuracionDelNivel.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelSiguienteNivel().Returns(configuracionDelNivel);
            servicio.DarSiguienteNivel();

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
            repositorio.DarConfiguracionDelSiguienteNivel().Returns(configuracionDelNivel);
            servicio.DarSiguienteNivel();

            var resultado = servicio.EsGanadorDelNivel();

            Assert.IsFalse(resultado);
        }

        [Test]
        public void obtener_primer_nivel()
        {
            configuracionDelNivel.TiempoDelNivel().Returns(0);
            configuracionDelNivel.DarConfiguracionesDePersona().Returns(new List<ConfiguracionDePersona>());
            repositorio.DarConfiguracionDelPrimerNivel().Returns(configuracionDelNivel);
                
            var nivel = servicio.DarPrimerNivel();

            Assert.AreEqual(0, nivel.TiempoDelNivel);
        }
        
        [Test]
        public void obtener_otro_nivel()
        {
            configuracionDelNivel.TiempoDelNivel().Returns(0);
            configuracionDelNivel.DarConfiguracionesDePersona().Returns(new List<ConfiguracionDePersona>());
            repositorio.DarConfiguracionDelSiguienteNivel().Returns(configuracionDelNivel);
                
            var nivel = servicio.DarSiguienteNivel();

            Assert.AreEqual(0, nivel.TiempoDelNivel);
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