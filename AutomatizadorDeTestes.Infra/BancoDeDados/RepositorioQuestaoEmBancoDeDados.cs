using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.ModuloDisciplina;
using AutomatizadorDeTestes.Dominio.ModuloMateria;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;

namespace AutomatizadorDeTestes.Infra.BancoDeDados
{
    public class RepositorioQuestaoEmBancoDeDados : IRepositorioQuestao
    {

        private const string enderecoBanco =
                "Data Source=(LocalDb)\\MSSQLLocalDB;" +
                "Initial Catalog=AutomatizadorDeTestesDB;" +
                "Integrated Security=True;" +
                "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBQUESTAO] 
                (
                    [DISCIPLINA_NUMERO],
                    [MATERIA_NUMERO],
                    [ENUNCIADO],
                    [RESPOSTA]
	            )
	            VALUES
                (
                    @DISCIPLINA_NUMERO,
                    @MATERIA_NUMERO,
                    @ENUNCIADO,
                    @RESPOSTA
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBQUESTAO]	
		        SET
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO,
                    [MATERIA_NUMERO] = @MATERIA_NUMERO,
                    [ENUNCIADO] = @ENUNCIADO,
                    [RESPOSTA] = @RESPOSTA
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBQUESTAO]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
        @"SELECT 
           Q.NUMERO, 
           Q.ENUNCIADO,
           Q.RESPOSTA,
           D.NUMERO AS DISCIPLINA_NUMERO, 
           D.NOME AS DISCIPLINA_NOME,
           MT.NUMERO AS MATERIA_NUMERO, 
           MT.NOME AS MATERIA_NOME
           FROM 
               TBQUESTAO AS Q
           INNER JOIN 
                TBDISCIPLINA AS D ON DISCIPLINA_NUMERO = D.NUMERO
           INNER JOIN 
                TBMATERIA AS MT ON MATERIA_NUMERO = MT.NUMERO";

        private const string sqlSelecionarPorNumero =
                @"SELECT 
                Q.NUMERO, 
                Q.ENUNCIADO, 
                Q.RESPOSTA, 
                D.NUMERO AS DISCIPLINA_NUMERO, 
                D.NOME AS DISCIPLINA_NOME,
                MT.NUMERO AS MATERIA_NUMERO,
                MT.NOME AS MATERIA_NOME
                FROM 
                    TBQUESTAO AS Q
                INNER JOIN 
                       TBDISCIPLINA AS D 
                ON D.NUMERO = DISCIPLINA_NUMERO
                INNER JOIN TBMATERIA AS MT
                ON
                     MT.NUMERO = MATERIA_NUMERO
                WHERE
                    Q.NUMERO = @NUMERO";

        
        private const string sqlInserirAlternativas =
           @"INSERT INTO [TBALTERNATIVA]
                (
		            [QUESTAO_NUMERO],
		            [LETRA],
		            [DESCRICAO]
	            )
                 VALUES
                (
		            @QUESTAO_NUMERO,
		            @LETRA,
		            @DESCRICAO
	            ); SELECT SCOPE_IDENTITY();";

        private const string sqlSelecionarAlternativas =
             @"SELECT 
	            [NUMERO],
                [QUESTAO_NUMERO],
                [LETRA],
                [DESCRICAO]
              FROM 
	            [TBALTERNATIVA]
              WHERE 
	            [QUESTAO_NUMERO] = @QUESTAO_NUMERO";


        private const string sqlExcluirAlternativa =
          @"DELETE FROM [TBALTERNATIVA]
		        WHERE
			        [QUESTAO_NUMERO] = @QUESTAO_NUMERO";



        #endregion

        #region QUESTAO

        public ValidationResult Inserir(Questao novoRegistro)
        {
            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;


            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosQuestao(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Questao registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosQuestao(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            AdicionarAlternativas(registro, registro.Alternativas);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Questao registro)
        {
            ExcluirAlternativa(registro);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", registro.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Questao SelecionarPorNumero(int numero)
        {

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            Questao questao = null;

            if (leitorQuestao.Read())
                questao = ConverterParaQuestao(leitorQuestao);

            conexaoComBanco.Close();

            CarregarAlternativas(questao);

            return questao;
        }

        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestao.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestao);
                CarregarAlternativas(questao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        private Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            int numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            int numeroDisciplina = Convert.ToInt32(leitorQuestao["DISCIPLINA_NUMERO"]);
            int numeroMateria = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            string enunciado = Convert.ToString(leitorQuestao["ENUNCIADO"]);
            string alternativaCorreta = Convert.ToString(leitorQuestao["RESPOSTA"]);

            string nomeDisciplina = Convert.ToString(leitorQuestao["DISCIPLINA_NOME"]);
            string nomeMateria = Convert.ToString(leitorQuestao["MATERIA_NOME"]);

            var questao = new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Resposta = alternativaCorreta,

                Disciplina = new Disciplina
                {
                    Numero = numeroDisciplina,
                    Nome = nomeDisciplina
                },

                Materia = new Materia
                {
                    Numero = numeroMateria,
                    Nome = nomeMateria
                }

            };

            return questao;
        }

        private static void ConfigurarParametrosQuestao(Questao novaQuestao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novaQuestao.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", novaQuestao.Disciplina.Numero);
            comando.Parameters.AddWithValue("MATERIA_NUMERO", novaQuestao.Materia.Numero);
            comando.Parameters.AddWithValue("ENUNCIADO", novaQuestao.Enunciado);
            comando.Parameters.AddWithValue("RESPOSTA", novaQuestao.Resposta);

        }
        public AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();

        }

