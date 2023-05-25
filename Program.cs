using System;
using Microsoft.Data.SqlClient;
namespace AcessandoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=localhost\SQLEXPRESS;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {

            }

            Console.WriteLine("Conexão completa");
        }
    }
}