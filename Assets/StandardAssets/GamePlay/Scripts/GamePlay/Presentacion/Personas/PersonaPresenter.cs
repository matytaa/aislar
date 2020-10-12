namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        public PersonaPresenter(PersonaVista vista)
        {
            this.vista = vista;

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
            vista.DarTemperatura();
        }      
        
        void ApagarContenedoPersona()
        {
            vista.ApagarContenedoPersona();
        }
    }
}