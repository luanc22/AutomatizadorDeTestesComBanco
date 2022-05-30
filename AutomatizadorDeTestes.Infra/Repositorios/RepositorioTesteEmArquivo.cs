using FluentValidation;
using FluentValidation.Results;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.ModuloTeste;
using AutomatizadorDeTestes.Infra.Compartilhado;

namespace AutomatizadorDeTestes.Infra.Repositorios
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Testes.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Teste novoRegistro)
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

        private ValidationResult Validar(Teste registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = ObterRegistros()
               .Select(x => x.Titulo.ToLower())
               .Contains(registro.Titulo.ToLower());

            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Titulo já está cadastrado"));

            return resultadoValidacao;
        }


        public List<Teste> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }


    }
}
