using JBleiloes.data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JBleiloes.DB
{
    public class DBConfig
    {
        public static string Connection()
        {
            //return "Data Source=.;Initial Catalog=JBLeiloes;Integrated Security=True;Encrypt=False";
           return "Data Source=DESKTOP-47F6BAO\\SQLEXPRESS;Initial Catalog=JBLeiloes;Integrated Security=True;Encrypt=False";
        }
    }
}