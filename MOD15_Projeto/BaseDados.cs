using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MOD15_Projeto
{
    public class BaseDados
    {
        string ligaBD;
        SqlConnection sqlConnection;
        string NomeBD;
        string caminhoBD;
        /*construtor*/
        public BaseDados(string NomeBD)
        {
            ligaBD = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.NomeBD = NomeBD;
            string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            caminhoBD += "\\MOD15_Projeto\\";
            this.caminhoBD = caminhoBD + NomeBD + ".mdf";
            if (System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }
            if (System.IO.File.Exists(this.caminhoBD) == false)
            {
                CriarBD();
            }

            //ligação BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(NomeBD);

        }
        /*destrutor*/
        ~BaseDados()
        {
            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch
            {
                //Pode ocorrer erros 
            }
        }
        private void CriarBD()
        {
            //ligar ao servidor BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            //criar a BD
            string sql = $"CREATE DATABASE {NomeBD} ON PRIMARY (NAME={NomeBD},FILENAME='{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(NomeBD);
            //criar as tabelas
            sql = @"
                        create table Familiar(
	                    ID_Familiar INT IDENTITY Primary Key,
	                    NIF varchar(9) unique ,
	                    Nome Varchar(100) NOT NULL  check (len(Nome)>=3),
	                    Email varchar(100) unique check (Email like '%@%.%'),
	                    Telemovel varchar(9) unique not null,
	                    Data_Nasc date,
	                    Morada varchar(150),
	                    RelacaoFamiliar varchar(100),
                    );
                       
                    create table Idoso(
	                    ID_Idoso INT IDENTITY Primary Key,
	                    NIF_Idoso varchar(9) NOT NULL unique,
	                    Nome_Idoso Varchar(100) NOT NULL check (len(Nome_Idoso)>=3),
	                    Data_Nasc date,
	                    Doencas varchar(100),
	                    NUtenteSaude Varchar(9) NOT NULL unique,
                        Idade int,
	                        
                    );
                    create table Visitas(
                        ID_Visita INT IDENTITY Primary Key,
	                    ID_Idoso int references Idoso(ID_Idoso),
	                    ID_Familiar int references Familiar(ID_Familiar),
	                    DataVisita date,
                    );
                    create table Medicamentos(
                        ID_Medicamento INT IDENTITY Primary Key,
                        Fotografia varbinary(max),
                        Nome varchar(100),
                        Contra varchar(500),
                    );      
                    create table IdosoMedica(
                        ID_IdosoMedica INT IDENTITY Primary Key,
                        ID_Idoso int references Idoso(ID_Idoso),
                        ID_Medicamento int references Medicamentos(ID_Medicamento),
                        Dose varchar(2),
    
                    );
                    ";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sql = @" Create Trigger CalcularIdade 
                        ON Idoso
                        AFTER INSERT AS 
                        BEGIN
 
	                        Declare @data_nasc date;
	                        Declare @idade int;
	                        Declare @id_idoso int;
	                        select @id_idoso = INSERTED.ID_Idoso FROM INSERTED;
	                        SELECT @data_nasc = INSERTED.Data_Nasc from INSERTED;
	                        set @idade = datediff(year,@data_nasc, getdate()); 
	                        UPDATE Idoso
	                        set idade=@idade
	                        where Idoso.ID_Idoso = @id_idoso
                        END	";

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //fechar a ligação ao servidor BD
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
            
        }
        /// <summary>
        /// Vai executar um SQL que altera os dados (p.e:insert, delete ou update)
        /// </summary>
        public void ExecutaSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            comando.ExecuteNonQuery(); 
            comando.Dispose();
            comando = null;
        }
        /// <summary>
        /// Executa uma consulta e devolve os dados da bd
        /// </summary>
        /// <returns>Um datatable com o resultado da consulta</returns>
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            //TODO: adicionar transações
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            DataTable dados = new DataTable();

            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);

            registos.Close();
            comando.Dispose();
            registos = null;
            comando = null;

            return dados;
        }

    }
}

