using JBleiloes.data.Leiloes;
using JBleiloes.data.Utilizadores;
using JBleiloes.DB;


namespace JBleiloes.data
{
    public class JBLeiloes
    {
        private Database db;

        public JBLeiloes()
        {
            this.db = new Database();
        }

        public Utilizador getUtilizador(string username)
        {
            return db.getUtilizador(username);
        }

        public bool validarLogin(string username, string password)
        {
            Utilizador user = db.getUtilizador(username);
            if (user == null) { return false; }
            else
            {
                if(user.getPassword().Equals(password)) { return true; };
            }
            return false;
        }

        public ICollection<Leilao> getLeilõesDecorrer()
        {
            return db.getLeiloesDecorrer();
        }

        public void registerUser(string username, string password, string nome, string email, int nº_cc, int NIF, string data_nascimento)
        {
            db.registerUser(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }
    }
}
