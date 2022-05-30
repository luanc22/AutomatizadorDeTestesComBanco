using AutomatizadorDeTestes.WinApp.Compartilhado;

namespace AutomatizadorDeTestes.WinApp.ModuloQuestao
{
    public class ConfiguracaoToolboxQuestao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Questões";

        public override string TooltipInserir { get { return "Inserir uma questão"; } }

        public override string TooltipEditar { get { return "Editar uma questão"; } }

        public override string TooltipExcluir { get { return "Excluir uma questão"; } }

        public override string TooltipVisualizarDetalhes { get { return "Visualizar Detalhes da Questão"; } }

        public override bool VisualizarDetalhesHabilitado => true;

    }
}
