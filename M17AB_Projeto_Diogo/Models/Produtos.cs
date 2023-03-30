using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace M17AB_Projeto_Diogo.Models
{
    public class Produtos
    {
        public int ID_Produto;
        public string nome;
        public decimal preco;
        public string categoria;
        public int stock;
        public string ean;

        BaseDados bd;

        public Produtos()
        {
            bd = new BaseDados();
        }


        public int Adicionar()
        {
            string sql = @"INSERT INTO Produtos(nome,ean,preco,categoria,stock)
                    VALUES (@nome,@ean,@preco,@categoria,@stock);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@ean",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.ean
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@categoria",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.categoria
                },
                new SqlParameter()
                {
                    ParameterName="@stock",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.stock
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosProdutos()
        {
            string sql = @"SELECT ID_Produto,nome,
                    preco, categoria, ean, stock
                    FROM Produtos";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosProdutos(int id_produto)
        {
            string sql = "SELECT * FROM Produtos WHERE ID_Produto=@ID_Produto";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID_Produto",SqlDbType=SqlDbType.Int,Value=id_produto }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerProduto(int id_produto)
        {
            string sql = "DELETE FROM Produtos WHERE id_produto=@id_produto";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value=id_produto }
            };
            bd.executaSQL(sql, parametros);
        }

        public void atualizaProduto()
        {
            string sql = "UPDATE Produtos SET nome=@nome,ean=@ean,preco=@preco,stock=@stock,";
            sql += "categoria=@categoria ";
            sql += " WHERE id_produto=@id_produto;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value = nome},
                new SqlParameter() {ParameterName="@ean",SqlDbType=SqlDbType.VarChar,Value = ean},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value = preco},
                new SqlParameter() {ParameterName="@categoria",SqlDbType=SqlDbType.VarChar,Value = categoria},
                new SqlParameter() {ParameterName="@stock",SqlDbType=System.Data.SqlDbType.Int, Value = stock},
                new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value = ID_Produto}
            };
            bd.executaSQL(sql, parametros);
        }

        public DataTable listaProdutosDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE stock>=1";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by nome";
            }
            return bd.devolveSQL(sql);
        }

        public DataTable listaProdutosDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE nome like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by nome";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal DataTable listaProdutosDisponiveisTipo(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Produtos WHERE stock >= 0 and categoria like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by nome";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }

    }
}