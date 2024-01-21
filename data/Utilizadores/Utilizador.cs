namespace JBleiloes.data.Utilizadores
{
    public class Utilizador
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public int cc { get; private set; }
        public int NIF { get; private set; }
        public string data_nascimento { get; private set; }
        public byte tipo_utilizador { get; private set; }

        public Utilizador(string username, string password, string nome, string email, int cc, int NIF, string data_nascimento, byte tipo_utilizador)
        {
            this.username = username;
            this.password = password;
            this.nome = nome;
            this.email = email;
            this.cc = cc;
            this.NIF = NIF;
            this.data_nascimento = data_nascimento;
            this.tipo_utilizador = tipo_utilizador;
        }
        public Utilizador()
        {
        }

        public string getPassword()
        {
            return password;
        }

        public string getUsername()
        {
            return username;
        }
    }
}