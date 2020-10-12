using System;

namespace Scripts.GamePlay.Presentacion
{
    public interface PersonaVista
    {
        event Action OnVistaHabilitada;
        event Action OnDarTemperatura;
        event Action OnBotonAislarClikeado;
        void MoverALaPersona();
        void DarTemperatura(float temperatura);
        void HabilitarBotonAislar();
        void ApagarContenedoPersona();
    }
}