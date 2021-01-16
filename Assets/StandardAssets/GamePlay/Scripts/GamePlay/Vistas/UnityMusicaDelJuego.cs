using UnityEngine;
using System.Collections.Generic;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{
    [CreateAssetMenu(fileName = "Musica", menuName = "Aislar/Crear musica del juego")]
    public class UnityMusicaDelJuego : ScriptableObject
    {
        [SerializeField] AudioClip lobby;
        [SerializeField] AudioClip gamePlay;
        [SerializeField] AudioClip efectoDeGanar;
        [SerializeField] AudioClip efectoDePerder;

        private Dictionary<string, AudioClip> sonidosDelJuego;
        private AudioSource audioSource;

        public void CargarMusica()
        {
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            sonidosDelJuego = new Dictionary<string, AudioClip>
            {
                {"lobby", lobby},
                {"gamePlay", gamePlay},
                {"efectoDeGanar", efectoDeGanar},
                {"efectoDePerder", efectoDePerder},
            };
        }

        public void PlayMusica(string key, bool loop)
        {
            var audioSourceClip = sonidosDelJuego[key];
            if (EstaEnPlayEsteSonido(audioSourceClip))
                return;

            audioSource.Stop();
            audioSource.clip = audioSourceClip;
            audioSource.loop = loop;
            audioSource.Play();
        }

        bool EstaEnPlayEsteSonido(AudioClip clip)
        {
            var clipActual = audioSource.clip;
            return (clipActual != null) && (clipActual == clip) && audioSource.isPlaying;
        }
    }
}
