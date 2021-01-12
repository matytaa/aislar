using UnityEngine;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{
    [CreateAssetMenu(fileName = "Configuracion De Persona", menuName = "Aislar/Crear configuracion de una persona")]
    public class ConfiguracionDePersona : ScriptableObject
    {
        [SerializeField] public float temperatura;
        [SerializeField] public bool tieneCovid;
    }
}
