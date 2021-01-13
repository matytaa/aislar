using System.Collections.Generic;
using System.Linq;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class RepositorioConfiguracion
    {
        private ConfiguracionDelNivel configuracion;
        private List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;
        private int contadorDeContagiados;

        protected RepositorioConfiguracion(){}
        
        public RepositorioConfiguracion(ConfiguracionDelNivel configuracion)
        {
            this.configuracion = configuracion;
            ClonarListaDeConfiguracionDePersonas();
            contadorDeContagiados = 0;
        }

        public virtual ConfiguracionDePersona DarConfiguracionDeUnaPersona()
        {
            if(listaDeConfiguracionDePersonas.Count() == 0)
                ClonarListaDeConfiguracionDePersonas();
                
            var configuracionDePersona = listaDeConfiguracionDePersonas.First();
            listaDeConfiguracionDePersonas.RemoveAt(0);
            return configuracionDePersona;
        }

        private void ClonarListaDeConfiguracionDePersonas(){
            listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>(configuracion.DarConfiguracionesDePersona());
        }

        public virtual ConfiguracionDelNivel DarConfiguracionDelNivel()
        {
            return configuracion;
        }

        public virtual int DarCantidadDeInfectadosConCovid()
        {
            return contadorDeContagiados;
        }

        public virtual void IncrementarCantidadDeContagiados()
        {
            contadorDeContagiados = contadorDeContagiados + 1;
        }
    }
}
