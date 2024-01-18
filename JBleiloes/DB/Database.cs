using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using JBleiloes.data.Leiloes;
using JBleiloes.data.Utilizadores;
using JBleiloes.DB.Tabelas;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JBleiloes.DB
{
    public class Database
    {
        private DBUtilizador DBUtilizador;
        private DBLeilao DBLeilao;
        private DBVeiculo DBVeiculo;

        public Database()
        {
            DBUtilizador = DBUtilizador.getInstance();
            DBLeilao = DBLeilao.getInstance();
            DBVeiculo = DBVeiculo.getInstance();
        }


        public bool validateLoginData(string username, string password)
        {
            return DBUtilizador.validateLoginInfo(username, password);
        }

        public Utilizador getUtilizador(string username)
        {
            return this.DBUtilizador.getUser(username);
        }

        public Leilao getLeilao(int idLeilao)
        {
            return this.DBLeilao.getLeilao(idLeilao);
        }

        public ICollection<Leilao> getLeiloesDecorrer()
        {
            return this.DBLeilao.getLeiloesDecorrer();
        }

        public void registerUser(string username, string password, string nome, string email, int nº_cc, int NIF, string data_nascimento)
        {
            DBUtilizador.addUtilizador(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }   

        public byte getUserTypeFromLeilao(string username)
        {
            return DBUtilizador.getUserTypeLeilao(username);
        }

        public void registaLeilaoEVeiculo(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, TimeSpan tempo_de_leilao, string Marca, string Modelo, int Ano, decimal Quilometragem)
        {
            DBVeiculo.registaVeiculo(Marca, Modelo, Ano, Quilometragem, vendedor);
            DBLeilao.registaLeilao(titulo, valor_inicial, vendedor, valor_minimo, tempo_de_leilao);
        }
    }
}
