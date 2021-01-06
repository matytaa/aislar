using NSubstitute;
using NUnit.Framework;
using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;
using UniRx;
using System;

namespace Tests.GamePlay.Infraestructura
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
