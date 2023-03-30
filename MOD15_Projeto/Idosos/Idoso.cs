using MOD15_Projeto.Familiares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD15_Projeto.Idosos
{
    public class Idoso
    {
        public int ID_Idoso { get; set; }
        public string Nome_Idoso { get; set; }
        public string NIF_Idoso { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string NUtenteSaude { get; set; }
        public string Doencas { get; set; }
        public string Idade { get; set; }

        public Idoso() { }

        public Idoso(int id_Idoso, string nome_idoso, string nif_idoso, DateTime data_nasc, string nutenteSaude, string doencas, string idade)
        {
            ID_Idoso = id_Idoso;
            Nome_Idoso = nome_idoso;
            NIF_Idoso = nif_idoso;
            Data_Nasc = data_nasc;
            NUtenteSaude = nutenteSaude;
            Doencas = doencas;
            Idade = idade;
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Idoso(nome_idoso,nif_idoso,data_nasc,nutentesaude,doencas)
                           VALUES 
                           (@nome_idoso,@nif_idoso,@data_nasc,@nutentesaude,@doencas)";


            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome_idoso",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@nif_idoso",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Nasc
                },
                new SqlParameter()
                {
                    ParameterName="@nutentesaude",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NUtenteSaude
                },
                new SqlParameter()
                {
                    ParameterName="@doencas",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Doencas
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Idoso";
            return bd.DevolveSQL(sql);
        }
        public static void ApagarFamiliar(BaseDados bd, int id_idoso_escolhido)
        {
            string sql = "DELETE FROM Idoso WHERE ID_Idoso=" + id_idoso_escolhido;
            bd.ExecutaSQL(sql);
        }

        public DataTable  Procurar(int id_idoso, BaseDados bd)
        {
            string sql = "SELECT * FROM Idoso WHERE ID_Idoso=" + id_idoso;
            DataTable selec = bd.DevolveSQL(sql);

            if (selec != null && selec.Rows.Count > 0)
            {
                this.ID_Idoso = int.Parse(selec.Rows[0]["ID_Idoso"].ToString());
                this.Nome_Idoso = selec.Rows[0]["Nome_Idoso"].ToString();
                this.NIF_Idoso = selec.Rows[0]["Nif_Idoso"].ToString();
                this.NUtenteSaude = selec.Rows[0]["nutentesaude"].ToString();
                this.Doencas = selec.Rows[0]["Doencas"].ToString();
                this.Data_Nasc = DateTime.Parse(selec.Rows[0]["data_nasc"].ToString());
                this.Idade = selec.Rows[0]["idade"].ToString();

            }

            return selec;
        }

        internal void Atualizar(BaseDados bd)
        {

            string sql = @"UPDATE Idoso SET nome_idoso = @nome_idoso, nif_idoso = @nif_idoso, 
                            nutentesaude = @nutentesaude,
                            doencas = @doencas, idade=@idade WHERE Id_Idoso = @id_idoso";
                          

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome_idoso",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@nif_idoso",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF_Idoso
                },
                new SqlParameter()
                {
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Nasc
                },
                new SqlParameter()
                {
                    ParameterName="@nutentesaude",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NUtenteSaude
                },
                new SqlParameter()
                {
                    ParameterName="@doencas",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Doencas
                },
                new SqlParameter()
                {
                    ParameterName="@idade",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Idade
                },
                new SqlParameter()
                {
                    ParameterName="@id_idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },


            };
            bd.ExecutaSQL(sql, parametros);


        }
        public static DataTable PesquisaIdoso(BaseDados bd, string nome_idoso)
        {
            string sql = @"SELECT * FROM Idoso WHERE Nome_Idoso Like @nome_idoso";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome_idoso",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome_idoso+"%"
                },

            };
            return bd.DevolveSQL(sql, parametros);

        }

        public override string ToString()
        {
            return this.Nome_Idoso;
        }

        public static void ApagarIdoso(BaseDados bd, int id_idoso_escolhido)
        {
            string sql = "DELETE FROM Idoso WHERE ID_Idoso=" + id_idoso_escolhido;
            bd.ExecutaSQL(sql);
        }

        public static DataTable ListarIdosos(BaseDados bd)
        {
            string sql = "SELECT * FROM Idoso";
            return bd.DevolveSQL(sql);
        }

        public static DataTable ListarIDs(BaseDados bd, int id_idoso_escolhido)
        {
            string sql = "SELECT * FROM Idoso WHERE id_idoso =" + id_idoso_escolhido;
            return bd.DevolveSQL(sql);
        }







        //Limpar combo box clear
    }
}
