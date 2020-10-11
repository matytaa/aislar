using NSubstitute;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design;
using Scripts.GamePlay.Presentacion;
using System;

namespace Tests.Presentacion.Personas
{
    public class PersonaPresenterTest
    {
        PersonaVista vista;
        PersonaPresenter presenter;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<PersonaVista>();
            presenter = new PersonaPresenter(vista);
        }

        [Test]
        public void mover_a_la_persona()
        {
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).MoverALaPersona();
        }
    }
}
