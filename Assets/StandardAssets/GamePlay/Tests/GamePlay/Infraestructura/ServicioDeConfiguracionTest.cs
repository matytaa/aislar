using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Tests.GamePlay.Infraestructura
{
    public class ServicioDeConfiguracionTest
    {
        ServicioDeConfiguracion servicio;
        RepositorioConfiguracion repositorio;
        ConfiguracionGeneral configuracionGeneral;
        ConfiguracionDePersona configuracionDePersona;
        Persona persona;

        [SetUp]
        public void setup()
        {
            repositorio = Substitute.For<RepositorioConfiguracion>();
            servicio = new ServicioDeConfiguracion(repositorio);
            configuracionGeneral = Substitute.For<ConfiguracionGeneral>();
            configuracionDePersona = Substitute.For<ConfiguracionDePersona>();
            persona = Substitute.For<Persona>();
        }

        [Test]
        public void dar_tiempo_del_nivel()
        {
            var tiempoDelNivel = 10;
            configuracionGeneral.TiempoDelNivel().Returns(tiempoDelNivel);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionGeneral);

            var resultado = servicio.DarTiempoDelNivel();

            Assert.AreEqual(tiempoDelNivel, resultado);
        }

        [Test]
        public void obtener_una_persona()
        {
            repositorio.DarConfiguracionDeUnaPersona().Returns(configuracionDePersona);

            var resultado = servicio.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(configuracionDePersona, resultado);
        }
        
        
        [Test]
        public void dar_limite_de_poblacion_con_covid()
        {
            var limiteDePoblacionConCovid = 10;
            configuracionGeneral.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionGeneral);

            var resultado = servicio.DarLimiteDePoblacionConCovid();

            Assert.AreEqual(limiteDePoblacionConCovid, resultado);
        }

        [Test]
        public void decir_que_el_nivel_es_ganador()
        {
            var esGanador = true;
            repositorio.DarCantidadDeInfectadosConCovid().Returns(3);
            var limiteDePoblacionConCovid = 10;
            configuracionGeneral.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionGeneral);

            var resultado = servicio.EsGanadorDelNivel();

            Assert.IsTrue(resultado);
        }

        [Test]
        public void decir_que_el_nivel_no_es_ganador()
        {
            var esGanador = false;
            repositorio.DarCantidadDeInfectadosConCovid().Returns(10);
            var limiteDePoblacionConCovid = 10;
            configuracionGeneral.LimiteDePoblacionConCovid().Returns(limiteDePoblacionConCovid);
            repositorio.DarConfiguracionDelNivel().Returns(configuracionGeneral);

            var resultado = servicio.EsGanadorDelNivel();

            Assert.IsFalse(resultado);
        }
    }
}