﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.GamePlay.Presentacion;
using Scripts.GamePlay.Vistas;
using Scripts.GamePlay.Infraestructura;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Proveedor
{
    public static class PersonasProveedor
    {
        private static RepositorioConfiguracion repositorioConfiguracion;
        public static void Para(PersonaVista vista)
        {
            new PersonaPresenter(vista, DarPersona());
        }

        public static void CargarConfiguracion(ConfiguracionGeneral configuracion)
        {
            repositorioConfiguracion = new RepositorioConfiguracion(configuracion);
        }

        public static Persona DarPersona()
        {
            var configuracion = repositorioConfiguracion.DarConfiguracion();
            return new Persona(configuracion.temperatura, configuracion.tieneCovid);
        }
    }
}