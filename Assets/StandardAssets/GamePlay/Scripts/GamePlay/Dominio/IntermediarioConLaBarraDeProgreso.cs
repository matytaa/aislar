using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GamePlay.Presentacion;

namespace Scripts.GamePlay.Dominio
{
    public class IntermediarioConLaBarraDeProgreso
    {
        private BarraDeProgresoVista vista;
        protected IntermediarioConLaBarraDeProgreso(){}
        public IntermediarioConLaBarraDeProgreso(BarraDeProgresoVista vista) 
        {
            this.vista = vista;
        }

        public virtual void DecrementarBarra()
        {
            vista.DescontarEnLaBarraDeProgreso();
        }
    }
}
