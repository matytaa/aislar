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
            repositorio.ActualizarCantidadAislados();

            Assert.AreEqual(1, repositorio.CantidadActualDeAislados());
            Assert.AreEqual(10, repositorio.TopeDeAislados());
        }

        [Test]
        public void reiniciar_cuenta_de_aislados()
        {
            repositorio.ActualizarCantidadAislados();

            repositorio.ReiniciarCuentaDeAislados();

            Assert.AreEqual(0, repositorio.CantidadActualDeAislados());
        }
    }
}
