using System;
using BaltaDataAcess.Models;
using Dapper;
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
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM Category");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Title}");
                }
            }

            Console.WriteLine("Conexão completa");
        }
    }
}