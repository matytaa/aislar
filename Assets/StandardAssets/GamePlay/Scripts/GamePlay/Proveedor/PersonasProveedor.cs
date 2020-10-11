using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GamePlay.Presentacion;

namespace Scripts.GamePlay.Proveedor
{
    public static class PersonasProveedor
    {
        public static void Para(PersonaVista vista)
        {
            new PersonaPresenter(vista);
        }
    }
}