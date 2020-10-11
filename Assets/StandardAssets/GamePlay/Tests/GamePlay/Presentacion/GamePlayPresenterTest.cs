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
        [Test]
        public void iniciar_tiempo_cuando_se_habilita_la_vista()
        {
            GamePlayView vista;
            vista = Substitute.For<GamePlayView>();
            GamePlayPresenter presenter = new GamePlayPresenter(vista);

            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).IniciarTimer();
        }
    }
}
