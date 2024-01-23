using Dapper;
using JBleiloes.data.Veiculos;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBVeiculo
    {
        private static DBVeiculo? singleton = null;

        private DBVeiculo() { }

        public static DBVeiculo getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBVeiculo();
            }
            return singleton;
        }

        public int RegistaVeiculo(string Marca, string Modelo, int Ano, decimal Quilometragem, string dono)
        {
            string insertQuery = "INSERT INTO [dbo].[Veiculo] ([Marca], [Modelo], [Ano], [Quilometragem], [DUA], [Seguro], [Dono]) VALUES (@Marca, @Modelo, @Ano, @Quilometragem, 'ASEXX4', 'SEGUROS LDA', @Dono)";
            string selectQuery = "SELECT MAX(id) FROM [dbo].[Veiculo]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    Console.WriteLine("Before Execute");
                    connection.Execute(insertQuery, new { Marca, Modelo, Ano, Quilometragem, Dono = dono });
                    int maxID = connection.QueryFirst<int>(selectQuery);
                    Console.WriteLine("After Execute");
                    return maxID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Veiculo getVeiculo(int id)
        {
            string query = $"SELECT * FROM [dbo].[Veiculo] WHERE id = {id} ";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                Veiculo v = connection.QueryFirst<Veiculo>(query);
                return v;
            }
        }

        public void updateDonoVeiculo(int id_veiculo, string new_owner)
        {
            string query = $"UPDATE [dbo].[Veiculo] SET [dono] = '{new_owner}' WHERE id = {id_veiculo}";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                connection.Query(query);
            }
        }
    }
}
