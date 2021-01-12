using System;
using UnityEngine;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;
using UniRx;

namespace Scripts.GamePlay.Proveedor
{
    public static class GamePlayProveedor 
    {
        private static Subject<Unit> barraDeProgresoAgotada = new Subject<Unit>();
        private static Subject<Aislados> aislados = new Subject<Aislados>();

        public static void AsignarPresenterYSetearConfiguracion(GamePlayView vista, 
            ConfiguracionGeneral configuracion,
            BarraDeProgresoVista barraDeProgreso)
        {
            PersonasProveedor.CargarConfiguracion(configuracion, barraDeProgreso);
            new GamePlayPresenter(vista, DarReceptorDeAislados(), DarServicioDeConfiguracion());
        }

        public static ServicioDeConfiguracion DarServicioDeConfiguracion()
        {
            return new ServicioDeConfiguracion(PersonasProveedor.DarRepositorioConfiguracion());
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