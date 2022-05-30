using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloDisciplina
{
    public class ConfiguracaoToolboxDisciplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Disciplinas";

        public override string TooltipInserir { get { return "Inserir uma disciplina"; } }

        public override string TooltipEditar { get { return "Editar uma disciplina"; } }

        public override string TooltipExcluir { get { return "Excluir uma disciplina"; } }
    }
}
