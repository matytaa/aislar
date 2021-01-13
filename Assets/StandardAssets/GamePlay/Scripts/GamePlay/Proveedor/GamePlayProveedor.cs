using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;
using UniRx;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Proveedor
{
    public static class GamePlayProveedor 
    {
        private static Subject<Unit> barraDeProgresoAgotada = new Subject<Unit>();
        private static Subject<Aislados> aislados = new Subject<Aislados>();
        private static RepositorioConfiguracion repositorioConfiguracion;

        public static void AsignarPresenterYSetearConfiguracion(GamePlayView vista, 
            ConfiguracionDelNivel configuracion,
            BarraDeProgresoVista barraDeProgreso)
        {
            repositorioConfiguracion = new RepositorioConfiguracion(configuracion);
            PersonasProveedor.CargarConfiguracion(configuracion.TopeDeAislados(), barraDeProgreso, repositorioConfiguracion);
            new GamePlayPresenter(vista, DarReceptorDeAislados(), DarServicioDeConfiguracion());
        }

        public static ServicioDeConfiguracion DarServicioDeConfiguracion()
        {
            return new ServicioDeConfiguracion(DarRepositorioConfiguracion());
        }

        public static RepositorioConfiguracion DarRepositorioConfiguracion()
        {
            return repositorioConfiguracion;
        }

        public static IObserver<Unit> DarEmisorDeBarraDeProgresoAgotada()
        {
            return barraDeProgresoAgotada;
        }

        public static IObservable<Unit> DarReceptorDeBarraDeProgresoAgotada()
        {
            return barraDeProgresoAgotada;
        }

        public static IObserver<Aislados> DarEmisorDeAislados()
        {
            return aislados;
        }


        public static IObservable<Aislados> DarReceptorDeAislados()
        {
            return aislados;
        }
    }
}