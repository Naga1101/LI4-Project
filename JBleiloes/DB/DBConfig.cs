using JBleiloes.data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JBleiloes.DB
{
    public class DBConfig
    {
        public const string USER = "LAPTOP-GRIEQPR6";
        public const string MACHINE = "LAPTOP-GRIEQPR6\\SQLEXPRESS";
        public const string DATABASE = "jbleiloes";

        public static string Connection()
        {
            return "Data Source =.; Initial Catalog = jbleiloes; Integrated Security = True; Encrypt = False";
        }
    }
}
