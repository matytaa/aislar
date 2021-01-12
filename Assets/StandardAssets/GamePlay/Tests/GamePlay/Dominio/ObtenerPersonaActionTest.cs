using NSubstitute;
using NUnit.Framework;
using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;

namespace Tests.GamePlay.Dominio
{
    public class ObtenerPersonaActionTest
    {
        ServicioDeConfiguracion servicioDeConfiguracion;
        ObtenerPersonaAction obtenerPersonaAction;

        ConfiguracionDePersona configuracionDePersona;
        Persona persona;

        [SetUp]
        public void setup()
        {
            servicioDeConfiguracion = Substitute.For<ServicioDeConfiguracion>();
            obtenerPersonaAction = new ObtenerPersonaAction(servicioDeConfiguracion);

            configuracionDePersona = new ConfiguracionDePersona();
            
            persona = Substitute.For<Persona>();
        }

        [Test]
        public void obtener_una_persona_de_la_configuracion()
        {
            var temperatura = 36.0f;
            configuracionDePersona.temperatura = temperatura;
            configuracionDePersona.tieneCovid = false;
            servicioDeConfiguracion.DarConfiguracionDeUnaPersona().Returns(configuracionDePersona);

            var resultado = obtenerPersonaAction.Ejecutar();
            
            Assert.IsFalse(resultado.TieneCovid());
            Assert.AreEqual(temperatura, resultado.Temperatura());
        }
    }
}