using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{
    [CreateAssetMenu(fileName = "Configuracion general", menuName = "Aislar/Crear configuracion general con niveles")]
    public class ConfiguracionGeneral : ScriptableObject
    {
        [SerializeField] List<ConfiguracionDelNivel> listaDeConfiguracionDeNiveles;

        public List<ConfiguracionDelNivel> DarConfiguracionDeNiveles()
        {
            return listaDeConfiguracionDeNiveles;
        }
    }
}
