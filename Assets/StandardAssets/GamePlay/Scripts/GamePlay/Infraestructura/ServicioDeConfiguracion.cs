using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class ServicioDeConfiguracion
    {
        private readonly RepositorioConfiguracion repositorioConfiguracion;
        
        protected ServicioDeConfiguracion(){}
        
        public ServicioDeConfiguracion(RepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }

        public virtual int DarTiempoDelNivel()
        {
            return repositorioConfiguracion.DarConfiguracionDelNivel().TiempoDelNivel();
        }

        public virtual ConfiguracionDePersona DarConfiguracionDeUnaPersona()
        {
            return repositorioConfiguracion.DarConfiguracionDeUnaPersona();
        }
    }
}