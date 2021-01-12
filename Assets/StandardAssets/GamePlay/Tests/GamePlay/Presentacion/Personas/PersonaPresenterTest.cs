using NSubstitute;
using NUnit.Framework;
using Scripts.GamePlay.Presentacion;
using System;
using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;

namespace Tests.Presentacion.Personas
{
    public class PersonaPresenterTest
    {
        PersonaVista vista;
        PersonaPresenter presenter;
        IntermediarioConLaBarraDeProgreso intermediario;
        ObtenerPersonaAction obtenerPersonaAction;
        ServicioDeAislados servicio;
        Persona persona;
        const float temperatura = 35.9f;

        [SetUp]
        public void setup()
        {
            persona = Substitute.For<Persona>();
            vista = Substitute.For<PersonaVista>();
            intermediario = Substitute.For<IntermediarioConLaBarraDeProgreso>();
            servicio = Substitute.For<ServicioDeAislados>();
            obtenerPersonaAction = Substitute.For<ObtenerPersonaAction>();
            obtenerPersonaAction.Ejecutar().Returns(persona);
            
            presenter = new PersonaPresenter(vista, obtenerPersonaAction, intermediario, servicio);
        }

        [Test]
        public void iniciar_recorrido()
        {
            obtenerPersonaAction.Ejecutar().Returns(persona);
            
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).IniciarRecorrido(Arg.Any<Carril>());
        }

        [Test]
        public void dar_temperatura()
        {
            persona.Temperatura().Returns(temperatura);
            
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
            servicio.Received(1).ActualizarAislados();
        }
        
        [Test]
        public void al_finalizar_recorrido_y_la_persona_tiene_covid_avisarle_a_la_barra_de_progreso()
        {
            persona.TieneCovid().Returns(true);
            obtenerPersonaAction.Ejecutar().Returns(persona);

            vista.OnRecorridoTerminado += Raise.Event<Action>();

            intermediario.Received(1).DecrementarBarra();
        } 
        
        [Test]
        public void al_finalizar_recorrido_y_la_persona_no_tiene_covid_no_tengo_que_avisarle_a_la_barra_de_progreso()
        {
            persona.TieneCovid().Returns(false);
            obtenerPersonaAction.Ejecutar().Returns(persona);

            vista.OnRecorridoTerminado += Raise.Event<Action>();

            intermediario.DidNotReceive().DecrementarBarra();
        }
    }
}
