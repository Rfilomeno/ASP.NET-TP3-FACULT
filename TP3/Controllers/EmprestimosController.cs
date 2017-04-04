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
    public class EmprestimosController : Controller
    {
        
        // GET: Emprestimos
        public ActionResult Index()
        {
            var repository = new EmprestimoRepository();

            var emprestimos = repository.GetAllEmprestimos();

            return View(
                emprestimos.Select(e => new EmprestimoViewModel()
                {
                    Id = e.Id,
                    LivroId = e.LivroId,
                    Titulo = e.Titulo,
                    DataEmprestimo = e.DataEmprestimo,
                    DataDevolucao = e.DataDevolucao
                    
                }
                ));
        }

        // GET: Emprestimos/Details/5
        public ActionResult Details(int id)
        {
            var repository = new EmprestimoRepository();

            var emprestimo = repository.DetailEmprestimo(id);

            var emprestimoViewModel = new EmprestimoViewModel
            {
                Id = emprestimo.Id,
                LivroId = emprestimo.LivroId,
                Titulo = emprestimo.Titulo,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucao = emprestimo.DataDevolucao
                
            };

            return View(emprestimoViewModel);
        }

        // GET: Emprestimos/Create
        public ActionResult Create(int id)
        {
            var repository = new LivroRepository();

            var emprestimo = repository.DetailLivro(id);
            var emprestimoViewModel = new EmprestimoViewModel
            {
                LivroId = emprestimo.Id,
                Titulo = emprestimo.Titulo,
                DataEmprestimo = DateTime.Today,
                DataDevolucao = DateTime.Today.AddDays(10)
            };

            return View(emprestimoViewModel);
        }
        

        // POST: Emprestimos/Create
        [HttpPost]
        public ActionResult Create(Emprestimo emprestimo)
        {
           
                var repository = new EmprestimoRepository();

                repository.CreateEmprestimo(new Emprestimo()
                {
                    LivroId = emprestimo.LivroId,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao
                    
                });

                return RedirectToAction("Index");
            
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new EmprestimoRepository();

            var emprestimo = repository.DetailEmprestimo(id);
            var emprestimoViewModel = new EmprestimoViewModel
            {
                Id = emprestimo.Id,
                LivroId = emprestimo.LivroId,
                Titulo = emprestimo.Titulo,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucao = emprestimo.DataDevolucao

            };

            return View(emprestimoViewModel);
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        public ActionResult Edit(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                var repository = new EmprestimoRepository();

                repository.EditEmprestimo(new Emprestimo()
                {
                    Id = emprestimo.Id,
                    LivroId = emprestimo.LivroId,
                    Titulo = emprestimo.Titulo,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao

                });

                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new EmprestimoRepository();

            var emprestimo = repository.DetailEmprestimo(id);

            var emprestimoViewModel = new EmprestimoViewModel()
            {
                Id = emprestimo.Id,
                LivroId = emprestimo.LivroId,
                Titulo = emprestimo.Titulo,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucao = emprestimo.DataDevolucao

            };

            return View(emprestimoViewModel);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var repository = new EmprestimoRepository();
            var emprestimo = repository.DetailEmprestimo(id);


            try
            {
                var delete = repository.DeleteEmprestimo(id, emprestimo.LivroId);

                return RedirectToAction("Index", "Livros");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
