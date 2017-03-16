using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP3.Domain;

namespace TP3.Repository
{
    public class LivroRepository
    {
        public IEnumerable<Livro> GetAllLivros()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\ASPNET\TP3\TP3\App_Data\Livros.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Livro";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;
                var livros = new List<Livro>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Titulo = reader["Titulo"].ToString();
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();
                            livro.Ano = (int)reader["Ano"];


                            livros.Add(livro);
                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return livros;
            }
        }

        internal void CreateLivro(Livro livro)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\ASPNET\TP3\TP3\App_Data\Livros.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Livro (Titulo, Autor, Editora, Ano) VALUES (@Titulo, @Autor, @Editora, @Ano)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Titulo", livro.Titulo);
                insertCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.Editora);
                insertCommand.Parameters.AddWithValue("@Ano", livro.Ano);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {

                    connection.Close();
                }
            }
        }

        public Livro DetailLivro(int id)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\ASPNET\TP3\TP3\App_Data\Livros.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"SELECT * FROM Livro WHERE Id = {id}";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livroPesquisado = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livroPesquisado = new Livro();
                            livroPesquisado.Id = (int)reader["Id"];
                            livroPesquisado.Titulo = reader["Titulo"].ToString();
                            livroPesquisado.Autor = reader["Autor"].ToString();
                            livroPesquisado.Editora = reader["Editora"].ToString();
                            livroPesquisado.Ano = (int)reader["Ano"];


                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return livroPesquisado;
            }

        }

        public bool DeleteLivro(int id)
        {
            int rows = 0;
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\ASPNET\TP3\TP3\App_Data\Livros.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"DELETE FROM Livro WHERE Id = {id}";
                var selectCommand = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    rows = selectCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
                return rows > 0;
            }

        }

        internal void EditLivro(Livro livro)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\ASPNET\TP3\TP3\App_Data\Livros.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"UPDATE Livro SET Titulo = '{ livro.Titulo }', Autor = '{ livro.Autor }', Editora = '{ livro.Editora }', Ano = { livro.Ano } WHERE Id = { livro.Id }";
                var insertCommand = new SqlCommand(commandText, connection);
                
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {

                    connection.Close();
                }
            }
        }

    }
}