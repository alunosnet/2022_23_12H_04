using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

namespace M17AB_Projeto_Diogo.Models
{
    public class Visitas
    {
        BaseDados bd;

        public Visitas()
        {
            this.bd = new BaseDados();
        }
        public int ID_Visita;
        public DateTime DataVisita;


        public void adicionarVisita(int id_idoso, int id, DateTime DataVisita)
        {
            string sql = "SELECT * FROM Idosos WHERE id_idoso=@id_idoso";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //verificar disponibilidade do livro
                if (dados.Rows[0]["estado"].ToString() != "1")
                    throw new Exception("O Idoso não está disponível para visitas");
                //alterar estado do livro
                sql = "UPDATE Idosos SET estado=@estado WHERE id_idoso=@id_idoso";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=0 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO Visitas(id_idoso,id,DataVisita,estado) 
                            VALUES (@id_idoso,@id,@DataVisita,@estado)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso },
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
                    new SqlParameter() {ParameterName="@DataVisita",SqlDbType=SqlDbType.Date,Value=DataVisita},
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
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
        public void adicionarReserva(int id_idoso, int id, DateTime DataVisita)
        {
            string sql = "SELECT * FROM Idosos WHERE id_idoso=@id_idoso";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //testar se o livro ainda está disponível
                if (dados.Rows[0]["estado"].ToString() != "1")
                    throw new Exception("O Idoso não está disponível");
                //alterar estado do livro
                sql = "UPDATE Idosos SET estado=@estado WHERE id_idoso=@id_idoso";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=2 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO Visitas(id_idoso,id,DataVisita,estado) 
                            VALUES (@id_idoso,@id,@DataVisita,@estado)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso },
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
                    new SqlParameter() {ParameterName="@DataVisita",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=2 },
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

        public DataTable listaTodasVisitasComNomes()
        {
            string sql = @"SELECT ID_Visita,Nome_Idoso as NomeIdoso,nome as NomeFamiliar,DataVisita,visitas.estado
                        FROM Visitas inner join idosos on visitas.id_idoso=idosos.id_idoso
                        inner join utilizadores on visitas.id=utilizadores.id";
            return bd.devolveSQL(sql);
        }
        public DataTable listaTodosVisitasComNomes(int id)
        {
            string sql = @"SELECT ID_Visita,Nome_Idoso as NomeIdoso,nome as NomeFamiliar,DataVisita,
                        case
                            when Visitas.estado=0 then 'Concluído'
                            when Visitas.estado=1 then 'Em curso'
                            when Visitas.estado=2 then 'Reservado'
                        end as estado
                        FROM Visitas inner join Idosos on Visitas.id_idoso=Idosos.id_idoso
                        inner join utilizadores on Visitas.id=utilizadores.id Where visitas.id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID",SqlDbType=SqlDbType.Int,Value=id }
            };
            return bd.devolveSQL(sql, parametros);
        }


        public DataTable listaTodasVisitasPorConcluirComNomes()
        { 
            string sql = @"SELECT ID_Visita,Nome_Idoso as [Nome do Idoso], nome as [Nome do Familiar],DataVisita,visitas.estado
                        FROM Visitas inner join Idosos on visitas.id_idoso=Idosos.ID_Idoso
                        inner join utilizadores on visitas.id=utilizadores.id where visitas.estado!=0";
            return bd.devolveSQL(sql);
        }   

        public void alterarEstadoVisita(int id_visita)
        {
            DataTable dadosVisita = devolveDadosVisita(id_visita);
            int id_idoso = int.Parse(dadosVisita.Rows[0]["id_idoso"].ToString());
            int novoestadoidoso, novoestadovisita;

            if (dadosVisita.Rows[0]["estado"].ToString() == "2") //reserva para emprestimo
            {
                novoestadoidoso = 0;
                novoestadovisita = 1;
            }
            else
            {
                //emprestimo para devolucao
                novoestadovisita = 0;
                novoestadoidoso = 1;
            }
            string sql = "SELECT * FROM Idosos WHERE id_idoso=@id_idoso";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //alterar estado do livro
                sql = "UPDATE Idosos SET estado=@estado WHERE id_idoso=@id_idoso";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=novoestadoidoso },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //terminar empréstimo
                sql = @"UPDATE Visitas SET estado=@estado WHERE ID_Visita=@ID_Visita";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@ID_Visita",SqlDbType=SqlDbType.Int,Value=id_visita },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=novoestadovisita },
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
        public DataTable devolveDadosVisita(int id_visita)
        {
            string sql = "SELECT * FROM Visitas WHERE ID_Visita=@ID_Visita";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID_Visita",SqlDbType=SqlDbType.Int,Value=id_visita }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerVisita(int id_visita)
        {
            string sql = "DELETE FROM Visitas WHERE ID_Visita=@id_visita";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_visita",SqlDbType=SqlDbType.Int,Value= id_visita},
            };
            bd.executaSQL(sql, parametros);
        }

        public  void atualizaVisita()
        {
            String sql = "UPDATE Visitas SET DataVisita=@DataVisita";
            sql += " WHERE ID_Visita=@ID_Visita;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@DataVisita",SqlDbType=SqlDbType.DateTime,Value= DataVisita},
                new SqlParameter() {ParameterName="@ID_Visita",SqlDbType=SqlDbType.Int,Value=ID_Visita}
            };
            bd.executaSQL(sql, parametros);
        }
    }
}