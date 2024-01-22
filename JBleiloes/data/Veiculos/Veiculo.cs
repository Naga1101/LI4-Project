namespace JBleiloes.data.Veiculos
{
    public class Veiculo
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public decimal Quilometragem { get; private set; }
        public string DUA { get; private set; } 
        public string Seguro { get; private set; }
        public string dono { get; private set; }
        public int id { get; private set; }


        public Veiculo() { }

        public Veiculo(string marca, string modelo, int ano, decimal quilometragem, string dUA, string seguro, string dono, int id)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Quilometragem = quilometragem;
            DUA = dUA;
            Seguro = seguro;
            this.dono = dono;
            this.id = id;
        }
    }
}
