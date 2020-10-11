namespace Scripts.GamePlay.Presentacion
{ 
    public class GamePlayPresenter
    {
        readonly GamePlayView vista;

        public GamePlayPresenter(GamePlayView vista)
        {
            this.vista = vista;

            this.vista.OnVistaHabilitada += IniciarTimer;
        }

        private void IniciarTimer()
        {
            vista.IniciarTimer();
        }
    }
}