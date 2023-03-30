using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD15_Projeto.DarMedicamento
{
    public class MedicaIdoso
    {
        public int ID_IdosoMedica { get; set; }
        public int ID_Medicamento { get; set; }
        public int ID_Idoso { get; set; }
        public string Dose { get; set; }
        public MedicaIdoso() { }

        public MedicaIdoso(int id_medicamento, int id_idoso, string dose)
        {
            ID_Medicamento = id_medicamento;
            ID_Idoso = id_idoso;
            Dose = dose;
        }

        public void Guardar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"INSERT INTO IdosoMedica (ID_Medicamento,ID_Idoso,dose) 
                            Values
                            (@ID_Medicamento,@ID_Idoso,@dose)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ID_Medicamento",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Medicamento
                },
                new SqlParameter()
                {
                    ParameterName="@ID_Idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@dose",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Dose
                },


            };
            //executar
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
             
            string sql = "SELECT * From IdosoMedica";
            return bd.DevolveSQL(sql);
            
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE IdosoMedica SET dose=@dose, ID_Medicamento=@id_medicamento, ID_Idoso=@id_idoso
                            where ID_IdosoMedica=@ID_IdosoMedica";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ID_Medicamento",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Medicamento
                },
                new SqlParameter()
                {
                    ParameterName="@ID_Idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@dose",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Dose
                },
                new SqlParameter()
                {
                    ParameterName="@ID_IdosoMedica",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_IdosoMedica
                },

            };

            bd.ExecutaSQL(sql, parametros);
        }
    }
}
