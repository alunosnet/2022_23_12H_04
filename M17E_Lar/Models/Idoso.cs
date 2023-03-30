using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M17E_Lar.Models
{
    public class Idoso
    {
        [Key]
        public int ID_Idoso { get; set; }

        [Required(ErrorMessage = "Tem de Indicar o nome do idoso")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do idoso, deve ter pelo menos 3 letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tem de indicar a data de nascimento do idoso")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Nasc { get; set; }

        [StringLength(400)]
        [MinLength(4, ErrorMessage = "Tamanho de caractéres inválido. Tem de ter pelo menos 4.")]
        [UIHint("Insira a uma doença caso tenha")]
        public string Doenças { get; set; }

        [Required(ErrorMessage = "Tem de indicar o Nº de Utente de Saúde do idoso")]
        [StringLength(9)]
        [MinLength(9, ErrorMessage = "O Nº de Utente de Saúde tem de ter 9 números")]
        [UIHint("Insira o Nº de Utente de Saude do Idoso")]
        public string NUtenteSaude { get; set; }

        public bool Estado { get; set; }

        [NotMapped]
        public int Idade
        {
            get
            {
                DateTime data = DateTime.Today;
                int idade = data.Year - Data_Nasc.Year;

                if (Data_Nasc > data.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
        }

        public Idoso()
        {
            Estado = true;
        }
    }
}