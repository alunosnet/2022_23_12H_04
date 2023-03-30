using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD15_Projeto.Medicamentos
{
    public class Medicamento
    {
        public int ID_Medicamento { get; set; }
        public string Nome { get; set; }
        public byte[] Fotografia { get; set; }
        public string Contra { get; set; }
        public Medicamento()
        { }

        public Medicamento(int id_medicamento, string nome, byte[] fotografia, string contra)
        {
            ID_Medicamento = id_medicamento;
            Nome = nome;
            Fotografia = fotografia;
            Contra = contra;
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Medicamentos(nome,fotografia,contra) VALUES 
                        (@nome,@fotografia,@contra)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@fotografia",
                    SqlDbType=System.Data.SqlDbType.VarBinary,
                    Value=this.Fotografia
                },
                new SqlParameter()
                {
                    ParameterName="@contra",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Contra
                },

            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Medicamentos";
            return bd.DevolveSQL(sql);
        }

        internal static void Apagar(BaseDados bd, int id_medicamento_escolhido)
        {
            string sql = "DELETE FROM Medicamentos WHERE id_medicamento=" + id_medicamento_escolhido;
            bd.ExecutaSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE Medicamentos SET nome=@nome,contra=@contra ";
            if (this.Fotografia != null)
                sql += ",fotografia=@fotografia";
            sql += " WHERE id_medicamento=@id_medicamento";

            List<SqlParameter> parametros = new List<SqlParameter>()
                {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@contra",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Contra
                },
                new SqlParameter()
                {
                    ParameterName="@id_medicamento",
                    SqlDbType=SqlDbType.Int,
                    Value=this.ID_Medicamento
                }
            };
            if (this.Fotografia != null)
                parametros.Add(
                       new SqlParameter()
                       {
                           ParameterName = "@fotografia",
                           SqlDbType = System.Data.SqlDbType.VarBinary,
                           Value = this.Fotografia
                       }
                    );
            bd.ExecutaSQL(sql, parametros);
        }

        internal void ProcurarPorMedicamento(BaseDados bd, int id_medicamento)
        {
            string sql = "SELECT * FROM Medicamentos WHERE ID_Medicamento=" + id_medicamento;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.ID_Medicamento = int.Parse(dados.Rows[0]["id_medicamento"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.Fotografia= (byte[])dados.Rows[0]["fotografia"];
                this.Contra = dados.Rows[0]["contra"].ToString();
            }
        }

        public static DataTable ListarMedicamentos(BaseDados bd)
        {
            string sql = "SELECT * FROM Medicamentos";
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
