using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3.Domain;
using TP3.Models;
using TP3.Repository;

namespace TP3.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            var repository = new LivroRepository();

            var livros = repository.GetAllLivros();

            return View(
                livros.Select(l => new LivroViewModel()
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Editora = l.Editora,
                    Ano = l.Ano
                }
                ));
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            var repository = new LivroRepository();

            var livro = repository.DetailLivro(id);

            var livroViewModel = new LivroViewModel {
                Id = livro.Id,
                Ano = livro.Ano,
                Autor = livro.Autor,
                Editora = livro.Editora,
                Titulo = livro.Titulo
            };

            return View(livroViewModel);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var repository = new LivroRepository();

                repository.CreateLivro(new Domain.Livro()
                {
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano

                });

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int id)
        {

            var repository = new LivroRepository();

            var livro = repository.DetailLivro(id);

            var livroViewModel = new LivroViewModel
            {
                Id = livro.Id,
                Ano = livro.Ano,
                Autor = livro.Autor,
                Editora = livro.Editora,
                Titulo = livro.Titulo
            };

            return View(livroViewModel);
                       
        }

        // POST: Livros/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var repository = new LivroRepository();

                repository.EditLivro(new Livro()
                {
                    Id= livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano

                });

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new LivroRepository();

            var livro = repository.DetailLivro(id);

            var livroViewModel = new LivroViewModel
            {
                Id = livro.Id,
                Ano = livro.Ano,
                Autor = livro.Autor,
                Editora = livro.Editora,
                Titulo = livro.Titulo
            };

            return View(livroViewModel);
        }

        // POST: Livros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var repository = new LivroRepository();

                var delete = repository.DeleteLivro(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
