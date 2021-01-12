using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Proveedor;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{ 
    public class UnityBarraDeProgresoVista : MonoBehaviour, BarraDeProgresoVista
    {
        [SerializeField] Slider barraDeProgreso;
        [SerializeField] Gradient gradiente;
        [SerializeField] Image colorDeLaBarra;

        private IObserver<Unit> emisorDeBarraDeProgresoAgotada;

        void Awake()
        {
            barraDeProgreso.maxValue = 10;
            barraDeProgreso.value = 10;
            colorDeLaBarra.color = gradiente.Evaluate(1f);
            emisorDeBarraDeProgresoAgotada = GamePlayProveedor.DarEmisorDeBarraDeProgresoAgotada();
        }

        public void DescontarEnLaBarraDeProgreso()
        {
            barraDeProgreso.value -= 1;
            colorDeLaBarra.color = gradiente.Evaluate(barraDeProgreso.normalizedValue);
            if (barraDeProgreso.value < 1)
                emisorDeBarraDeProgresoAgotada.OnNext(Unit.Default);
        }
    }
}