using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP3.Domain;

namespace TP3.Repository
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> GetAllEmprestimos();
        void CreateEmprestimo(Emprestimo emprestimo);
        Emprestimo DetailEmprestimo(int id);
        bool DeleteEmprestimo(int id, int livroId);
        

    }
    public class EmprestimoRepository : IEmprestimoRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Assessment - ASP.NET - Rodrigo\TP3\App_Data\Livros.mdf;Integrated Security=True";

        //feito
        public IEnumerable<Emprestimo> GetAllEmprestimos()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Emprestimos INNER JOIN Livro ON Emprestimos.LivroID=Livro.Id";

                var selectCommand = new SqlCommand(commandText, connection);

                Emprestimo emprestimo = null;
                var emprestimos = new List<Emprestimo>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emprestimo = new Emprestimo();
                            emprestimo.Id = (int)reader["Id"];
                            emprestimo.LivroId = (int)reader["LivroId"];
                            emprestimo.Titulo = reader["Titulo"].ToString();
                            emprestimo.DataEmprestimo = Convert.ToDateTime(reader["DataEmprestimo"]);
                            emprestimo.DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]);

                            emprestimos.Add(emprestimo);
                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return emprestimos;
            }
        }

        //por fazer create
        public void CreateEmprestimo(Emprestimo emprestimo)
        {


            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Emprestimos (LivroId, DataEmprestimo, DataDevolucao) VALUES (@LivroId, @DataEmprestimo, @DataDevolucao)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@LivroId", emprestimo.LivroId);
                insertCommand.Parameters.AddWithValue("@DataEmprestimo", emprestimo.DataEmprestimo);
                insertCommand.Parameters.AddWithValue("@DataDevolucao", emprestimo.DataDevolucao);

                var commandText2 = $"UPDATE Livro SET Disponivel = '0' WHERE Id = { emprestimo.LivroId }";
                var insertCommand2 = new SqlCommand(commandText2, connection);


                try
                {
                    connection.Open();
                    insertCommand2.ExecuteNonQuery();
                    insertCommand.ExecuteNonQuery();

                }
                finally
                {

                    connection.Close();
                }
            }
        }

        //feito
        public Emprestimo DetailEmprestimo(int id)
        {


            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = $"SELECT * FROM Emprestimos INNER JOIN Livro ON Emprestimos.LivroID=Livro.Id WHERE Emprestimos.Id = {id}";
                var selectCommand = new SqlCommand(commandText, connection);

                Emprestimo EmpPesquisado = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            EmpPesquisado = new Emprestimo();
                            EmpPesquisado.Id = (int)reader["Id"];
                            EmpPesquisado.LivroId = (int)reader["LivroId"];
                            EmpPesquisado.Titulo = reader["Titulo"].ToString();
                            EmpPesquisado.DataEmprestimo = Convert.ToDateTime(reader["DataEmprestimo"]);
                            EmpPesquisado.DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]);



                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return EmpPesquisado;
            }

        }

        //feito delete
        public bool DeleteEmprestimo(int id, int livroId)
        {
            int rows = 0;


            using (var connection = new SqlConnection(connectionString))
            {


                var commandText2 = $"UPDATE Livro SET Disponivel = '1' WHERE Id = { livroId }";
                var insertCommand = new SqlCommand(commandText2, connection);
                var commandText = $"DELETE FROM Emprestimos WHERE Id = {id}";
                var selectCommand = new SqlCommand(commandText, connection);


                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    rows = selectCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
                return rows > 0;

            }

        }

        //Feito
        public void EditEmprestimo(Emprestimo emprestimo)
        {


            using (var connection = new SqlConnection(connectionString))
            {

                var livroAntigo = DetailEmprestimo(emprestimo.Id);

                if (emprestimo.LivroId != livroAntigo.LivroId)
                {
                    var commandText2 = $"UPDATE Livro SET Disponivel = '1' WHERE Id = { livroAntigo.LivroId }";
                    var commandText3 = $"UPDATE Livro SET Disponivel = '0' WHERE Id = { emprestimo.LivroId }";
                    var insertCommand2 = new SqlCommand(commandText2, connection);
                    var insertCommand3 = new SqlCommand(commandText3, connection);

                    try
                    {
                        connection.Open();
                        insertCommand2.ExecuteNonQuery();
                        insertCommand3.ExecuteNonQuery();
                    }
                    finally
                    {

                        connection.Close();
                    }

                }

                var commandText = $"UPDATE Emprestimos SET LivroId = '{ emprestimo.LivroId }', DataEmprestimo = '{ emprestimo.DataEmprestimo }', DataDevolucao = '{ emprestimo.DataDevolucao }' WHERE Id = { emprestimo.Id }";
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