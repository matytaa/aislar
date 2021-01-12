using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Presentacion.Personas
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