using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;
using System.Collections.Generic;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class ServicioDeConfiguracion
    {
        private readonly RepositorioConfiguracion repositorioConfiguracion;
        private List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;
        private Nivel nivelActual;
        protected ServicioDeConfiguracion(){}
        
        public ServicioDeConfiguracion(RepositorioConfiguracion repositorioConfiguracion)
        {
            this.repositorioConfiguracion = repositorioConfiguracion;
        }

        public virtual Nivel DarPrimerNivel()
        {
            GenerarNivel(repositorioConfiguracion.DarConfiguracionDelPrimerNivel());
            return nivelActual;
        }

        public virtual Nivel DarSiguienteNivel()
        {
            GenerarNivel(repositorioConfiguracion.DarConfiguracionDelSiguienteNivel());
            return nivelActual;
        }

        public virtual ConfiguracionDePersona DarConfiguracionDeUnaPersona()
        {
            return nivelActual.DarConfiguracionDeUnaPersona();
        }

        public virtual bool EsGanadorDelNivel()
        {
            return repositorioConfiguracion.DarCantidadDeInfectadosConCovid() < nivelActual.LimiteDePoblacionConCovid;
        }

        public virtual void IncrementarCantidadDeContagiados()
        {
            repositorioConfiguracion.IncrementarCantidadDeContagiados();
        }

        public virtual bool HayUnSiguienteNivel()
        {

            return repositorioConfiguracion.TotalDeNiveles() > repositorioConfiguracion.NumeroDeNivelActual();
        }

        private void GenerarNivel(ConfiguracionDelNivel configuracionDeNivel)
        {
            nivelActual = new Nivel(configuracionDeNivel.TiempoDelNivel(),
                configuracionDeNivel.TopeDeAislados(),
                configuracionDeNivel.LimiteDePoblacionConCovid(),
                configuracionDeNivel.DarConfiguracionesDePersona());
        }
    }
}