using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
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
            if (EsPosibleAislarMasPersonas()) { 
                repositorio.ActualizarCantidadAislados();
                emisorDeAislados.OnNext(new Aislados(CantidadActualDeAislados(), TopeDeAislados()));
            }
        }

        public virtual bool EsPosibleAislarMasPersonas()
        {
            return CantidadActualDeAislados() < TopeDeAislados();
        }
        
        public virtual void ReiniciarCuentaDeAislados()
        {
            repositorio.ReiniciarCuentaDeAislados();
        } 
        
        public virtual void ConfigurarTopeDeAislados(int topeDeAislados)
        {
            repositorio.ConfigurarTopeDeAislados(topeDeAislados);
        }

        private int CantidadActualDeAislados()
        {
            return repositorio.CantidadActualDeAislados();
        }
        
        private int TopeDeAislados()
        {
            return repositorio.TopeDeAislados();
        }
    }
}
