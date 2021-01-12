using Scripts.GamePlay.Vistas;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Scripts.GamePlay.Infraestructura
{
    public class RepositorioConfiguracion
    {
        private ConfiguracionGeneral configuracion;
        private List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;

        protected RepositorioConfiguracion(){}
        
        public RepositorioConfiguracion(ConfiguracionGeneral configuracion)
        {
            this.configuracion = configuracion;
            ClonarListaDeConfiguracionDePersonas();
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

        public virtual ConfiguracionGeneral DarConfiguracionDelNivel()
        {
            return configuracion;
        }
    }
}
