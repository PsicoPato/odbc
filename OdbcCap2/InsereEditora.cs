using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace OdbcCap2
{
    class InsereEditora
    {
        static void Main(string[] args)
        {            
            Editora e = new Editora();

            Console.WriteLine("Digite o Nome da Editora: ");
            e.Nome = System.Console.ReadLine();

            Console.WriteLine("Digite o Email da Editora: ");
            e.Email = System.Console.ReadLine();

            string sql = @"INSERT INTO Editoras (Nome, Email) OUTPUT INSERTED.id VALUES(? , ?)";

            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                OdbcCommand command = new OdbcCommand(sql, conexao);

                command.Parameters.AddWithValue("@Nome", e.Nome);
                command.Parameters.AddWithValue("@Email", e.Email);

                conexao.Open();
                e.Id = command.ExecuteScalar() as long?;

                Console.WriteLine("Editora cadastrada com id: " + e.Id);
            }
        }
    }
}
