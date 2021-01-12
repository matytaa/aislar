using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Tests.GamePlay.Infraestructura
{
    public class RepositorioDeAisladosTest
    {
        RepositorioDeAislados repositorio;
        int topeDeAislados = 10;

        [SetUp]
        public void setup()
        {
            repositorio = new RepositorioDeAislados(topeDeAislados);
        }

        [Test]
        public void actualizar_cantidad_de_aislados()
        {
            var result = repositorio.DarAisladosActualizados();

            Assert.AreEqual(1, result.CantidadActualDeAislados());
            Assert.AreEqual(10, result.TopeDeAislados());
        }
    }
}
