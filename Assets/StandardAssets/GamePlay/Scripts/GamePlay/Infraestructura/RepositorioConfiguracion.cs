using System.Collections.Generic;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class RepositorioConfiguracion
    {
        private ConfiguracionGeneral configuracion;
        private ConfiguracionDelNivel configuracionDelNivel;

        private List<ConfiguracionDelNivel> listaDeConfiguracionDeNiveles;
        private int contadorDeContagiados;
        private int contadorDeNiveles;

        protected RepositorioConfiguracion(){}
        
        public RepositorioConfiguracion(ConfiguracionGeneral configuracion)
        {
            this.configuracion = configuracion;
            listaDeConfiguracionDeNiveles = new List<ConfiguracionDelNivel>(configuracion.DarConfiguracionDeNiveles());
            contadorDeContagiados = 0;
            contadorDeNiveles = 0;
        }

        public virtual ConfiguracionDelNivel DarConfiguracionDelPrimerNivel()
        {
            configuracionDelNivel = DarConfiguracionDelNivel(0);
            contadorDeNiveles = 1;
            contadorDeContagiados = 0;
            return configuracionDelNivel;
        }
        
        public virtual ConfiguracionDelNivel DarConfiguracionDelSiguienteNivel()
        {
            configuracionDelNivel = DarConfiguracionDelNivel(contadorDeNiveles);
            contadorDeNiveles = contadorDeNiveles + 1;
            contadorDeContagiados = 0;
            return configuracionDelNivel;
        }

        private ConfiguracionDelNivel DarConfiguracionDelNivel(int numeroDeNivel)
        {
            return listaDeConfiguracionDeNiveles[numeroDeNivel];
        }

        public virtual int DarCantidadDeInfectadosConCovid()
        {
            return contadorDeContagiados;
        }

        public virtual void IncrementarCantidadDeContagiados()
        {
            contadorDeContagiados = contadorDeContagiados + 1;
        }
        
        public virtual int TotalDeNiveles()
        {
            return listaDeConfiguracionDeNiveles.Count;
        }
        
        public virtual int NumeroDeNivelActual()
        {
            return contadorDeNiveles;
        }
    }
}
