using System;
using System.Collections.Generic;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Dominio
{
    public class Persona
    {
        private float temperatura;
        private bool tieneCovid;
        private List<Carril> carriles = new List<Carril>()
        { Carril.PRIMER_CARRIL, Carril.SEGUNDO_CARRIL,Carril.TERCER_CARRIL,Carril.CUARTO_CARRIL};

        protected Persona(){}
        
        public Persona(float temperatura, bool tieneCovid)
        {
            this.temperatura = temperatura;
            this.tieneCovid = tieneCovid;
        }

        public virtual float Temperatura()
        {
            return this.temperatura;
        }

        public virtual bool TieneCovid()
        {
            return tieneCovid;
        } 
        
        public virtual Carril DarCarril()
        {
            var random = new Random();
            return carriles[random.Next(carriles.Count)];
        }
    }
}
