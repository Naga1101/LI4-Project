using Dapper;
using JBleiloes.data.Leiloes;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBWatchlist
    {
        private static DBWatchlist? singleton = null;

        private DBWatchlist() { }

        public static DBWatchlist getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBWatchlist();
            }
            return singleton;
        }

        public IEnumerable<Leilao> GetLeiloesUtilizadorWatchList(string username)
        {
            string query = @"SELECT Leilao.* FROM Watchlist JOIN Leilao ON Watchlist.id_Leilao = Leilao.id WHERE Watchlist.id_cliente = @Username";

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

        public void removerWatchlist(string username, int idLeilao)
        {
            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [dbo].[Watchlist] WHERE id_cliente = @IdCliente AND id_Leilao = @IdLeilao";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", username);
                    command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AdicionarWatchlist(string username, int idLeilao)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO [dbo].[Watchlist] (id_cliente, id_Leilao) VALUES (@IdCliente, @IdLeilao)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IdCliente", username);
                        command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool podeAdicionarWatchList(string username, int idLeilao)
        {
            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM [dbo].[Watchlist] WHERE id_cliente = @IdCliente AND id_Leilao = @IdLeilao";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", username);
                    command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}