        private ValidationResult Validar(Questao registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = SelecionarTodos()
               .Select(x => x.Enunciado.ToLower())
               .Contains(registro.Enunciado.ToLower());

            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Enunciado já está cadastrado"));

            return resultadoValidacao;
        }

        #endregion

        #region ALTERNATIVA
        public void AdicionarAlternativas(Questao questao, List<Alternativa> alternativas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            foreach (Alternativa alternativa in alternativas)
            {
                bool alternativaAdicionada = questao.AdicionarAlternativa(alternativa);

                if (alternativaAdicionada)
                {
                    SqlCommand comandoInsercao = new SqlCommand(sqlInserirAlternativas, conexaoComBanco);

                    ConfigurarParametrosAlternativa(alternativa, comandoInsercao);
                    var numero = comandoInsercao.ExecuteScalar();
                    alternativa.Numero = Convert.ToInt32(numero);
                }
            }

            conexaoComBanco.Close();

        }

        private void ConfigurarParametrosAlternativa(Alternativa alternativa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", alternativa.Numero);
            comando.Parameters.AddWithValue("LETRA", alternativa.Letra);
            comando.Parameters.AddWithValue("DESCRICAO", alternativa.Descricao);
            comando.Parameters.AddWithValue("QUESTAO_NUMERO", alternativa.Questao.Numero);
        }

        private void CarregarAlternativas(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarAlternativas, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            SqlDataReader leitorAlternativa = comandoSelecao.ExecuteReader();


            while (leitorAlternativa.Read())
            {
                Alternativa alternativa = ConverterParaAlternativa(leitorAlternativa);

                questao.AdicionarAlternativa(alternativa);
            }

            conexaoComBanco.Close();
        }

        private Alternativa ConverterParaAlternativa(SqlDataReader leitorItemTarefa)
        {
            var numero = Convert.ToInt32(leitorItemTarefa["NUMERO"]);
            var letra = Convert.ToString(leitorItemTarefa["LETRA"]);
            var descricao = Convert.ToString(leitorItemTarefa["DESCRICAO"]);

            var alternativa = new Alternativa
            {
                Numero = numero,
                Letra = letra,
                Descricao = descricao
            };

            return alternativa;
        }


        public List<Questao> Sortear(Materia materia, int quantidade)
        {
            int limite = 0;
            List<Questao> questoesSorteadas = new List<Questao>();
            List<Questao> questoesMateriaSelecionada = SelecionarTodos().Where(x => x.Materia.Nome.Equals(materia.Nome)).ToList();

            Random random = new Random();
            List<Questao> questoes = questoesMateriaSelecionada.OrderBy(item => random.Next()).ToList();

            foreach (Questao questao in questoes)
            {
                questoesSorteadas.Add(questao);
                limite++;
                if (limite == quantidade)
                    break;
            }


            return questoesSorteadas;
        }

        public List<Questao> SortearQuestoesRecuperacao(Disciplina disciplina, int quantidade)
        {
            {
                throw new NotImplementedException();
                int limite = 0;
                List<Questao> questoesSorteadas = new List<Questao>();
                List<Questao> questoesDisciplinaSelecionada = SelecionarTodos().Where(x => x.Disciplina.Nome.Equals(disciplina.Nome)).ToList();

                Random random = new Random();
                List<Questao> questoes = questoesDisciplinaSelecionada.OrderBy(item => random.Next()).ToList();

                foreach (Questao questao in questoes)
                {
                    questoesSorteadas.Add(questao);
                    limite++;
                    if (limite == quantidade)
                        break;
                }

                return questoesSorteadas;
            }
        }


        private void ExcluirAlternativa(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluirAlternativa, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }


        #endregion

    }
}