﻿using System;
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
            vista.PlayMusica("lobby", true);
            vista.MostrarPopupDeStartGameONextLevel(false);
        }

        private void IniciarPrimerNivel()
        {
            IniciarNivel(servicioDeConfiguracion.DarPrimerNivel());
        }

        private void IniciarOtroNivel()
        {
            IniciarNivel(servicioDeConfiguracion.DarSiguienteNivel());
        }

        private void IniciarNivel(Nivel nivel)
        {
            vista.PlayMusica("gamePlay", true);
            vista.ApagarPopUP();
            vista.InstanciarPersonas(nivel.TiempoDelNivel);
            vista.ConfigurarLimiteDePersonasConCovid(nivel.LimiteDePoblacionConCovid);
            vista.IniciarTimer(nivel.TiempoDelNivel);
            vista.ConfigurarTopeDeAislados(nivel.TopeDeAislados);
        }

        private void IniciarTimer()
        {
            
        }
        
        private void MostrarGameOver()
        {
            vista.DestruirPersonas();
            var esGanador = servicioDeConfiguracion.EsGanadorDelNivel();
            var hayUnSiguienteNivel = servicioDeConfiguracion.HayUnSiguienteNivel();
            vista.MostrarGameOver(esGanador);
            var esGanadorYHayOtroNivel = (esGanador && hayUnSiguienteNivel);
            if (!esGanadorYHayOtroNivel) vista.PlayMusica("lobby", true);
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