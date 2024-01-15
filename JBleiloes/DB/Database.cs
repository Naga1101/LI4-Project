﻿using JBleiloes.data;

using JBleiloes.DB.Tabelas;

namespace JBleiloes.DB
{
    public class Database
    {
        private DBUtilizador DBUtilizador;
        private DBLeilao DBLeilao;

        public Database()
        {
            this.DBUtilizador = DBUtilizador.getInstance();
            this.DBLeilao = DBLeilao.getInstance();
        }

        public Utilizador getUtilizador(string username)
        {
            return this.DBUtilizador.getUser(username);
        }

        public Leilao getLeilao(int idLeilao)
        {
            return this.DBLeilao.getLeilao(idLeilao);
        }
    
    }
}