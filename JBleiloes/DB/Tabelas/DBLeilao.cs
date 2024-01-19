using Dapper;
using JBleiloes.Components.Pages.Leilões;
using JBleiloes.data.Leiloes;
using JBleiloes.DB;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBLeilao
    {
        private static DBLeilao? singleton = null;

        private DBLeilao() { }

        public static DBLeilao getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBLeilao();
            }
            return singleton;
        }

        public Leilao getLeilao(int idLeilao)
        {
            Leilao? leilao = null;
            string query = "SELECT * FROM [dbo].[Leilão] WHERE id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    leilao = connection.QueryFirst<Leilao>(query, new { Id = idLeilao });
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return leilao;
        }

        public List<Leilao> GetLeiloesDecorrer()
        {
            List<Leilao> leiloes = new List<Leilao>();
            string query = "SELECT * FROM dbo.Leilão WHERE a_decorrer = 1"; // Filter auctions in progress

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    IEnumerable<Leilao> result = connection.Query<Leilao>(query);
                    leiloes.AddRange(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return leiloes;
        }
        
        public byte getUserTypeLeilao(string username)
        {
            string query = $"SELECT [tipo_utilizador] FROM [JBLeiloes].[dbo].[Utilizador] WHERE [username] = '{username}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    byte res = connection.QuerySingle<byte>(query);

                    return res;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            string query = "SELECT * FROM [dbo].[Leilão]";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                return connection.Query<Leilao>(query);
            }
        }
        public void registaLeilao(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, TimeSpan tempo_de_leilao)
        {
            string query = "INSERT INTO [dbo].[Leilão] (id, titulo, valor_inicial, vendedor, valor_minimo, valor_atual, veiculo, aprovado, a_decorrer, comprador, tempo_de_leilão, imagem)" +
                $"(5,'{titulo}', {valor_inicial}, '{valor_inicial}', {vendedor}, {valor_minimo}, 0, 0, 0, NULL, '{tempo_de_leilao}', 'car_image1.jpg')";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    connection.Query(query);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public IEnumerable<Leilao> getLeiloesUtilizador(string username)
        {
            string query = $"SELECT * FROM [dbo].[Leilão] where vendedor = '{username}'";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                var leiloes = connection.Query<Leilao>(query);

                foreach (var leilao in leiloes)
                {
                    yield return leilao;
                }
            }
        }

        public IEnumerable<Leilao> GetLeiloesUtilizadorWatchList(string username)
        {
            string query = @"SELECT Leilão.* FROM Watchlist JOIN Leilão ON Watchlist.id_leilão = Leilão.id WHERE Watchlist.id_cliente = @Username";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    var leiloes = connection.Query<Leilao>(query, new { Username = username });
                    return leiloes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }      
}

public class LeilaoRepository
{
    public IEnumerable<Leilao> GetAllLeiloes()
    {
        string query = "SELECT * FROM [dbo].[Leilão]";

        using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
        {
            connection.Open();
            return connection.Query<Leilao>(query);
        }
    }
}