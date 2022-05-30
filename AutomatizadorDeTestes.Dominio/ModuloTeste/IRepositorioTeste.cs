using System;
using AutomatizadorDeTestes.Dominio.Compartilhado;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;
using System.Collections.Generic;
using FluentValidation.Results;
namespace AutomatizadorDeTestes.Dominio.ModuloTeste
{
    public interface IRepositorioTeste : IRepositorioBase<Teste>
    {
    }
}
