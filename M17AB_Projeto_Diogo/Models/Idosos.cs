using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17AB_Projeto_Diogo.Models
{
    public class Idosos
    {
        public int ID_Idoso;
        public string Nome_Idoso;
        public string NIF_Idoso;
        public DateTime Data_Nasc;
        public string Doencas;
        public string NUtenteSaude;
        public int estado;

        BaseDados bd;

        public Idosos()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = @"INSERT INTO Idosos(nome_idoso,data_nasc,nif_idoso,doencas,nutentesaude,estado)
                    VALUES (@nome_idoso,@data_nasc,@nif_idoso,@doencas,@nutentesaude,@estado);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
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
                    ParameterName="@NIF_Idoso",
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
                    ParameterName="@doencas",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Doencas
                },
                new SqlParameter()
                {
                    ParameterName="@nutentesaude",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.NUtenteSaude
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.estado
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosIdosos()
        {
            string sql = @"SELECT ID_Idoso,nome_idoso,data_nasc,
                    doencas, nutentesaude,nif_idoso,
                    case
                        when estado=0 then 'Em Curso'
                        when estado=1 then 'Disponível'
                        when estado=2 then 'Reservado'
                    end as estado
                    FROM Idosos";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosIdoso(int id_idoso)
        {
            string sql = "SELECT * FROM Idosos WHERE ID_Idoso=@ID_Idoso";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ID_Idoso",SqlDbType=SqlDbType.Int,Value=id_idoso }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public void removerIdoso(int id_idoso)
        {
            string sql = "DELETE FROM Idosos WHERE id_idoso=@id_idoso";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_idoso",SqlDbType=SqlDbType.Int,Value=id_idoso }
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizaIdoso()
        {
            string sql = "UPDATE Idosos SET Nome_Idoso=@Nome_Idoso,data_nasc=@data_nasc,doencas=@doencas,nif_idoso=@nif_idoso, nutentesaude=@nutentesaude";
            sql += " WHERE id_idoso=@id_idoso;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@Nome_Idoso",SqlDbType=SqlDbType.VarChar,Value= Nome_Idoso},
                new SqlParameter() {ParameterName="@doencas",SqlDbType=SqlDbType.VarChar,Value= Doencas},
                new SqlParameter() {ParameterName="@data_nasc",SqlDbType=SqlDbType.DateTime,Value= Data_Nasc},
                new SqlParameter() {ParameterName="@nif_idoso",SqlDbType=SqlDbType.VarChar,Value= NIF_Idoso},
                new SqlParameter() {ParameterName="@nutentesaude",SqlDbType=SqlDbType.VarChar,Value=NUtenteSaude},
                new SqlParameter() {ParameterName="@ID_Idoso",SqlDbType=SqlDbType.Int,Value=ID_Idoso}
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable listaIdososDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM Idosos WHERE estado=1";
            if (ordena != null && ordena == 1)
            {
                sql += " order by Nome_Idoso";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by data_nasc";
            }
            return bd.devolveSQL(sql);
        }


        internal DataTable listaIdososDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM Idosos WHERE estado=1 and Nome_Idoso like @Nome_Idoso";
            if (ordena != null && ordena == 1)
            {
                sql += " order by Nome_Idoso";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by data_nasc";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@Nome_Idoso",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }

    }
}