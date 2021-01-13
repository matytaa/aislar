using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class IntermediarioConLaBarraDeProgreso
    {
        private BarraDeProgresoVista vista;
        private RepositorioConfiguracion repositorio;

        protected IntermediarioConLaBarraDeProgreso(){}
        public IntermediarioConLaBarraDeProgreso(BarraDeProgresoVista vista, RepositorioConfiguracion repositorio) 
        {
            this.vista = vista;
            this.repositorio = repositorio;
    }

        public virtual void DecrementarBarra()
        {
            repositorio.IncrementarCantidadDeContagiados();
            vista.DescontarEnLaBarraDeProgreso();
        }
    }
}
