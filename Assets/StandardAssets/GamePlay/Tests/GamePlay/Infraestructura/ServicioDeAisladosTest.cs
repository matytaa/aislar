using System;
using NSubstitute;
using NUnit.Framework;
using StandardAssets.GamePlay.Scripts.GamePlay.Dominio;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;

namespace StandardAssets.GamePlay.Tests.GamePlay.Infraestructura
{
    public class ServicioDeAisladosTest
    {
        ServicioDeAislados servicio;
        IObserver<Aislados> emisorDeAislados;
        RepositorioDeAislados repositorio;
        Aislados aislados;

        [SetUp]
        public void setup()
        {
            emisorDeAislados = Substitute.For<IObserver<Aislados>>();
            repositorio = Substitute.For<RepositorioDeAislados>();
            servicio = new ServicioDeAislados(emisorDeAislados, repositorio);

            aislados = Substitute.For<Aislados>();
        }

        [Test]
        public void actualizar_cantidad_de_aislados()
        {
            repositorio.CantidadActualDeAislados().Returns(1);
            repositorio.TopeDeAislados().Returns(4);

            servicio.ActualizarAislados();

            repositorio.Received(1).ActualizarCantidadAislados();
        }
        
        [Test]
        public void reiniciar_cuenta_de_aislados()
        {
            servicio.ReiniciarCuentaDeAislados();

            repositorio.Received(1).ReiniciarCuentaDeAislados();
        }

        [Test]
        public void emitir_aislados_actualizados()
        {
            repositorio.CantidadActualDeAislados().Returns(1);
            repositorio.TopeDeAislados().Returns(4);

            servicio.ActualizarAislados();

            emisorDeAislados.Received(1).OnNext(Arg.Any<Aislados>());
        }

        [Test]
        public void emitir_aislados_actualizados_cuando_falta_un_aislado()
        {
            repositorio.CantidadActualDeAislados().Returns(3);
            repositorio.TopeDeAislados().Returns(4);

            servicio.ActualizarAislados();

            emisorDeAislados.Received(1).OnNext(Arg.Any<Aislados>());
        }  
        [Test]
        public void no_emitir_aislados_actualizados_cuando_is_igual_que_el_tope()
        {
            repositorio.CantidadActualDeAislados().Returns(4);
            repositorio.TopeDeAislados().Returns(4);

            servicio.ActualizarAislados();

            emisorDeAislados.DidNotReceive().OnNext(Arg.Any<Aislados>());
        }        
        
        [Test]
        public void no_emitir_aislados_actualizados()
        {
            repositorio.CantidadActualDeAislados().Returns(5);
            repositorio.TopeDeAislados().Returns(4);

            servicio.ActualizarAislados();

            emisorDeAislados.DidNotReceive().OnNext(Arg.Any<Aislados>());
        }
    }
}
