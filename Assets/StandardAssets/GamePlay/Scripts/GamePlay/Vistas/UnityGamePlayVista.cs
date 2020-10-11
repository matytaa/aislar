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

namespace Scripts.GamePlay.Vistas
{ 
    public class UnityGamePlayVista : MonoBehaviour, GamePlayView
    {
        [SerializeField] int tiempoTotal;
        [SerializeField] TextMeshProUGUI tiempoRestante;
        public event Action OnVistaHabilitada = () => { };
        readonly Disposer suscripcion = Disposer.Create();

        void Awake()
        {
            GamePlayProveedor.Para(this);
        }
        
        void OnEnable()
        {
            OnVistaHabilitada();
        }      
        
        void OnDisable()
        {
            suscripcion.Dispose();
        }

        public void IniciarTimer()
        {
            SeconsTimer(tiempoTotal)
                .Subscribe(ActualizacionDelTimer)
                .AddTo(suscripcion);
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