using Scripts.GamePlay.Vistas;
using System;
using Scripts.GamePlay.Dominio;

namespace Scripts.GamePlay.Infraestructura
{
    public class ServicioDeAislados
    {
        readonly IObserver<Aislados> emisorDeAislados;
        readonly RepositorioDeAislados repositorio;

        protected ServicioDeAislados() { }

        public ServicioDeAislados(IObserver<Aislados> emisorDeAislados, RepositorioDeAislados repositorio)
        {
            this.emisorDeAislados = emisorDeAislados;
            this.repositorio = repositorio;
        }

        public virtual void ActualizarAislados() 
        {
            var aislados = repositorio.DarAisladosActualizados();
            emisorDeAislados.OnNext(aislados);
        }
    }
}
