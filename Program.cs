using System;
using Microsoft.Data.SqlClient;
namespace AcessandoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=base;User Id=sa;";

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
            }

            Console.WriteLine("Hello World!");
        }
    }
}