using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion.Personas;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Proveedor
{
    public static class PersonasProveedor
    {
        private static IntermediarioConLaBarraDeProgreso intermediario;
        private static ServicioDeAislados servicioDeAislados;
        private static RepositorioDeAislados repositorioDeAislados;

        public static void Para(PersonaVista vista)
        {
            new PersonaPresenter(vista, DarObtenerPersonaAction(), DarIntermediario(), DarServicioDeAislados());
        }

        public static void CargarConfiguracion(int topeDeAislados,
            BarraDeProgresoVista barraDeProgreso)
        {
            intermediario = new IntermediarioConLaBarraDeProgreso(barraDeProgreso, GamePlayProveedor.DarServicioDeConfiguracion());
            repositorioDeAislados = new RepositorioDeAislados(topeDeAislados);
            servicioDeAislados = new ServicioDeAislados(GamePlayProveedor.DarEmisorDeAislados(), repositorioDeAislados);
        }

        public static ObtenerPersonaAction DarObtenerPersonaAction()
        {
            return new ObtenerPersonaAction(GamePlayProveedor.DarServicioDeConfiguracion());
        }

        static ServicioDeAislados DarServicioDeAislados()
        {
            return servicioDeAislados;
        }
        
        static IntermediarioConLaBarraDeProgreso DarIntermediario()
        {
            return intermediario;
        }
    }
}