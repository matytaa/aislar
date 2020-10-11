using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using System.Globalization;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Proveedor;
using Scripts.GamePlay.Utils;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace Scripts.GamePlay.Vistas.Personas
{
    public class UnityPersonaVista : MonoBehaviour, PersonaVista
    {
        [SerializeField] float velocidad;
        public event Action OnVistaHabilitada = () => { };

        readonly Disposer suscripcion = Disposer.Create();

        void Awake()
        {
            PersonasProveedor.Para(this);
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
    }
}
