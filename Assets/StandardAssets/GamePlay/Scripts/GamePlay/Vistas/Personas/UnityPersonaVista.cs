using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Proveedor;
using Scripts.GamePlay.Utils;
using System.Diagnostics;
using TMPro;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Vistas.Personas
{
    public class UnityPersonaVista : MonoBehaviour, PersonaVista
    {
        [SerializeField] float velocidad;
        [SerializeField] Button botonDarTemperatura;
        [SerializeField] Button botonAislar;
        [SerializeField] GameObject panelTemperatura;
        [SerializeField] TextMeshProUGUI temperatura;

        public event Action OnVistaHabilitada = () => { };
        public event Action OnDarTemperatura = () => { };
        public event Action OnBotonAislarClikeado = () => { };
        public event Action OnRecorridoTerminado = () => { };

        readonly Disposer suscripcion = Disposer.Create();

        void Awake()
        {
            PersonasProveedor.Para(this);
            botonDarTemperatura.onClick.AddListener(() => OnDarTemperatura());
            botonAislar.onClick.AddListener(() => OnBotonAislarClikeado());
            panelTemperatura.SetActive(false);
            botonAislar.gameObject.SetActive(false);
        }

        void OnEnable()
        {
            OnVistaHabilitada();
        }

        void OnDisable()
        {
            ApagarContenedoPersona();
            suscripcion.Dispose();
        }

        public void IniciarRecorrido(Carril carril)
        {
            var delta = 0.02f;
            var velocidadDeLaPersona = velocidad * delta;
            transform.position = new Vector3(-12, carril.Valor(), 0);

            Observable.EveryUpdate()
                .Do(_ => transform.Translate(velocidadDeLaPersona, 0, 0))
                .Select(_ => transform.position.x)
                .TakeWhile(posicionX => posicionX < 12)
                .DoOnCompleted(() => OnRecorridoTerminado())
                .Subscribe()
                .AddTo(suscripcion);
        }

        public void DarTemperatura(float temperaturaDeLaPersona)
        {
            temperatura.text = "" + temperaturaDeLaPersona;
            panelTemperatura.SetActive(true);
        }
        
        public void HabilitarBotonAislar()
        {
            botonAislar.gameObject.SetActive(true);
        }
        
        public void ApagarContenedoPersona()
        {
            botonAislar.gameObject.SetActive(false);
            panelTemperatura.SetActive(false);
            suscripcion.Dispose();
            gameObject.SetActive(false);
        }

        public IObservable<Unit> AccionAsincronicaQueDefineLaVidaDeLaPersona()
        {
            return Observable
                .Timer(TimeSpan.FromSeconds(7))
                .AsUnitObservable();
        }
    }
}
