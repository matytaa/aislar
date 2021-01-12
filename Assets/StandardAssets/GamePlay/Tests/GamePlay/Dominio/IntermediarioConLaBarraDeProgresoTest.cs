using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;

namespace StandardAssets.GamePlay.Tests.GamePlay.Dominio
{
    public class IntermediarioConLaBarraDeProgresoTest
    {
        IntermediarioConLaBarraDeProgreso intermediario;
        BarraDeProgresoVista vista;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<BarraDeProgresoVista>();
            intermediario = new IntermediarioConLaBarraDeProgreso(vista);
        }

        [Test]
        public void decremantar_barra_de_progreso()
        {
            intermediario.DecrementarBarra();

            vista.Received(1).DescontarEnLaBarraDeProgreso();
        }
    }
}
