using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace OdbcCap2
{
    class ListaEditoras
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Editoras";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                conexao.Open();
                OdbcDataReader resultado = command.ExecuteReader();

                List<Editora> lista = new List<Editora>();

                while(resultado.Read())
                {
                    Editora e = new Editora();
                    e.Id = resultado["Id"] as long?;
                    e.Nome = resultado["Nome"] as string;
                    e.Email = resultado["Email"] as string;

                    lista.Add(e);
                }

                foreach(Editora e in lista)
                {
                    Console.WriteLine("{0} : {1} - {2}\n", e.Id, e.Nome, e.Email);
                }
            }
        }
    }
}
