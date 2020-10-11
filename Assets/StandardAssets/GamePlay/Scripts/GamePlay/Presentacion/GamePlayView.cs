using System;

namespace Scripts.GamePlay.Presentacion
{
    public interface GamePlayView
    {
        event Action OnVistaHabilitada;
        event Action OnTimerFinaliza;
        void IniciarTimer();
        void MostrarGameOver();
    }
}