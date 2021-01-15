using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class IntermediarioConLaBarraDeProgreso
    {
        private BarraDeProgresoVista vista;
        private ServicioDeConfiguracion servicioDeConfiguracion;

        protected IntermediarioConLaBarraDeProgreso(){}
        public IntermediarioConLaBarraDeProgreso(BarraDeProgresoVista vista, ServicioDeConfiguracion servicioDeConfiguracion) 
        {
            this.vista = vista;
            this.servicioDeConfiguracion = servicioDeConfiguracion;
    }

        public virtual void DecrementarBarra()
        {
            servicioDeConfiguracion.IncrementarCantidadDeContagiados();
            vista.DescontarEnLaBarraDeProgreso();
        }
    }
}
