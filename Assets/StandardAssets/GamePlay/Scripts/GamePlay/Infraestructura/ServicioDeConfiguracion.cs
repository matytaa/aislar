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

        public virtual int DarLimiteDePoblacionConCovid()
        {
            return repositorioConfiguracion.DarConfiguracionDelNivel().LimiteDePoblacionConCovid();
        }
        
        public virtual bool EsGanadorDelNivel()
        {
            return repositorioConfiguracion.DarCantidadDeInfectadosConCovid() < DarLimiteDePoblacionConCovid();
        }
    }
}