using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{
    [CreateAssetMenu(fileName = "Configuracion general", menuName = "Aislar/Crear configuracion general")]
    public class ConfiguracionGeneral : ScriptableObject
    {
        [SerializeField] List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;
        [SerializeField] int topeDeAislados;
        [SerializeField] int tiempoDelNivel;
        [SerializeField] int limiteDePoblacionConCovid;

        public List<ConfiguracionDePersona> DarConfiguracionesDePersona()
        {
            return listaDeConfiguracionDePersonas;
        }

        public int TopeDeAislados()
        {
            return topeDeAislados;
        }    
    
        public virtual int TiempoDelNivel()
        {
            return tiempoDelNivel;
        }
        
        public virtual int LimiteDePoblacionConCovid()
        {
            return limiteDePoblacionConCovid;
        }
    }
}
