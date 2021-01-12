using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using TMPro;
using System.Globalization;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Proveedor;
using Scripts.GamePlay.Utils;
using Scripts.GamePlay.Vistas.Personas;
using UniRx;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Vistas
{
    public class UnityGamePlayVista : MonoBehaviour, GamePlayView
    {
        [SerializeField] int tiempoTotal;
        [SerializeField] TextMeshProUGUI tiempoRestante;
        [SerializeField] Animator animator;
        [SerializeField] ConfiguracionGeneral configuracion;
        [SerializeField] UnityPersonaVista prefabPersona;
        [SerializeField] Transform contenedorDeLasPersonas;
        [SerializeField] UnityBarraDeProgresoVista barraDeProgreso;
        [SerializeField] TextMeshProUGUI cantidadDeAislados;

        static readonly int gameOverTrigger = Animator.StringToHash("game-over");
        readonly Disposer suscripcion = Disposer.Create();
        private IObservable<Unit> receptorDeBarraDeProgresoAgotada;

        public event Action OnVistaHabilitada = () => { };
        public event Action OnTimerFinaliza = () => { };
        public event Action OnBarraDeProgresoAgotada = () => { };

        void Awake()
        {
            GamePlayProveedor.AsignarPresenterYSetearConfiguracion(this, configuracion, barraDeProgreso);
            InstanciarPersona();
            receptorDeBarraDeProgresoAgotada = GamePlayProveedor.DarReceptorDeBarraDeProgresoAgotada();
            receptorDeBarraDeProgresoAgotada.Subscribe(_ => OnBarraDeProgresoAgotada())
                .AddTo(suscripcion);
        }

        void OnEnable()
        {
            OnVistaHabilitada();
        }

        void InstanciarPersona()
        {
            var poolDePersonas = new PoolDePersonas(prefabPersona, contenedorDeLasPersonas);
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ =>
                {
                    var cuantosObjectosQuieroPrecargadosOsiosos = 10;
                    UnityPersonaVista persona = null;
                    poolDePersonas.PreloadAsync(cuantosObjectosQuieroPrecargadosOsiosos, 2)
                        .Do(__ => persona = poolDePersonas.Rent())
                        .Do(__ => persona.transform.localScale = new Vector3(1, 1, 1))
                        .SelectMany(__ => persona.AccionAsincronicaQueDefineLaVidaDeLaPersona())
                        .Subscribe(__ => poolDePersonas.Return(persona));
                }
                )
                .AddTo(suscripcion);
        }

        void OnDisable()
        {
            suscripcion.Dispose();
        }

        public void IniciarTimer(int tiempoDelNivel)
        {
            SeconsTimer(tiempoDelNivel)
                .DoOnCompleted(() => OnTimerFinaliza())
                .Subscribe(ActualizacionDelTimer)
                .AddTo(suscripcion);
        }

        public void MostrarGameOver()
        {
            animator.SetTrigger(gameOverTrigger);
        }
        
        public void ActualizarCantidadDeAislados(Aislados aislados)
        {
            cantidadDeAislados.text = aislados.CantidadActualDeAislados() + "/" + aislados.TopeDeAislados();
        }

        void ActualizacionDelTimer(int segundosRestantes)
        {
            tiempoRestante.text = "" + segundosRestantes;
        }

        IObservable<int> SeconsTimer(int tiempoTotal)
        {
            var comienzo = DateTime.UtcNow;
            return Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => (float)(DateTime.UtcNow - comienzo).TotalSeconds)
                .Select(tiempoTranscurrido => tiempoTotal - (int)Math.Round(tiempoTranscurrido))
                .TakeWhile(tiempoRestanteEnSegundos => tiempoRestanteEnSegundos >= 0);
        }
    }
}