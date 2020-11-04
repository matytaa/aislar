using UnityEngine;
using UniRx.Toolkit;
using Scripts.GamePlay.Vistas.Personas;

namespace Scripts.GamePlay.Vistas.Personas
{
    public class PoolDePersonas : ObjectPool<UnityPersonaVista>
    {
        readonly UnityPersonaVista prefab;
        readonly Transform contenedorDePersonas;

        public PoolDePersonas(UnityPersonaVista prefab, Transform contenedorDePersonas)
        {
            this.prefab = prefab;
            this.contenedorDePersonas = contenedorDePersonas;
        }

        protected override UnityPersonaVista CreateInstance()
        {
            var persona = GameObject.Instantiate(prefab);
            persona.transform.SetParent(contenedorDePersonas);

            return persona;
        }
    }
}
