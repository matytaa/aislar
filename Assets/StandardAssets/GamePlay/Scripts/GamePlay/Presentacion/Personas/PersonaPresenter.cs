using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;

namespace Scripts.GamePlay.Presentacion
{ 
    public class PersonaPresenter
    {
        readonly PersonaVista vista;
        readonly Persona persona;
        readonly IntermediarioConLaBarraDeProgreso intermediario;
        readonly ServicioDeAislados servicio;

        public PersonaPresenter(PersonaVista vista, 
            Persona persona,
            IntermediarioConLaBarraDeProgreso intermediario,
            ServicioDeAislados servicio)
        {
            this.vista = vista;
            this.persona = persona;
            this.intermediario = intermediario;
            this.servicio = servicio;

            this.vista.OnVistaHabilitada += IniciarRecorrido;
            this.vista.OnDarTemperatura += HabilitarBotonAislarYDarTemperatura;
            this.vista.OnBotonAislarClikeado += OnBotonAislarEsClikeado;
            this.vista.OnRecorridoTerminado += DecrementarBarraSiLoNecesita;
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