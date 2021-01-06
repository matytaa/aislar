using NSubstitute;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Dominio;
using System;
using UniRx;

namespace Tests.Presentacion
{
    public class GamePlayPresenterTest
    {
        GamePlayView vista;
        GamePlayPresenter presenter;
        Subject<Aislados> aisladosSubject;
        Aislados aislados;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<GamePlayView>();
            aisladosSubject = new Subject<Aislados>();
            GamePlayPresenter presenter = new GamePlayPresenter(vista, aisladosSubject);

            aislados = Substitute.For<Aislados>();
        }

        [Test]
        public void iniciar_tiempo_cuando_se_habilita_la_vista()
        {
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).IniciarTimer();
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
