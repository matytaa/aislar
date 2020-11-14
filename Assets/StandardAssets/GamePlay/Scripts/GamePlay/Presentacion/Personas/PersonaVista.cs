using System;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Presentacion
{
    public interface PersonaVista
    {
        event Action OnVistaHabilitada;
        event Action OnDarTemperatura;
        event Action OnBotonAislarClikeado;
        event Action OnRecorridoTerminado;
        void IniciarRecorrido(Carril carril);
        void DarTemperatura(float temperatura);
        void HabilitarBotonAislar();
        void ApagarContenedoPersona();
    }
}