namespace Scripts.GamePlay.Dominio
{
    public enum Carril
    {
       PRIMER_CARRIL,
       SEGUNDO_CARRIL,
       TERCER_CARRIL,
       CUARTO_CARRIL
    }

    public static class Extension
    {
        public static float Valor(this Carril carril)
        {
            switch (carril)
            {
                case Carril.PRIMER_CARRIL: return -0.5f;
                case Carril.SEGUNDO_CARRIL: return -1.5f;
                case Carril.TERCER_CARRIL: return -2.5f;
                case Carril.CUARTO_CARRIL: return -3.5f;
                default: return -1.5f;
            }
        }
    }
}
