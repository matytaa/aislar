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
        private static ServicioDeConfiguracion servicioDeConfiguracion;
        

        public static void AsignarPresenterYSetearConfiguracion(GamePlayView vista, 
            BarraDeProgresoVista barraDeProgreso)
        {
            PersonasProveedor.CargarConfiguracion(10, barraDeProgreso);
            new GamePlayPresenter(vista, DarReceptorDeAislados(), DarServicioDeConfiguracion(), PersonasProveedor.DarServicioDeAislados());
        }

        public static ServicioDeConfiguracion DarServicioDeConfiguracion()
        {
            return servicioDeConfiguracion;
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

        public static void Iniciliazar(RepositorioConfiguracion repositorioConfiguracion)
        {
            servicioDeConfiguracion = new ServicioDeConfiguracion(repositorioConfiguracion);
        }
    }
}