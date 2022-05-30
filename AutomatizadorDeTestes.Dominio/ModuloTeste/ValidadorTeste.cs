using FluentValidation;

namespace AutomatizadorDeTestes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Titulo)
                  .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Disciplina)
             .NotNull().NotEmpty();

            RuleFor(x => x.Questoes)
            .NotNull().NotEmpty();

        }
    }
}
