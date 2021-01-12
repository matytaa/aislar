using System;
using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using UniRx;

namespace StandardAssets.GamePlay.Tests.GamePlay.Presentacion
{
    public class GamePlayPresenterTest
    {
        GamePlayView vista;
        GamePlayPresenter presenter;
        Subject<Aislados> aisladosSubject;
        ServicioDeConfiguracion servicio;
        Aislados aislados;
        private int tiempoDelNivel = 10;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<GamePlayView>();
            aisladosSubject = new Subject<Aislados>();
            servicio = Substitute.For<ServicioDeConfiguracion>();
            GamePlayPresenter presenter = new GamePlayPresenter(vista, aisladosSubject, servicio);

            aislados = Substitute.For<Aislados>();
        }

        [Test]
        public void iniciar_tiempo_cuando_se_habilita_la_vista()
        {
            servicio.DarTiempoDelNivel().Returns(tiempoDelNivel);
            
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).IniciarTimer(Arg.Is(tiempoDelNivel));
        }
        
        [Test]
        public void mostrar_game_over_cuando_el_termina()
        {
            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).MostrarGameOver();
        }

        [Test]
        public void mostrar_game_over_cuando_la_barra_de_progreso_se_haya_agotado()
        {
            vista.OnBarraDeProgresoAgotada += Raise.Event<Action>();

            vista.Received(1).MostrarGameOver();
        }

        [Test]
        public void actualizar_cantidad_de_aislados()
        {
            aisladosSubject.OnNext(aislados);

            vista.Received(1).ActualizarCantidadDeAislados(Arg.Is(aislados));
        }
        
        [Test]
        public void no_actualizar_cantidad_de_aislados_cuando_llenamos_el_cupo()
        {
            aislados.ElCupoEstaCompleto().Returns(true);

            aisladosSubject.OnNext(aislados);

            vista.DidNotReceive().ActualizarCantidadDeAislados(Arg.Is(aislados));
        }
    }
}
