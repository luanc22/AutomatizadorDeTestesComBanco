using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatizadorDeTestes.Dominio.ModuloQuestao;
using AutomatizadorDeTestes.Dominio.ModuloTeste;

namespace AutomatizadorDeTestes.Infra.BancoDeDados
{
    public class RepositorioTesteEmBancoDeDados : IRepositorioTeste
    {
        RepositorioDisciplinaEmBancoDeDados repositorioDisciplina = new RepositorioDisciplinaEmBancoDeDados();
        RepositorioMateriaEmBancoDeDados repositorioMateria = new RepositorioMateriaEmBancoDeDados();


        private const string enderecoBanco =
                "Data Source=(LocalDb)\\MSSQLLocalDB;" +
                "Initial Catalog=AutomatizadorDeTestesDB;" +
                "Integrated Security=True;" +
                "Pooling=False";

        private const string sqlInserir =
            @"INSERT INTO [TBTESTE] 
                (
                    [TITULO],
                    [DATACRIACAO],
                    [MATERIA_NUMERO],
                    [DISCIPLINA_NUMERO]
                )
	            VALUES
                (
                    @TITULO,
                    @DATACRIACAO,
                    @MATERIA_NUMERO,
                    @DISCIPLINA_NUMERO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBTESTE]	
		        SET
			        [TITULO] = @TITULO,
			        [DATACRIACAO] = @DATACRIACAO,
                    [MATERIA_NUMERO] = @MATERIA_NUMERO,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBTESTE]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarPorNumero =
            @"SELECT
	                T.NUMERO,
                    T.TITULO,
                    T.DATACRIACAO,

                    D.NUMERO AS DISCIPLINA_NUMERO,
                    D.NOME AS DISCIPLINA_NOME,
                    MT.NUMERO AS MATERIA_NUMERO,
                    MT.NOME AS MATERIA_NOME
                
                FROM 
	                TBTESTE AS T 
                INNER JOIN 
                    TBDISCIPLINA AS D ON DISCIPLINA_NUMERO = D.NUMERO
                INNER JOIN 
                    TBMATERIA AS MT ON MATERIA_NUMERO = MT.NUMERO
                WHERE
                    T.NUMERO = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT
	                T.NUMERO,
                    T.TITULO,
                    T.DATACRIACAO,

                    D.NUMERO AS DISCIPLINA_NUMERO,
                    D.NOME AS DISCIPLINA_NOME,
                    MT.NUMERO AS MATERIA_NUMERO,
                    MT.NOME AS MATERIA_NOME

              FROM 
	                TBTESTE AS T 
                INNER JOIN 
                    TBDISCIPLINA AS D ON DISCIPLINA_NUMERO = D.NUMERO
                INNER JOIN 
                    TBMATERIA AS MT ON MATERIA_NUMERO = MT.NUMERO";

        private const string sqlSelecionarQuestoesDoTeste =
           @"SELECT 
	                Q.NUMERO, 
	                Q.ENUNCIADO
                FROM 
	                TBQUESTAO AS Q INNER JOIN TBQUESTAO_TBTESTE AS QT 
                ON 
	                Q.NUMERO = QT.QUESTAO_NUMERO
                WHERE 
	                QT.TESTE_NUMERO = TESTE_NUMERO";

        private const string sqlAdicionarQuestaoNoTeste =
            @"INSERT INTO [TBQUESTAO_TBTESTE] 
                (
                    [TESTE_NUMERO],
                    [QUESTAO_NUMERO]
	            )
	            VALUES
                (
                    @TESTE_NUMERO,
                    @QUESTAO_NUMERO
                )";

        private const string sqlRemoverQuestaoDoTeste =
            @"DELETE FROM 
                TBQUESTAO_TBTESTE
            WHERE 
	            [QUESTAO_NUMERO] = @QUESTAO_NUMERO";

        public ValidationResult Editar(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTeste(teste, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Teste teste, List<Questao> questoesSelecionadas, List<Questao> questoesNaoSelecionadas)
        {
            var resultadoValidacao = Editar(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            foreach (var questao in questoesNaoSelecionadas)
            {
                if (teste.Questoes.Contains(questao))
                    RemoverQuestao(questao);
            }

            foreach (var questao in questoesSelecionadas)
            {
                AdicionarQuestao(teste, questao);
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", teste.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Inserir(Teste novoTeste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(novoTeste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTeste(novoTeste, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoTeste.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            Teste teste = null;

            if (leitorTeste.Read())
                teste = ConverterParaTeste(leitorTeste);

            conexaoComBanco.Close();

            CarregarQuestoes(teste);

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            List<Teste> testes = new List<Teste>();

            while (leitorTeste.Read())
            {
                Teste teste = ConverterParaTeste(leitorTeste);

                testes.Add(teste);
            }

            conexaoComBanco.Close();

            return testes;
        }

        private void CarregarQuestoes(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarQuestoesDoTeste, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("QUESTAO_NUMERO", teste.Numero);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestoesTeste = comandoSelecao.ExecuteReader();


            while (leitorQuestoesTeste.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestoesTeste);

                teste.AdicionarQuestao(questao);
            }

            conexaoComBanco.Close();
        }

        #region Métodos privados

        private void ConfigurarParametrosTeste(Teste teste, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", teste.Numero);
            comando.Parameters.AddWithValue("TITULO", teste.Titulo);
            comando.Parameters.AddWithValue("DATACRIACAO", teste.dataCriacao);
            comando.Parameters.AddWithValue("MATERIA_NUMERO", teste.Materia.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", teste.Disciplina.Numero);
        }

        private Teste ConverterParaTeste(SqlDataReader leitorTeste)
        {
            var numero = Convert.ToInt32(leitorTeste["NUMERO"]);
            var titulo = Convert.ToString(leitorTeste["TITULO"]);
            var dataCriacao = Convert.ToDateTime(leitorTeste["DATACRIACAO"]);
            var numeroMateria = Convert.ToInt32(leitorTeste["MATERIA_NUMERO"]);
            var numeroDisciplina = Convert.ToInt32(leitorTeste["DISCIPLINA_NUMERO"]);

            var teste = new Teste
            {
                Numero = numero,
                Titulo = titulo,
                dataCriacao = dataCriacao,
                Materia = repositorioMateria.SelecionarPorNumero(numeroMateria),
                Disciplina = repositorioDisciplina.SelecionarPorNumero(numeroDisciplina)
            };

            return teste;
        }

        private Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            var numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            var enunciado = Convert.ToString(leitorQuestao["ENUNCIADO"]);
            var resposta = Convert.ToString(leitorQuestao["RESPOSTA"]);
            var numeroMateria = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            var numeroDisciplina = Convert.ToInt32(leitorQuestao["DISCIPLINA_NUMERO"]);

            var questao = new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Resposta = resposta,
                Materia = repositorioMateria.SelecionarPorNumero(numeroMateria),
                Disciplina = repositorioDisciplina.SelecionarPorNumero(numeroDisciplina)
            };

            return questao;
        }

        private void AdicionarQuestao(Teste teste, Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlAdicionarQuestaoNoTeste, conexaoComBanco);

            comandoInsercao.Parameters.AddWithValue("TESTE_NUMERO", teste.Numero);
            comandoInsercao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            comandoInsercao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        private void RemoverQuestao(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlRemoverQuestaoDoTeste, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        #endregion
    }
}