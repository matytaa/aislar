using System;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using StandardAssets.GamePlay.Scripts.GamePlay.Proveedor;
using StandardAssets.GamePlay.Scripts.GamePlay.Utils;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas.Personas;
using TMPro;
using UniRx;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Vistas
{
    public class UnityGamePlayVista : MonoBehaviour, GamePlayView
    {
        [SerializeField] TextMeshProUGUI tiempoRestante;
        [SerializeField] Animator animator;
        [SerializeField] UnityPersonaVista prefabPersona;
        [SerializeField] Transform contenedorDeLasPersonas;
        [SerializeField] UnityBarraDeProgresoVista barraDeProgreso;
        [SerializeField] TextMeshProUGUI cantidadDeAislados;
        [SerializeField] GameObject panelDeBotones;
        [SerializeField] Button botonStart;
        [SerializeField] Button botonNextLevel;
        [SerializeField] UnityMusicaDelJuego musicaDelJuego;
        [SerializeField] GameObject tutorial;

        static readonly int gameOverTrigger = Animator.StringToHash("game-over");
        static readonly int gameOverWinTrigger = Animator.StringToHash("game-over-win");
        readonly Disposer suscripcion = Disposer.Create();
        private IObservable<Unit> receptorDeBarraDeProgresoAgotada;

        public event Action OnVistaHabilitada = () => { };
        public event Action OnTimerFinaliza = () => { };
        public event Action OnBarraDeProgresoAgotada = () => { };
        public event Action OnBotonStartEsClickeado = () => { };
        public event Action OnBotonNextLevelEsClickeado = () => { };

        void Awake()
        {
            GamePlayProveedor.AsignarPresenterYSetearConfiguracion(this, barraDeProgreso);
            receptorDeBarraDeProgresoAgotada = GamePlayProveedor.DarReceptorDeBarraDeProgresoAgotada();
            receptorDeBarraDeProgresoAgotada.Subscribe(_ => OnBarraDeProgresoAgotada())
                .AddTo(suscripcion);
            botonStart.onClick.AddListener(IniciarNivel);
            botonNextLevel.onClick.AddListener(IniciarOtroNivel);
        }

        public void InstanciarPersonas(int tiempoDelNivel)
        {
            var poolDePersonas = new PoolDePersonas(prefabPersona, contenedorDeLasPersonas);
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Where(timeSpan => timeSpan < tiempoDelNivel )
                .Subscribe(_ =>
                {
                    var cuantosObjectosQuieroPrecargadosOsiosos = 10;
                    UnityPersonaVista persona = null;
                    poolDePersonas.PreloadAsync(cuantosObjectosQuieroPrecargadosOsiosos, 2)
                        .Do(__ => persona = poolDePersonas.Rent())
                        .Do(__ => persona.transform.localScale = new Vector3(1, 1, 1))
                        .SelectMany(__ => persona.AccionAsincronicaQueDefineLaVidaDeLaPersona())
                        .Subscribe(__ => poolDePersonas.Return(persona))
                        .AddTo(suscripcion);
                }
                )
                .AddTo(suscripcion);
        }

        public void DestruirPersonas()
        {
            suscripcion.Dispose();
            foreach (Transform persona in contenedorDeLasPersonas)
                Destroy(persona.gameObject);
        }

        public void PlayMusica(string key, bool loop)
        {
            musicaDelJuego.PlayMusica(key, loop);
        }

        public void IniciarTimer(int tiempoDelNivel)
        {
            SeconsTimer(tiempoDelNivel)
                .DoOnCompleted(() => OnTimerFinaliza())
                .Subscribe(ActualizacionDelTimer)
                .AddTo(suscripcion);
        }

        public void ConfigurarLimiteDePersonasConCovid(int limiteDePersonasConCovid)
        {
            barraDeProgreso.ConfigurarLimiteDePersonasConCovid(limiteDePersonasConCovid);
        }

        public void MostrarGameOver(bool esGanador)
        {
            animator.SetTrigger(esGanador ? gameOverWinTrigger : gameOverTrigger);
        }

        public void ConfigurarTopeDeAislados(int TopeDeAislados)
        {
            cantidadDeAislados.text = 0 + "/" + TopeDeAislados;
        }

        public void ActualizarCantidadDeAislados(Aislados aislados)
        {
            cantidadDeAislados.text = aislados.CantidadActualDeAislados() + "/" + aislados.TopeDeAislados();
        }

        public void MostrarPopupDeStartGameONextLevel(bool esGanadorYHayOtroNivel)
        {
            panelDeBotones.SetActive(true);
            botonNextLevel.gameObject.SetActive(esGanadorYHayOtroNivel);
            botonStart.gameObject.SetActive(!esGanadorYHayOtroNivel);
            tutorial.SetActive(!esGanadorYHayOtroNivel);
        }

        public void ApagarPopUP()
        {
            panelDeBotones.SetActive(false);
        }

        void OnEnable()
        {
            OnVistaHabilitada();
        }

        void IniciarNivel()
        {
            OnBotonStartEsClickeado();
        }
        
        void IniciarOtroNivel()
        {
            OnBotonNextLevelEsClickeado();
        }

        void OnDisable()
        {
            suscripcion.Dispose();
        }

        void ActualizacionDelTimer(int segundosRestantes)
        {
            tiempoRestante.text = "" + segundosRestantes;
        }

        IObservable<int> SeconsTimer(int tiempoTotal)
        {
            var comienzo = DateTime.UtcNow;
            return Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => (float)(DateTime.UtcNow - comienzo).TotalSeconds)
                .Select(tiempoTranscurrido => tiempoTotal - (int)Math.Round(tiempoTranscurrido))
                .TakeWhile(tiempoRestanteEnSegundos => tiempoRestanteEnSegundos >= 0);
        }
    }
}