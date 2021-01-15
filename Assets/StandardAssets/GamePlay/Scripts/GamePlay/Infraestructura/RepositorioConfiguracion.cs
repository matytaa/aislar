using System.Collections.Generic;
using System.Linq;
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

        public virtual ConfiguracionDelNivel DarConfiguracionDelNivel()
        {
            configuracionDelNivel = listaDeConfiguracionDeNiveles[contadorDeNiveles];
            contadorDeNiveles = contadorDeNiveles + 1;
            return configuracionDelNivel;
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
