using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MOD15_Projeto.Familiares
{
    public class Familiar
    {
        public int ID_Familiar { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string Morada { get; set; }
        public string RelacaoFamiliar { get; set; }
        public string Telemovel   { get; set; }     
        public Familiar() { }

        public Familiar(int id_Familiar, string nome, string nif, string email, DateTime data_Nasc, string morada, string relacaoFamiliar, string telemovel)
        {
            ID_Familiar = id_Familiar;
            Nome = nome;
            NIF = nif;
            Email = email;
            Data_Nasc = data_Nasc;
            Morada = morada;
            RelacaoFamiliar = relacaoFamiliar;
            Telemovel = telemovel;  
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO Familiar(nif,nome,email,telemovel,data_nasc,morada,relacaofamiliar)
                           VALUES 
                           (@nif,@nome,@email,@telemovel,@data_nasc,@morada,@relacaofamiliar)";

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
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF
                },
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Email
                },
                new SqlParameter()
                {
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Nasc
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Morada
                },
                new SqlParameter()
                {
                    ParameterName="@relacaofamiliar",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.RelacaoFamiliar
                },
                new SqlParameter()
                {
                    ParameterName="@telemovel",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Telemovel
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM Familiar";
            return bd.DevolveSQL(sql);
        }

        public static void ApagarFamiliar(BaseDados bd ,int id_familiar_escolhido)
        {
            string sql = "DELETE FROM Familiar WHERE ID_Familiar=" + id_familiar_escolhido;
            bd.ExecutaSQL(sql);
        }

        public  DataTable Procurar(int id_familiar, BaseDados bd)
        {
            string sql = "SELECT * FROM Familiar WHERE ID_Familiar=" + id_familiar;
            DataTable selec = bd.DevolveSQL(sql);

            if (selec != null && selec.Rows.Count > 0)
            {
                this.ID_Familiar = int.Parse(selec.Rows[0]["ID_Familiar"].ToString());
                this.Nome = selec.Rows[0]["nome"].ToString();
                this.NIF = selec.Rows[0]["nif"].ToString();
                this.Email = selec.Rows[0]["email"].ToString();
                this.Telemovel = selec.Rows[0]["telemovel"].ToString();
                this.RelacaoFamiliar = selec.Rows[0]["RelacaoFamiliar"].ToString();
                this.Morada = selec.Rows[0]["Morada"].ToString();
                this.Data_Nasc = DateTime.Parse(selec.Rows[0]["data_nasc"].ToString());
                
            }

            return selec;
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE Familiar SET nome=@nome,data_nasc=@data_nasc,nif = @nif, 
                           morada = @morada, email = @email, telemovel = @telemovel, 
                           RelacaoFamiliar = @RelacaoFamiliar ";
            sql += " WHERE ID_Familiar= @ID_Familiar";

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
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NIF
                },
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Email
                },
                new SqlParameter()
                {
                    ParameterName="@data_nasc",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_Nasc
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Morada
                },
                new SqlParameter()
                {
                    ParameterName="@relacaofamiliar",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.RelacaoFamiliar
                },
                new SqlParameter()
                {
                    ParameterName="@telemovel",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Telemovel
                },
                new SqlParameter()
                {
                    ParameterName="@id_familiar",
                    SqlDbType=SqlDbType.Int,
                    Value=this.ID_Familiar
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }
        public static DataTable ListarFamiliar(BaseDados bd)
        {
            string sql = "SELECT * FROM Familiar";
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
