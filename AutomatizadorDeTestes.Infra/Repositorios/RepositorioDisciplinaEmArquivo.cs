using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Infra.Compartilhado;

namespace AutomatizadorDeTestes.Infra.Repositorios
{
    public class RepositorioDisciplinaEmArquivo : RepositorioEmArquivoBase<Disciplina>, IRepositorioDisciplina
    {

        public RepositorioDisciplinaEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Disciplinas.Count > 0)
                contador = dataContext.Disciplinas.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Disciplina novoRegistro)
        {
            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }


        public List<Disciplina> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public override List<Disciplina> ObterRegistros()
        {
            return dataContext.Disciplinas;
        }

        public override AbstractValidator<Disciplina> ObterValidador()
        {
            return new ValidadorDisciplina();

        }

        private ValidationResult Validar(Disciplina registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = ObterRegistros()
               .Select(x => x.Nome.ToLower())
               .Contains(registro.Nome.ToLower());

            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));

            return resultadoValidacao;
        }
    }
}
