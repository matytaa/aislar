using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Tests.GamePlay.Dominio
{
    public class NivelTest
    {
        private Nivel nivel;
        private ConfiguracionDePersona unaPersona;
        private ConfiguracionDePersona otraPersona;

        [SetUp]
        public void obtener_persona()
        {
            unaPersona = Substitute.For<ConfiguracionDePersona>();
            otraPersona = Substitute.For<ConfiguracionDePersona>();

            var configuracionDePersonas = new List<ConfiguracionDePersona>{unaPersona, otraPersona};
            
            nivel = new Nivel(0,0,0, configuracionDePersonas);
        }

        [Test]
        public void dar_primera_persona()
        {
            var resultado = nivel.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(unaPersona, resultado);
        }
        
        [Test]
        public void dar_segunda_persona()
        {
            nivel.DarConfiguracionDeUnaPersona();
            
            var resultado = nivel.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(otraPersona, resultado);
        }
        
        [Test]
        public void dar_primera_persona_otra_vez()
        {
            nivel.DarConfiguracionDeUnaPersona();
            nivel.DarConfiguracionDeUnaPersona();
            
            var resultado = nivel.DarConfiguracionDeUnaPersona();
            
            Assert.AreEqual(unaPersona, resultado);
        }
    }
}