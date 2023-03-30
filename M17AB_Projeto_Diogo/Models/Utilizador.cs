using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17AB_Projeto_Diogo.Models
{
    public class Utilizador
    {
        public int id;
        public int ID_Idoso;
        public string nome;
        public string email;
        public string morada;
        public string nif;
        public string password;
        public int perfil;
        public int sal;
        public string RelacaoFamiliar;

        BaseDados bd;

        public Utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar
        public void Adicionar()
        {
            string sql = @"INSERT INTO utilizadores(email,nome,morada,nif,password,perfil,sal,RelacaoFamiliar,ID_Idoso)
                            VALUES (@email,@nome,@morada,@nif,HASHBYTES('SHA2_512',concat(@password,@sal)),@perfil,@sal,@RelacaoFamiliar,@ID_Idoso)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.morada
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
                new SqlParameter()
                {
                    ParameterName="@sal",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.sal
                },
                new SqlParameter()
                {
                    ParameterName="@relacaofamiliar",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.RelacaoFamiliar
                },
                new SqlParameter()
                {
                    ParameterName="@ID_Idoso",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ID_Idoso
                },

            };
            bd.executaSQL(sql, parametros);

        }

        internal DataTable ListaTodosUtilizadores()
        {
            return bd.devolveSQL("SELECT * FROM Utilizadores");
        }

        public void atualizarUtilizador()
        {
            string sql = @"UPDATE utilizadores SET nome=@nome,morada=@morada,nif=@nif,
                            RelacaoFamiliar = @RelacaoFamiliar, email = @email
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@relacaofamiliar",SqlDbType=SqlDbType.VarChar,Value=RelacaoFamiliar },
                //new SqlParameter() {ParameterName="@ID_Idoso",SqlDbType=SqlDbType.Int,Value=ID_Idoso },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosUtilizador(int id)
        {
            string sql = "SELECT * FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }
        public void removerUtilizador(int id)
        {
            string sql = "DELETE FROM Utilizadores WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            bd.executaSQL(sql, parametros);
        }
        public void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE utilizadores set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE utilizadores set password=HASHBYTES('SHA2_512',contact(@password, sal)),lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosUtilizador(string email)
        {
            string sql = "SELECT * FROM utilizadores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
    }
}