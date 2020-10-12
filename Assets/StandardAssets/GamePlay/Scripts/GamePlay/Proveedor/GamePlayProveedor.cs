using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GamePlay.Presentacion;

namespace Scripts.GamePlay.Proveedor
{
    public static class GamePlayProveedor 
    {
        public static void Para(GamePlayView vista, ConfiguracionGeneral configuracion)
        {
            new GamePlayPresenter(vista);
            PersonasProveedor.CargarConfiguracion(configuracion);
        }
    }
}