using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Proveedor;
using Scripts.GamePlay.Utils;
using System.Diagnostics;

namespace Scripts.GamePlay.Vistas.Personas
{
    public class UnityPersonaVista : MonoBehaviour, PersonaVista
    {
        [SerializeField] float velocidad;
        [SerializeField] Button botonDarTemperatura;
        [SerializeField] GameObject panelTemperatura;

        public event Action OnVistaHabilitada = () => { };
        public event Action OnDarTemperatura = () => { };

        readonly Disposer suscripcion = Disposer.Create();

        void Awake()
        {
            PersonasProveedor.Para(this);
            botonDarTemperatura.onClick.AddListener(() => OnDarTemperatura());
            panelTemperatura.SetActive(false);
        }

        void OnEnable()
        {
            OnVistaHabilitada();
        }

        void OnDisable()
        {
            suscripcion.Dispose();
        }

        public void MoverALaPersona()
        {
            velocidad = velocidad * Time.deltaTime;
            transform.position = new Vector3(-12, -1.5f, 0);

            Observable.EveryUpdate()
                .Do(_ => transform.Translate(velocidad, 0, 0))
                .Select(_ => transform.position.x)
                .TakeWhile(posicionX => posicionX < 12)
                .Subscribe()
                .AddTo(suscripcion);
        }

        public void DarTemperatura()
        {
            panelTemperatura.SetActive(true);
        }
    }
}
