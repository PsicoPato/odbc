using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace OdbcCap2
{
    class CriaBaseDeDadosLivraria
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                conexao.Open();
                string sql = @"IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'livraria') DROP DATABASE livraria";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();

                sql = @"CREATE DATABASE livraria";
                command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();
            }
        }
    }
}
