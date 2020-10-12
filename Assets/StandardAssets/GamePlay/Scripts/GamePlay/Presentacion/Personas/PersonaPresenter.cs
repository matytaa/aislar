namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        public PersonaPresenter(PersonaVista vista)
        {
            this.vista = vista;

            this.vista.OnVistaHabilitada += MoverALaPersona;
            this.vista.OnDarTemperatura += DarTemperatura;
        }

        void MoverALaPersona()
        {
            vista.MoverALaPersona();
        }
        
        void DarTemperatura()
        {
            vista.DarTemperatura();
        }
    }
}