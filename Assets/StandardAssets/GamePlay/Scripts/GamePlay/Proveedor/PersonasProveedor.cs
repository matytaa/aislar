using System.Collections;
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
        private static IntermediarioConLaBarraDeProgreso intermediario;
        private static ServicioDeAislados servicioDeAislados;
        private static RepositorioDeAislados repositorioDeAislados;

        public static void Para(PersonaVista vista)
        {
            new PersonaPresenter(vista, DarPersona(), DarIntermediario(), DarServicioDeAislados());
        }

        public static void CargarConfiguracion(ConfiguracionGeneral configuracion,
            BarraDeProgresoVista barraDeProgreso)
        {
            repositorioConfiguracion = new RepositorioConfiguracion(configuracion);
            intermediario = new IntermediarioConLaBarraDeProgreso(barraDeProgreso);
            repositorioDeAislados = new RepositorioDeAislados(configuracion.TopeDeAislados());
            servicioDeAislados = new ServicioDeAislados(GamePlayProveedor.DarEmisorDeAislados(), repositorioDeAislados);
        }

        public static Persona DarPersona()
        {
            var configuracion = repositorioConfiguracion.DarConfiguracion();
            return new Persona(configuracion.temperatura, configuracion.tieneCovid);
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