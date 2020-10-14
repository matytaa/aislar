﻿using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        readonly Persona persona;
        readonly IntermediarioConLaBarraDeProgreso intermediario;

        public PersonaPresenter(PersonaVista vista, 
            Persona persona,
            IntermediarioConLaBarraDeProgreso intermediario)
        {
            this.vista = vista;
            this.persona = persona;
            this.intermediario = intermediario;

            this.vista.OnVistaHabilitada += MoverALaPersona;
            this.vista.OnDarTemperatura += HabilitarBotonAislarYDarTemperatura;
            this.vista.OnBotonAislarClikeado += ApagarContenedoPersona;
            this.vista.OnRecorridoTerminado += DecrementarBarraSiLoNecesita;
        }

        void MoverALaPersona()
        {
            vista.MoverALaPersona();
        }
        
        void HabilitarBotonAislarYDarTemperatura()
        {
            vista.HabilitarBotonAislar();
            vista.DarTemperatura(persona.Temperatura());
        }      
        
        void ApagarContenedoPersona()
        {
            vista.ApagarContenedoPersona();
        }

        void DecrementarBarraSiLoNecesita()
        {
            if(persona.TieneCovid())
                intermediario.DecrementarBarra();
        }
    }
}