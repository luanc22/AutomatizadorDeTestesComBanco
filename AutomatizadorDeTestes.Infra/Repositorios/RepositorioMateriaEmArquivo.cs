using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Infra.Compartilhado;

namespace AutomatizadorDeTestes.Infra.Repositorios
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Materia novoRegistro)
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

        public List<Materia> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }

        private ValidationResult Validar(Materia registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var materias = ObterRegistros();
            foreach(var m in materias)
            {
                if(m.Nome.ToLower() == registro.Nome.ToLower() && m.Serie == registro.Serie && registro.Numero == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome da matéria já está cadastrado com a série selecionada"));

            }

            return resultadoValidacao;
        }


    }
}
