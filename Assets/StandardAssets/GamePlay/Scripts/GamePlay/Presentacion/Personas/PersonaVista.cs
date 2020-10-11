using System;

namespace Scripts.GamePlay.Presentacion
{
    public interface PersonaVista
    {
        event Action OnVistaHabilitada;
        void MoverALaPersona();
    }
}