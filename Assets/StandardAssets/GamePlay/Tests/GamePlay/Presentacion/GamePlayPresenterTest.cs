using System;
using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Presentacion;
using UniRx;

namespace StandardAssets.GamePlay.Tests.GamePlay.Presentacion
{
    public class GamePlayPresenterTest
    {
        GamePlayView vista;
        GamePlayPresenter presenter;
        Subject<Aislados> aisladosSubject;
        ServicioDeConfiguracion servicio;
        ServicioDeAislados servicioDeAislados;
        Aislados aislados;
        private int tiempoDelNivel = 10;
        private int limiteDePoblacionConCovid = 10;
        private int topeDeAislados = 8;
        Nivel nivelActual;

        [SetUp]
        public void setup()
        {
            vista = Substitute.For<GamePlayView>();
            aisladosSubject = new Subject<Aislados>();
            servicio = Substitute.For<ServicioDeConfiguracion>();
            servicioDeAislados = Substitute.For<ServicioDeAislados>();
            GamePlayPresenter presenter = new GamePlayPresenter(vista, aisladosSubject, servicio, servicioDeAislados);

            aislados = Substitute.For<Aislados>();
            nivelActual = Substitute.For<Nivel>();
        }

        [Test]
        public void iniciar_tiempo_cuando_se_hace_click_en_boton_start()
        {
            nivelActual.TiempoDelNivel.Returns(tiempoDelNivel);
            servicio.DarPrimerNivel().Returns(nivelActual);
            
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            servicio.Received(1).DarPrimerNivel();
            vista.Received(1).IniciarTimer(Arg.Is(tiempoDelNivel));
        }

        [Test]
        public void poner_musica_del_gameplay_cuando_se_hace_click_en_boton_start()
        { 
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            vista.Received(1).PlayMusica("gamePlay", true);
        }

        [Test]
        public void reiniciar_cuenta_de_aislados_al_iniciar_primer_nivel()
        { 
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            servicioDeAislados.Received(1).ReiniciarCuentaDeAislados();
        }
        
        [Test]
        public void reiniciar_cuenta_de_aislados_al_iniciar_otro_nivel()
        { 
            vista.OnBotonNextLevelEsClickeado += Raise.Event<Action>();

            servicioDeAislados.Received(1).ReiniciarCuentaDeAislados();
        }
        
        [Test]
        public void configurar_limite_de_personas_con_covid()
        {
            nivelActual.LimiteDePoblacionConCovid.Returns(limiteDePoblacionConCovid);
            servicio.DarPrimerNivel().Returns(nivelActual);
            
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            vista.Received(1).ConfigurarLimiteDePersonasConCovid(Arg.Is(limiteDePoblacionConCovid));
        } 
        
        [Test]
        public void configurar_tope_de_aislados()
        {
            nivelActual.TopeDeAislados.Returns(topeDeAislados);
            servicio.DarPrimerNivel().Returns(nivelActual);
            
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            vista.Received(1).ConfigurarTopeDeAislados(Arg.Is(topeDeAislados));
        }
        
        [Test]
        public void mostrar_game_over_cuando_el_termina()
        {
            var esGanador = false;
            servicio.EsGanadorDelNivel().Returns(esGanador);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).MostrarGameOver(Arg.Is(esGanador));
        }  
        
        [Test]
        public void destruir_personas_cuando_el_termina()
        {
            var esGanador = false;
            servicio.EsGanadorDelNivel().Returns(esGanador);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).DestruirPersonas();
        }     
        
        [Test]
        public void mostrar_game_over_win_cuando_el_termina_y_la_cantidad_de_personas_con_covid_es_valida()
        {
            var esGanador = true;
            servicio.EsGanadorDelNivel().Returns(esGanador);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).MostrarGameOver(Arg.Is(esGanador));
        }

        [Test]
        public void mostrar_game_over_cuando_la_barra_de_progreso_se_haya_agotado()
        {
            var esGanador = false;
            servicio.EsGanadorDelNivel().Returns(esGanador);

            vista.OnBarraDeProgresoAgotada += Raise.Event<Action>();

            vista.Received(1).MostrarGameOver(Arg.Is(esGanador));
        }

        [Test]
        public void al_perder_musica_del_lobby()
        {
            var esGanador = false;
            servicio.EsGanadorDelNivel().Returns(esGanador);

            vista.OnBarraDeProgresoAgotada += Raise.Event<Action>();

            vista.Received(1).PlayMusica("lobby", true);
        }

        [Test]
        public void al_terminar_ultimo_nivel_poner_musica_del_lobby()
        {
            servicio.HayUnSiguienteNivel().Returns(false);
            servicio.EsGanadorDelNivel().Returns(true);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).PlayMusica("lobby", true);
        }

        [Test]
        public void actualizar_cantidad_de_aislados()
        {
            aisladosSubject.OnNext(aislados);

            vista.Received(1).ActualizarCantidadDeAislados(Arg.Is(aislados));
        }
        
        [Test]
        public void no_actualizar_cantidad_de_aislados_cuando_llenamos_el_cupo()
        {
            aislados.ElCupoEstaCompleto().Returns(true);

            aisladosSubject.OnNext(aislados);

            vista.DidNotReceive().ActualizarCantidadDeAislados(Arg.Is(aislados));
        }

        [Test]
        public void iniciar_juego_al_hacer_click_en_boton_start()
        {
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            servicio.Received(1).DarPrimerNivel();
            vista.Received(1).ApagarPopUP();
        }

        [Test]
        public void instanciar_personas_al_hacer_click_en_boton_start()
        {
            vista.OnBotonStartEsClickeado += Raise.Event<Action>();

            servicio.Received(1).DarPrimerNivel();
            vista.Received(1).InstanciarPersonas(Arg.Any<int>());
        }

        [Test]
        public void al_habilitar_la_vista_mostrar_panel_de_inciar_juego()
        {
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).MostrarPopupDeStartGameONextLevel(false);
        }

        [Test]
        public void al_habilitar_la_vista_cargar_musica_del_lobby()
        {
            vista.OnVistaHabilitada += Raise.Event<Action>();

            vista.Received(1).PlayMusica("lobby", loop: true);
        }
        
        [Test]
        public void mostrar_boton_next_level_siempre_que_haya_uno_disponible_cuando_termina_el_tiempo()
        {
            servicio.HayUnSiguienteNivel().Returns(true);
            servicio.EsGanadorDelNivel().Returns(true);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).MostrarPopupDeStartGameONextLevel(esGanadorYHayOtroNivel: true);
        }
        
        [Test]
        public void no_mostrar_boton_next_level_porque_estamos_en_el_ultimo_nivel_cuando_termina_el_tiempo()
        {
            servicio.HayUnSiguienteNivel().Returns(false);
            servicio.EsGanadorDelNivel().Returns(true);

            vista.OnTimerFinaliza += Raise.Event<Action>();

            vista.Received(1).MostrarPopupDeStartGameONextLevel(false);
        }

        [Test]
        public void al_hacer_click_en_next_level_iniciar_otro_nivel()
        {
            vista.OnBotonNextLevelEsClickeado += Raise.Event<Action>();

            vista.Received(1).ApagarPopUP();
        }
    }
}
