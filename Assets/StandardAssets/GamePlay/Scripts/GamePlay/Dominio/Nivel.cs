using System.Collections.Generic;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class Nivel
    {
        public virtual int TiempoDelNivel { get; }
        public virtual int TopeDeAislados { get; }
        public virtual int LimiteDePoblacionConCovid { get; }
        private int contadorDePersonas = 0;
        
        private readonly List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;

        protected Nivel() {}

        public Nivel(int tiempoDelNivel, 
            int topeDeAislados, 
            int limiteDePoblacionConCovid, 
            List<ConfiguracionDePersona> configuracionesDePersonas)
        {
            TiempoDelNivel = tiempoDelNivel;
            TopeDeAislados = topeDeAislados;
            LimiteDePoblacionConCovid = limiteDePoblacionConCovid;
            listaDeConfiguracionDePersonas = new List<ConfiguracionDePersona>(configuracionesDePersonas);
        }
        
        public virtual ConfiguracionDePersona DarConfiguracionDeUnaPersona()
        {
            if (listaDeConfiguracionDePersonas.Count == contadorDePersonas)
                contadorDePersonas = 0;

            var configuracionDePersona = listaDeConfiguracionDePersonas[contadorDePersonas];
            contadorDePersonas = contadorDePersonas + 1;
            return configuracionDePersona;
        }
    }
}