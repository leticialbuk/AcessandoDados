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
                //CreateManyCategory(connection);
                //UpdateCategory(connection);
                //ListCategories(connection);
                ExecuteProcedure(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM Category");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;

            var insertSql = $@"INSERT INTO 
                    [Category]      
                VALUES(
                    @Id,
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend"
            });

            Console.WriteLine($"{rows} Registros atualizados!");
        }
        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Nova categoria";
            category2.Url = "categoria-nova";
            category2.Summary = "Nova categoria";
            category2.Order = 9;
            category2.Description = "Categoria";
            category2.Featured = true;

            var insertSql = $@"INSERT INTO 
                    [Category]      
                VALUES(
                    @Id,
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new[]{
                new
                {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
                },

                new
                {
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured
                }
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }
        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";
            var pars = new { StudentId = "f525e728-99b8-4e57-9f59-9a086d22b881" };
            var affectedRows = connection.Execute(
                procedure,
                pars,
                commandType: System.Data.CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linhas afetadas");
        }
    }
}