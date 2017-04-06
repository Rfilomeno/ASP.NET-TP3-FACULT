using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3.Repository;
using TP3.Domain;
using TP3.Controllers;
using TP3.Models;
using System.Linq;
using Moq;
using System.Web.Mvc;

namespace TP3.Tests
{
    /// <summary>
    /// Summary description for LivrosControllerTests
    /// </summary>
    [TestClass]
    public class LivrosControllerTests
    {
        [TestMethod]
        public void LivrosCreateTests()
        {
            // Arrange
            var mockRepository = new Mock<ILivroRepository>();

            var livro = new LivroViewModel() { Id = 1, Autor = "Teste", Editora = "Teste", Ano = 2017, Titulo="Teste", Disponivel = true };
            var controller = new LivrosController(mockRepository.Object);

            // Act
            var resultado = controller.Create(livro);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(RedirectToRouteResult));

            var resultadoDaView = resultado as RedirectToRouteResult;
            var modelo = resultadoDaView.RouteValues.Values.First();
            Assert.IsTrue(modelo.Equals("Index"));
        }

        [TestMethod]
        public void LivrosEditTests()
        {
            // Arrange
            var mockRepository = new Mock<ILivroRepository>();

            var livro = new Livro() { Id = 1, Autor = "Teste", Editora = "Teste", Ano = 2017, Titulo = "Teste", Disponivel = true };
            var controller = new LivrosController(mockRepository.Object);

            // Act
            var resultado = controller.Edit(livro);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(RedirectToRouteResult));

            var resultadoDaView = resultado as RedirectToRouteResult;
            var modelo = resultadoDaView.RouteValues.Values.First();
            Assert.IsTrue(modelo.Equals("Index"));
        }

        
                   
    }
}
