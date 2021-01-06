using UniRx;
using System;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Presentacion
{ 
    public class GamePlayPresenter
    {
        readonly GamePlayView vista;
        readonly IObservable<Aislados> aislados;

        public GamePlayPresenter(GamePlayView vista, IObservable<Aislados> aislados)
        {
            this.vista = vista;
            this.aislados = aislados;
            this.vista.OnVistaHabilitada += IniciarTimer;
            this.vista.OnTimerFinaliza += MostrarGameOver;
            this.vista.OnBarraDeProgresoAgotada += MostrarGameOver;

            PrepararseParaActualizarLaVista();
        }

        private void IniciarTimer()
        {
            vista.IniciarTimer();
        }
        
        private void MostrarGameOver()
        {
            vista.MostrarGameOver();
        }

        private void PrepararseParaActualizarLaVista()
        {
            this.aislados
                .Where(aislados => !aislados.ElCupoEstaCompleto())
                .Do(vista.ActualizarCantidadDeAislados)
                .Subscribe();
        }
    }
}