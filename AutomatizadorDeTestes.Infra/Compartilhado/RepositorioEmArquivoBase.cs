using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using AutomatizadorDeTestes.Dominio.Compartilhado;

namespace AutomatizadorDeTestes.Infra.Compartilhado
{
    public abstract class RepositorioEmArquivoBase<T> where T : EntidadeBase<T>
    {

        protected DataContext dataContext;

        protected int contador = 0;

        public RepositorioEmArquivoBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public abstract AbstractValidator<T> ObterValidador();

        public abstract List<T> ObterRegistros();

        public virtual ValidationResult Inserir(T novoRegistro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;

        }

        public virtual ValidationResult Editar(T registro)
        {

            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();

                foreach (var item in registros)
                {
                    if (item.Numero == registro.Numero)
                    {
                        item.Atualizar(registro);
                        break;
                    }
                }
            }

            return resultadoValidacao;

        }

        public virtual ValidationResult Excluir(T registro)
        {
            var resultadoValidacao = new ValidationResult();

            var registros = ObterRegistros();

            if (registros.Remove(registro) == false)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            return resultadoValidacao;
        }



        public virtual T SelecionarPorNumero(int numero)
        {
            return ObterRegistros()
                .FirstOrDefault(x => x.Numero == numero);
        }
    }
}

