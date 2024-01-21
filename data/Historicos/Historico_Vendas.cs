namespace JBleiloes.data.Historicos
{
    public class Historico_Vendas
    {
        public string cliente {get;set;}
        
        public int id_leilao { get;set;}
        public int id_historico_vendas { get;set;}

        public Historico_Vendas() { }

        public Historico_Vendas (string cliente, int id_leilao, int id_historico_vendas)
        {
            this.cliente = cliente;
            this.id_leilao = id_leilao;
            this.id_historico_vendas = id_historico_vendas;
        }
    }
}
