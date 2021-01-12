namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class Aislados
    {
        readonly int cantidadActualDeAislados;
        readonly int topeDeAislados;
        protected Aislados(){}

        public Aislados(int cantidadActualDeAislados, int topeDeAislados) 
        {
            this.cantidadActualDeAislados = cantidadActualDeAislados;
            this.topeDeAislados = topeDeAislados;
        }

        public virtual bool ElCupoEstaCompleto() {
            return cantidadActualDeAislados > topeDeAislados;
        }

        public int CantidadActualDeAislados() {
            return cantidadActualDeAislados;
        }

        public int TopeDeAislados()
        {
            return topeDeAislados;
        }
    }
}
