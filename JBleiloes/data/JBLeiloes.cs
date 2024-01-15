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
    }
}
