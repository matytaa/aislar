using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Presentacion
{
    public interface GamePlayView
    {
        event Action OnVistaHabilitada;
        event Action OnTimerFinaliza;
        event Action OnBarraDeProgresoAgotada;
        void IniciarTimer(int tiempoDelNivel);
        void MostrarGameOver();
        void ActualizarCantidadDeAislados(Aislados aislados);
    }
}