using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using UniRx;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Presentacion
{ 
    public class GamePlayPresenter
    {
        readonly GamePlayView vista;
        readonly IObservable<Aislados> aislados;
        readonly ServicioDeConfiguracion servicioDeConfiguracion;

        public GamePlayPresenter(GamePlayView vista, 
            IObservable<Aislados> aislados, 
            ServicioDeConfiguracion servicioDeConfiguracion)
        {
            this.vista = vista;
            this.aislados = aislados;
            this.servicioDeConfiguracion = servicioDeConfiguracion;
            this.vista.OnVistaHabilitada += ConfigurarNivel;
            this.vista.OnTimerFinaliza += MostrarGameOver;
            this.vista.OnBarraDeProgresoAgotada += MostrarGameOver;

            PrepararseParaActualizarLaVista();
        }

        private void ConfigurarNivel()
        {
            ConfigurarLimiteDePersonasConCovid();
            IniciarTimer();
        }

        private void IniciarTimer()
        {
            vista.IniciarTimer(servicioDeConfiguracion.DarTiempoDelNivel());
        }
        
        private void ConfigurarLimiteDePersonasConCovid()
        {
            vista.ConfigurarLimiteDePersonasConCovid(servicioDeConfiguracion.DarLimiteDePoblacionConCovid());
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