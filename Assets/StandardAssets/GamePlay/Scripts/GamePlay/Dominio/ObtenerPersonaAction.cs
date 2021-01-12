using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class ObtenerPersonaAction
    {
        private readonly ServicioDeConfiguracion servicioDeConfiguracion;
        
        protected ObtenerPersonaAction(){}

        public ObtenerPersonaAction(ServicioDeConfiguracion servicioDeConfiguracion)
        {
            this.servicioDeConfiguracion = servicioDeConfiguracion;
        }

        public virtual Persona Ejecutar()
        {
            var configuracion = servicioDeConfiguracion.DarConfiguracionDeUnaPersona();
            return new Persona(configuracion.temperatura, configuracion.tieneCovid);;
        }
    }
}