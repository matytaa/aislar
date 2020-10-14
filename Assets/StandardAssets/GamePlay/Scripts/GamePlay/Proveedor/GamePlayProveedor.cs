using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GamePlay.Presentacion;

namespace Scripts.GamePlay.Proveedor
{
    public static class GamePlayProveedor 
    {
        public static void AsignarPresenterYSetearConfiguracion(GamePlayView vista, 
            ConfiguracionGeneral configuracion,
            BarraDeProgresoVista barraDeProgreso)
        {
            new GamePlayPresenter(vista);
            PersonasProveedor.CargarConfiguracion(configuracion, barraDeProgreso);
        }
    }
}