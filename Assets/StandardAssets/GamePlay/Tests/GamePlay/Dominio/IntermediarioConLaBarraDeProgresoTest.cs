using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Tests.GamePlay.Dominio
{
    public class IntermediarioConLaBarraDeProgresoTest
    {
        IntermediarioConLaBarraDeProgreso intermediario;
        BarraDeProgresoVista vista;
        RepositorioConfiguracion repositorio;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<BarraDeProgresoVista>();
            repositorio = Substitute.For<RepositorioConfiguracion>();
            intermediario = new IntermediarioConLaBarraDeProgreso(vista, repositorio);
        }

        [Test]
        public void decremantar_barra_de_progreso()
        {
            intermediario.DecrementarBarra();

            vista.Received(1).DescontarEnLaBarraDeProgreso();
            repositorio.Received(1).IncrementarCantidadDeContagiados();
        }
    }
}
