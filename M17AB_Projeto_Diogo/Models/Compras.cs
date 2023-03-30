using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace M17AB_Projeto_Diogo.Models
{
    public class Compras
    {
        BaseDados bd;

        public Compras()
        {
            this.bd = new BaseDados();
        }

        public void adicionarCompra(int id_produto, int ID, DateTime datacompra)
        {
            string sql = "SELECT * FROM produtos WHERE id_produto=@id_produto";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value=id_produto }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //verificar disponibilidade do produto
                if (int.Parse(dados.Rows[0]["stock"].ToString()) <= 0)
                    throw new Exception("Produto não está disponível");
                //alterar estado do produto
                sql = "UPDATE Produtos SET Stock=Stock -1 WHERE id_produto=@id_produto";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value=id_produto },

                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar Compras
                sql = @"INSERT INTO Compras(id_produto,ID,data_compra) 
                            VALUES (@id_produto,@ID,@data_compra)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value=id_produto },
                    new SqlParameter() {ParameterName="@ID",SqlDbType=SqlDbType.Int,Value=ID },
                    new SqlParameter() {ParameterName="@data_compra",SqlDbType=SqlDbType.Date,Value=datacompra},
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }

        public DataTable listaTodosComprasComNomes(int id)
        {
            string sql = @"SELECT ID_Compra,produtos.nome as nomeProduto,utilizadores.nome as nomeComprador,data_compra
                        FROM Compras inner join produtos on compras.id_produto=produtos.id_produto
                        inner join utilizadores on compras.ID=utilizadores.id Where compras.ID=@ID";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID",SqlDbType=SqlDbType.Int,Value=id }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public DataTable listaTodosComprasComNomes()
        {
            string sql = @"SELECT ID_Compra,produtos.nome as nomeProduto,utilizadores.nome as nomeComprador,data_compra
                        FROM Compras inner join produtos on compras.id_produto=produtos.id_produto
                        inner join utilizadores on compras.ID=utilizadores.id";
            return bd.devolveSQL(sql);
        }

        public DataTable listaTodosComprasConcluidasComNomes()
        {
            string sql = @"SELECT ID_Compra,produtos.nome as [Nome do Produto],utilizadores.nome as [Nome do Utilizador],data_compra,compras.stock
                        FROM Compras inner join produtos on compras.id_produto=produtos.id_produto
                        inner join utilizadores on compras.ID=utilizadores.id where compras.stock!=0";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosCompras(int ID_Compra)
        {
            string sql = "SELECT * FROM compras WHERE ID_Compra=@ID_Compra";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID_Compra",SqlDbType=SqlDbType.Int,Value=ID_Compra }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerCompra(int ID_Compra)
        {
            string sql = "DELETE FROM Compras WHERE ID_Compra=@ID_Compra";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID_Compra",SqlDbType=SqlDbType.Int,Value=ID_Compra }
            };
            bd.executaSQL(sql, parametros);
        }
    }
}