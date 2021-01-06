using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Configuracion general", menuName = "Aislar/Crear configuracion general")]
public class ConfiguracionGeneral : ScriptableObject
{
    [SerializeField] List<ConfiguracionDePersona> listaDeConfiguracionDePersonas;
    [SerializeField] int topeDeAislados;

    public List<ConfiguracionDePersona> DarConfiguracionesDePersona()
    {
        return listaDeConfiguracionDePersonas;
    }

    public int TopeDeAislados()
    {
        return topeDeAislados;
    }
}
