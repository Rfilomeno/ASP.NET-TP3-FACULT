using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP3.Domain
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}