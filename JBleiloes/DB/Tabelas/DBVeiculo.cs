using Dapper;
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

        public void registaVeiculo(string Marca, string Modelo, int Ano, decimal Quilometragem/*, string DUA, string Seguro*/, string dono)
        {
            string query = "INSERT INTO [dbo].[Veículo] (Marca, Modelo, Ano, Quilometragem, DUA, Seguro, dono, id)" +
                $"VALUES ('{Marca}, '{Modelo}', {Ano}, {Quilometragem}, '{null}', '{null}', '{dono}', 5)";
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


    }
}
