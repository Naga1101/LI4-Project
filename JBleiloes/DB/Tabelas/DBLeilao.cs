using Dapper;
using JBleiloes.Components.Leiloes;
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
            string query = "SELECT * FROM [dbo].[Leilao] WHERE id = @Id";

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
            string query = "SELECT * FROM dbo.Leilao WHERE a_decorrer = 1 AND aprovado = 1"; // Filter auctions in progress

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
        public IEnumerable<Leilao> GetLeiloesUtilizadorWatchList(string username)
        {
            string query = @"SELECT Leilao.* FROM Watchlist JOIN Leilao ON Watchlist.id_leilao = Leilao.id WHERE Watchlist.id_cliente = @Username";

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
            string query = "SELECT * FROM [dbo].[Leilao]";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                return connection.Query<Leilao>(query);
            }
        }
        public IEnumerable<Leilao> getAllUserLeiloes()
        {
            string query = "SELECT * FROM dbo.Leilao INNER JOIN dbo.Utilizador ON Leilao.vendedor = Utilizador.username WHERE Utilizador.tipo_utilizador = 1 AND a_decorrer = 1;";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                return connection.Query<Leilao>(query);
            }

        }

        public void atualizarValorAtualLeilao(int id_leilao, decimal licitação)
        {
            string query = $"UPDATE [dbo].[Leilao] SET [valor_atual] = {licitação} WHERE id = {id_leilao}";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                connection.Query(query);
            }
        }

        public IEnumerable<Leilao> getAllAdminLeiloes()
        {
            string query = "SELECT * FROM dbo.Leilao INNER JOIN dbo.Utilizador ON Leilao.vendedor = Utilizador.username WHERE Utilizador.tipo_utilizador = 2 AND Leilao.a_decorrer = 1;";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                return connection.Query<Leilao>(query);
            }

        }
        public void registaLeilao(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, DateTime tempo_de_leilao, int id_veiculo)
        {
            byte aprovado = (vendedor == "admin") ? (byte)1 : (byte)0;

            string formattedDate = tempo_de_leilao.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $"INSERT INTO [dbo].[Leilao] (titulo, valor_inicial, vendedor, valor_minimo, valor_atual, veiculo, aprovado, a_decorrer, comprador, tempo_de_leilao, imagem)" +
                           $"VALUES ('{titulo}', {valor_inicial}, '{vendedor}', {valor_minimo}, 0, {id_veiculo}, {aprovado}, 0, NULL, '{formattedDate}', 'car_image1.jpg')";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void aprovarLeilao(int idLeilao)
        {
            string query = $"UPDATE [dbo].[Leilao] SET [aprovado] = 1 WHERE [id] = {idLeilao}";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    connection.Query(query);

                    query = $"UPDATE [dbo].[Leilao] SET [a_decorrer] = 1 WHERE [id] = {idLeilao}";
                    connection.Query(query);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Leilao> GetLeiloesDecorrerEAprovados()
        {
            List<Leilao> leiloes = new List<Leilao>();
            string query = "SELECT * FROM dbo.Leilao WHERE a_decorrer = 1 AND aprovado = 1"; // Filter auctions in progress

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

        public IEnumerable<Leilao> getLeiloesUtilizador(string username)
        {
            string query = $"SELECT * FROM [dbo].[Leilao] where vendedor = '{username}'";

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

        public void defineComprador(int id_leilao, string comprador)
        {
            string query = $"UPDATE [dbo].[Leilao] SET [comprador] = '{comprador}' WHERE id = {id_leilao}";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                connection.Query(query);
            }
        }

        public void removerA_Decorrer(int id_leilao)
        {
            string query = $"UPDATE [dbo].[Leilao] SET [a_decorrer] = 0 WHERE id = {id_leilao}";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                connection.Query(query);
            }
        }
    }      
}