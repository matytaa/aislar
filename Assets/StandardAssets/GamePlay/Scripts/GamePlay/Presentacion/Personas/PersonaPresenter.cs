using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        readonly Persona persona;

        public PersonaPresenter(PersonaVista vista, Persona persona)
        {
            this.vista = vista;
            this.persona = persona;

            this.vista.OnVistaHabilitada += MoverALaPersona;
            this.vista.OnDarTemperatura += HabilitarBotonAislarYDarTemperatura;
            this.vista.OnBotonAislarClikeado += ApagarContenedoPersona;
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
    }
}