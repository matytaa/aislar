using Scripts.GamePlay.Vistas;
namespace Scripts.GamePlay.Infraestructura
{
    public class RepositorioConfiguracion
    {
        private ConfiguracionGeneral configuracion;
        
        public RepositorioConfiguracion(ConfiguracionGeneral configuracion)
        {
            this.configuracion = configuracion;
        }

        public ConfiguracionDePersona DarConfiguracion()
        {
            return null;
        }
    }
}
