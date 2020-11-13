using System;
using UnityEngine;
using Scripts.GamePlay.Presentacion;
using UniRx;

namespace Scripts.GamePlay.Proveedor
{
    public static class GamePlayProveedor 
    {
        private static Subject<Unit> barraDeProgresoAgotada = new Subject<Unit>();

        public static void AsignarPresenterYSetearConfiguracion(GamePlayView vista, 
            ConfiguracionGeneral configuracion,
            BarraDeProgresoVista barraDeProgreso)
        {
            new GamePlayPresenter(vista);
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
    }
}