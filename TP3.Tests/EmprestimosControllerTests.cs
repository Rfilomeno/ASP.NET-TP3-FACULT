using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3.Repository;
using TP3.Domain;
using TP3.Controllers;
using System.Linq;
using Moq;
using System.Web.Mvc;
using System;

namespace TP3.Tests
{
    [TestClass]
    public class EmprestimosControllerTests
    {
        [TestMethod]
        public void EmprestimosCreateTests()
        {
            // Arrange
            var mockRepository = new Mock<IEmprestimoRepository>();

            var emprestimo = new Emprestimo() { Id = 1, LivroId = 1, Titulo = "Teste", DataEmprestimo = DateTime.Now, DataDevolucao = DateTime.Now };
            var controller = new EmprestimosController(mockRepository.Object);

            // Act
            var resultado = controller.Create(emprestimo);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(RedirectToRouteResult));

            var resultadoDaView = resultado as RedirectToRouteResult;
            var modelo = resultadoDaView.RouteValues.Values.First();
            Assert.IsTrue(modelo.Equals("Index"));
        }

        [TestMethod]
        public void EmprestimosEditTests()
        {
            // Arrange
            var mockRepository = new Mock<IEmprestimoRepository>();

            var emprestimo = new Emprestimo() { Id = 1, LivroId = 1, Titulo = "Teste", DataEmprestimo = DateTime.Now, DataDevolucao = DateTime.Now };
            var controller = new EmprestimosController(mockRepository.Object);

            // Act
            var resultado = controller.Edit(emprestimo);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(RedirectToRouteResult));

            var resultadoDaView = resultado as RedirectToRouteResult;
            var modelo = resultadoDaView.RouteValues.Values.First();
            Assert.IsTrue(modelo.Equals("Index"));
        }
    }
}
