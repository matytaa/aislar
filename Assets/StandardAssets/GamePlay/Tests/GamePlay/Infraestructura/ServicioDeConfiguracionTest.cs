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
    }
}