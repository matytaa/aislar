using NSubstitute;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design;
using Scripts.GamePlay.Presentacion;
using System;
using Scripts.GamePlay.Dominio;

namespace Tests.Presentacion.Personas
{
    public class PersonaPresenterTest
    {
        PersonaVista vista;
        PersonaPresenter presenter;
        Persona persona;
        const float temperatura = 35.9f;

        [SetUp]
        public void setup()
        {
            persona = new Persona(temperatura, false);
            vista = Substitute.For<PersonaVista>();
            presenter = new PersonaPresenter(vista, persona);
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

            vista.Received(1).DarTemperatura(temperatura);
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
