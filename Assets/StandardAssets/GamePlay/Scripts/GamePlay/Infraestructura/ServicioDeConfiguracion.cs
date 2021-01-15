using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class ServicioDeConfiguracion
    {
        private readonly RepositorioConfiguracion repositorioConfiguracion;
        private List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;
        private ConfiguracionDelNivel configuracionDeNivelActual;
        protected ServicioDeConfiguracion(){}
        
        public ServicioDeConfiguracion(RepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }

        public virtual ConfiguracionDelNivel DarNivelActual()
        {
            configuracionDeNivelActual = repositorioConfiguracion.DarConfiguracionDelNivel();
            listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>(configuracionDeNivelActual.DarConfiguracionesDePersona());
            return configuracionDeNivelActual;
        }

        public virtual int DarTiempoDelNivel()
        {
            return configuracionDeNivelActual.TiempoDelNivel();
        }

        public virtual ConfiguracionDePersona DarConfiguracionDeUnaPersona()
        {
            if (listaDeConfiguracionDePersonas.Count() == 0)
                ClonarListaDeConfiguracionDePersonas();

            var configuracionDePersona = listaDeConfiguracionDePersonas.First();
            listaDeConfiguracionDePersonas.RemoveAt(0);
            return configuracionDePersona;
        }

        private void ClonarListaDeConfiguracionDePersonas()
        {
            listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>(configuracionDeNivelActual.DarConfiguracionesDePersona());
        }

        public virtual int DarLimiteDePoblacionConCovid()
        {
            return configuracionDeNivelActual.LimiteDePoblacionConCovid();
        }
        
        public virtual bool EsGanadorDelNivel()
        {
            return repositorioConfiguracion.DarCantidadDeInfectadosConCovid() < DarLimiteDePoblacionConCovid();
        }

        void ObtenerNivel()
        {
            configuracionDeNivelActual = repositorioConfiguracion.DarConfiguracionDelNivel();
        }

        public virtual void IncrementarCantidadDeContagiados()
        {
            repositorioConfiguracion.IncrementarCantidadDeContagiados();
        }

        public virtual bool HayUnSiguienteNivel()
        {

            var a = repositorioConfiguracion.TotalDeNiveles();
            var b = repositorioConfiguracion.NumeroDeNivelActual();
            return repositorioConfiguracion.TotalDeNiveles() > repositorioConfiguracion.NumeroDeNivelActual();
        }
    }
}