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
        ServicioDeConfiguracion servicio;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<BarraDeProgresoVista>();
            servicio = Substitute.For<ServicioDeConfiguracion>();
            intermediario = new IntermediarioConLaBarraDeProgreso(vista, servicio);
        }

        [Test]
        public void decremantar_barra_de_progreso()
        {
            intermediario.DecrementarBarra();

            vista.Received(1).DescontarEnLaBarraDeProgreso();
            servicio.Received(1).IncrementarCantidadDeContagiados();
        }
    }
}
