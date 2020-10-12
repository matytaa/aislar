using System;

namespace Scripts.GamePlay.Presentacion
{
    public interface PersonaVista
    {
        event Action OnVistaHabilitada;
        event Action OnDarTemperatura;
        void MoverALaPersona();
        void DarTemperatura();
    }
}