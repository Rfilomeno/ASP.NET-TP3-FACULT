using System;
using System.Text;
using System.Collections.Generic;
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
        public LivrosControllerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IndexTestMethod()
        {
            //Arrange
            var mockRepository = new Mock<ILivroRepository>();

            mockRepository.Setup(repository => repository.GetAllLivros()).Returns(new List<Livro>
            {
                new Livro() { Id = 1,
                    Titulo = "Teste",
                    Autor = "Teste",
                    Editora = "Teste",
                    Ano = 2001
                },
                new Livro()
                {
                    Id = 2,
                    Titulo = "Teste2",
                    Autor = "Teste2",
                    Editora = "Teste2",
                    Ano = 2002
                }
                });                ;
            var controller = new LivrosController(mockRepository.Object);
            

         //Act

            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<LivroViewModel>));

            var livros = model as IEnumerable<LivroViewModel>;
            Assert.AreEqual(3, livros.Count());
        }   
    }
}
