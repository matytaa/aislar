﻿using System;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Presentacion
{
    public interface GamePlayView
    {
        event Action OnVistaHabilitada;
        event Action OnTimerFinaliza;
        event Action OnBarraDeProgresoAgotada;
        void IniciarTimer();
        void MostrarGameOver();
        void ActualizarCantidadDeAislados(Aislados aislados);
    }
}