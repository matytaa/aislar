using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
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
