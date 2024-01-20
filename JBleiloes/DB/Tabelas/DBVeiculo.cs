using Dapper;
using JBleiloes.data.Licitacoes;
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
            string query = "INSERT INTO [dbo].[Veiculo]" +
                           "([Marca], [Modelo], [Ano], [Quilometragem], [DUA], [Seguro], [Dono])" +
                           $"VALUES ('{Marca}', '{Modelo}', {Ano}, {Quilometragem}, 'ASEXX4', 'SEGUROS LDA', '{dono}')";
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    Console.WriteLine("Before Execute");
                    connection.Query(query);
                    query = "SELECT MAX(id) FROM [dbo].[Veiculo]";
                    int maxID = connection.QueryFirst<int>(query);
                    Console.WriteLine("After Execute");
                    return maxID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateDonoVeiculo(int id_veiculo, string new_owner)
        {
            string query = $"UPDATE [dbo].[Veiculo] SET [dono] = {new_owner} WHERE id = {id_veiculo}";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                connection.Query(query);
            }
        }

    }
}
