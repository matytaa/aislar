using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace Scripts.GamePlay.Vistas
{ 
    public class UnityBarraDeProgresoVista : MonoBehaviour
    {
        [SerializeField] Slider barraDeProgreso;
        [SerializeField] Gradient gradiente;
        [SerializeField] Image colorDeLaBarra;
        
        void Awake()
        {
            barraDeProgreso.maxValue = 10;
            barraDeProgreso.value = 10;
            colorDeLaBarra.color = gradiente.Evaluate(1f);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DescontarEnLaBarraDeProgreso();
        }

        void DescontarEnLaBarraDeProgreso()
        {
            barraDeProgreso.value -= 1;
            colorDeLaBarra.color = gradiente.Evaluate(barraDeProgreso.normalizedValue);
        }
    }
}