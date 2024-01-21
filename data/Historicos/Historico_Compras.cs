namespace JBleiloes.data.Historicos
{
    public class Historico_Compras
    {
        public string cliente { get; set; }

        public int id_leilao { get; set; }
        public int id_historico_compras { get; set; }

        public Historico_Compras() { }

        public Historico_Compras(string cliente, int id_leilao, int id_historico_compras)
        {
            this.cliente = cliente;
            this.id_leilao = id_leilao;
            this.id_historico_compras = id_historico_compras;
        }
    }
}
