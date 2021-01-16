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
            this.vista.OnVistaHabilitada += MostrarPanelDeIniciarJuego;
            this.vista.OnBotonStartEsClickeado += IniciarPrimerNivel;
            this.vista.OnBotonNextLevelEsClickeado += IniciarOtroNivel;
            this.vista.OnTimerFinaliza += MostrarGameOver;
            this.vista.OnBarraDeProgresoAgotada += MostrarGameOver;

            PrepararseParaActualizarLaVista();
        }

        private void MostrarPanelDeIniciarJuego()
        {
            vista.MostrarPopupDeStartGameONextLevel(false);
        }

        private void IniciarPrimerNivel()
        {
            servicioDeConfiguracion.DarPrimerNivel();
            IniciarNivel();
        }


        private void IniciarOtroNivel()
        {
            servicioDeConfiguracion.DarNivelActual();
            IniciarNivel();
        }

        private void IniciarNivel()
        {
            vista.ApagarPopUP();
            vista.InstanciarPersonas(servicioDeConfiguracion.DarTiempoDelNivel());
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
            vista.DestruirPersonas();
            var esGanador = servicioDeConfiguracion.EsGanadorDelNivel();
            var hayUnSiguienteNivel = servicioDeConfiguracion.HayUnSiguienteNivel();
            vista.MostrarGameOver(esGanador);
            var esGanadorYHayOtroNivel = (esGanador && hayUnSiguienteNivel);
            vista.MostrarPopupDeStartGameONextLevel(esGanadorYHayOtroNivel);
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