using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M17E_Lar.Models
{
    public class Medicamento
    {
        [Key]
        public int ID_Medicamento { get; set; }

        [Required(ErrorMessage = "Tem de Indicar o nome do medicamento")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do medicamento, deve ter pelo menos 3 letras")]
        public string Nome { get; set; }

        [Display(Name = "Contra Indicações")]
        [StringLength(400)]
        [MinLength(4, ErrorMessage = "Tamanho de caractéres inválido. Tem de ter pelo menos 4.")]
        [UIHint("Insira a uma contra indicação caso tenha")]
        public string Contra { get; set; }


        [Display(Name = "Tipo de toma")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "Tamanho de caractéres inválido. Tem de ter pelo menos 2.")]
        [UIHint("Insira a maneira de utilização")]
        public string Forma { get; set; }

    }
}