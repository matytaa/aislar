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
            acumuladoDeAislados = 0;
        }

        public virtual Aislados DarAisladosActualizados() {
            acumuladoDeAislados = acumuladoDeAislados + 1;
            return new Aislados(acumuladoDeAislados, topeDeAislados);
        }
    }
}
