using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD15_Projeto.Visistas
{
    public class Visita
    {

        public int ID_Familiar { get; set; }
        public int ID_Idoso { get; set; }
        public int ID_Visita { get; set; }
        public DateTime DataVisita { get; set; }
        /*public DateTime Hora { get; set; }*/
        public Visita() { }

        public Visita(int id_familiar, int id_idoso,DateTime dataVisita/*, DateTime hora*/)
        {
            this.ID_Familiar = id_familiar;
            this.ID_Idoso = id_idoso;
            this.DataVisita = dataVisita;
            //this.Hora = hora;
        }
        public void Guardar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"INSERT INTO VISITAS (ID_Familiar,ID_Idoso,DataVisita) 
                            Values
                            (@ID_Familiar,@ID_Idoso,@DataVisita)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ID_Familiar",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Familiar
                },
                new SqlParameter()
                {
                    ParameterName="@ID_Idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@DataVisita",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataVisita
                },
                /*new SqlParameter()
                {
                    ParameterName="@Hora",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Hora
                },
                */

            };
            //executar
            bd.ExecutaSQL(sql, parametros);
        }

        public static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos FROM Visitas";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Visitas ORDER BY DataVisita DESC";
            return bd.DevolveSQL(sql);
        }

        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT ID_Visita,DataVisita FROM
                        (SELECT row_number() over (order by ID_Visita) as Num,* FROM Visitas) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto} ";
            return bd.DevolveSQL(sql);
        }
        public void ProcurarPorNrVisita(BaseDados bd, int idVisita)
        {
            string sql = "SELECT * FROM VISITAS WHERE ID_Visita=" + idVisita;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.ID_Visita = int.Parse(dados.Rows[0]["ID_Visita"].ToString());
                this.ID_Familiar = int.Parse(dados.Rows[0]["ID_Familiar"].ToString());
                this.ID_Idoso = int.Parse(dados.Rows[0]["ID_Idoso"].ToString());
                this.DataVisita = DateTime.Parse(dados.Rows[0]["DataVisita"].ToString());
            }
        }
        public static void ApagarVisita(BaseDados bd, int id_visita_escolhido)
        {
            string sql = "DELETE FROM VISITAS WHERE ID_Visita=" + id_visita_escolhido;
            bd.ExecutaSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE VISITAS SET ID_Idoso = @id_idoso, ID_Familiar = @id_familiar
                            , DataVisita = @DataVisita
                            WHERE ID_Visita = @ID_Visita";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id_visita",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Visita
                },
                new SqlParameter()
                {
                    ParameterName="@id_familiar",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Familiar
                },
                new SqlParameter()
                {
                    ParameterName="@id_idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@datavisita",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataVisita
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        internal void ProcurarPorIdVisita(BaseDados bd, int idvisita)
        {
            string sql = "SELECT * FROM VISITAS WHERE ID_Visita=" + idvisita;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.ID_Visita = int.Parse(dados.Rows[0]["ID_Visita"].ToString());
                this.ID_Familiar = int.Parse(dados.Rows[0]["ID_Familiar"].ToString());
                this.ID_Idoso = int.Parse(dados.Rows[0]["ID_Idoso"].ToString());
                this.DataVisita = DateTime.Parse(dados.Rows[0]["DataVisita"].ToString());
            }
        }
    }
}
