using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.GamePlay.Dominio
{
    public class Persona
    {
        private float temperatura;
        private bool tieneCovid;

        public Persona(float temperatura, bool tieneCovid)
        {
            this.temperatura = temperatura;
            this.tieneCovid = tieneCovid;
        }

        public float Temperatura()
        {
            return this.temperatura;
        }
    }
}
