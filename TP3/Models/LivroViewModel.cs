using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP3.Models
{
    public class LivroViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
       // [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50)]
      //  [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Autor { get; set; }

        [Required]
        [StringLength(50)]
      //  [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Editora { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public bool Disponivel { get; set; }
    }
}