﻿using NSubstitute;
using NUnit.Framework;
using Scripts.GamePlay.Dominio;
using Scripts.GamePlay.Infraestructura;
using UniRx;
using System;

namespace Tests.GamePlay.Infraestructura
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
            servicio.ActualizarAislados();

            repositorio.Received(1).DarAisladosActualizados();
        }


        [Test]
        public void emitir_aislados_actualizados()
        {
            repositorio.DarAisladosActualizados().Returns(aislados);

            servicio.ActualizarAislados();

            emisorDeAislados.Received(1).OnNext(Arg.Is(aislados));
        }
    }
}
