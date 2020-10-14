using NSubstitute;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design;
using Scripts.GamePlay.Presentacion;
using System;
using Scripts.GamePlay.Dominio;

namespace Tests.Presentacion.Personas
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
