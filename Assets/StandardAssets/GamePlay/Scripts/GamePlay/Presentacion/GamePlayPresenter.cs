namespace Scripts.GamePlay.Presentacion
{ 
    public class GamePlayPresenter
    {
        readonly GamePlayView vista;

        public GamePlayPresenter(GamePlayView vista)
        {
            this.vista = vista;

            this.vista.OnVistaHabilitada += IniciarTimer;
            this.vista.OnTimerFinaliza += MostrarGameOver;
            this.vista.OnBarraDeProgresoAgotada += MostrarGameOver;
        }

        private void IniciarTimer()
        {
            vista.IniciarTimer();
        }
        
        private void MostrarGameOver()
        {
            vista.MostrarGameOver();
        }
    }
}