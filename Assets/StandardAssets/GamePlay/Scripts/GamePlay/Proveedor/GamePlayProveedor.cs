using System;
using UnityEngine;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Dominio;
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
            new GamePlayPresenter(vista, DarReceptorDeAislados());
            PersonasProveedor.CargarConfiguracion(configuracion, barraDeProgreso);
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