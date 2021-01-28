using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura
{
    public class RepositorioDeAislados
    {
        readonly int topeDeAislados;
        private int acumuladoDeAislados;

        protected RepositorioDeAislados() { }

        public RepositorioDeAislados(int topeDeAislados)
        {
            this.topeDeAislados = topeDeAislados;
        }

        public virtual void ActualizarCantidadAislados() {
            acumuladoDeAislados = acumuladoDeAislados + 1;
        }

        public virtual int CantidadActualDeAislados()
        {
            return acumuladoDeAislados;
        }        
        
        public virtual int TopeDeAislados()
        {
            return topeDeAislados;
        }

        public virtual void ReiniciarCuentaDeAislados()
        {
            acumuladoDeAislados = 0;
        }
    }
}
