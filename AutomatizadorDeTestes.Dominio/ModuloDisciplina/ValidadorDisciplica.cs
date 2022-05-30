using FluentValidation;

namespace AutomatizadorDeTestes.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
              .NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
