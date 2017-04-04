using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP3.Models
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }
        [Required]
        public int LivroId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDevolucao { get; set; }
    }
}