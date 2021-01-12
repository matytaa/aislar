using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;

namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        readonly ObtenerPersonaAction obtenerPersonaAction;
        readonly IntermediarioConLaBarraDeProgreso intermediario;
        readonly ServicioDeAislados servicio;
        
        private Persona persona;

        public PersonaPresenter(PersonaVista vista, 
            ObtenerPersonaAction obtenerPersonaAction,
            IntermediarioConLaBarraDeProgreso intermediario,
            ServicioDeAislados servicio)
        {
            this.vista = vista;
            this.obtenerPersonaAction = obtenerPersonaAction;
            this.intermediario = intermediario;
            this.servicio = servicio;
            

            this.vista.OnVistaHabilitada += IniciarRecorrido;
            this.vista.OnDarTemperatura += HabilitarBotonAislarYDarTemperatura;
            this.vista.OnBotonAislarClikeado += OnBotonAislarEsClikeado;
            this.vista.OnRecorridoTerminado += DecrementarBarraSiLoNecesita;
            
            persona = this.obtenerPersonaAction.Ejecutar();
        }

        void IniciarRecorrido()
        {
            vista.IniciarRecorrido(persona.DarCarril());
        }
        
        void HabilitarBotonAislarYDarTemperatura()
        {
            vista.HabilitarBotonAislar();
            vista.DarTemperatura(persona.Temperatura());
        }      
        
        void OnBotonAislarEsClikeado()
        {
            vista.ApagarContenedoPersona();
            servicio.ActualizarAislados();
        }

        void DecrementarBarraSiLoNecesita()
        {
            if(persona.TieneCovid())
                intermediario.DecrementarBarra();
        }
    }
}