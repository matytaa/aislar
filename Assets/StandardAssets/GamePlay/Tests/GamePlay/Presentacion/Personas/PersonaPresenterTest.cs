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

        [Test]
        public void dar_temperatura()
        {
            vista.OnDarTemperatura += Raise.Event<Action>();

            vista.Received(1).DarTemperatura();
        }
        
        [Test]
        public void habilitar_boton_aislar()
        {
            vista.OnDarTemperatura += Raise.Event<Action>();

            vista.Received(1).HabilitarBotonAislar();
        }
        
        [Test]
        public void al_hacer_click_en_boton_aislar()
        {
            vista.OnBotonAislarClikeado += Raise.Event<Action>();

            vista.Received(1).ApagarContenedoPersona();
        }
    }
}
