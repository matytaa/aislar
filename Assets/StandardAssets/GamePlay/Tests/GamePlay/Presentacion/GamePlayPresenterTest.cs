using NSubstitute;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design;
using Scripts.GamePlay.Presentacion;
using System;

namespace Tests.Presentacion
{
    public class GamePlayPresenterTest
    {
        GamePlayView vista;
        GamePlayPresenter presenter;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<GamePlayView>();
            GamePlayPresenter presenter = new GamePlayPresenter(vista);
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
    }
}
