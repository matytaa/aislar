using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Presentacion
{
    public interface GamePlayView
    {
        event Action OnVistaHabilitada;
        event Action OnTimerFinaliza;
        event Action OnBarraDeProgresoAgotada;
        event Action OnBotonStartEsClickeado;
        event Action OnBotonNextLevelEsClickeado;
        void IniciarTimer(int tiempoDelNivel);
        void MostrarGameOver(bool esGanador);
        void ActualizarCantidadDeAislados(Aislados aislados);
        void ConfigurarLimiteDePersonasConCovid(int limiteDePersonasConCovid);
        void ApagarOPrenderPanelDeBotones(bool prendido);
        void InstanciarPersonas();
        void DejarDeInstanciarPersonas();
        void ApagarOPrenderBotonNextLevel(bool prendido);
    }
}