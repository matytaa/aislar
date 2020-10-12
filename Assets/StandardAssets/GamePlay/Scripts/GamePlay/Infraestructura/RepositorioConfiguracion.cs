using Scripts.GamePlay.Vistas;
namespace Scripts.GamePlay.Infraestructura
{
    public class RepositorioConfiguracion
    {
        private ConfiguracionDePersona configuracion;
        
        public RepositorioConfiguracion(ConfiguracionDePersona configuracion)
        {
            this.configuracion = configuracion;
        }

        public ConfiguracionDePersona DarConfiguracion()
        {
            return configuracion;
        }
    }
}
