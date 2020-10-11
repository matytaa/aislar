using System;

namespace Scripts.GamePlay.Presentacion
{
    public interface GamePlayView
    {
        event Action OnVistaHabilitada;
        void IniciarTimer();
    }
}