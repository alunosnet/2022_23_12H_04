using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M17E_Lar.Models
{
    public class Visita
    {
        [Key]
        public int ID_Visita { get; set; }

        [ForeignKey("familiar")]
        [Display(Name = "Familiar")]
        [Required(ErrorMessage = "Tem de indicar o Familiar")]
        public int ID { get; set; }
        public Familiar familiar { get; set; }

        [ForeignKey("idoso")]
        [Display(Name = "Idoso")]
        [Required(ErrorMessage = "Tem de indicar um Idoso")]
        public int ID_Idoso { get; set; }
        public Idoso idoso { get; set; }

        [Required(ErrorMessage = "Tem de indicar a data para a qual deseja marcar a visita")]
        [Display(Name = "Data da Visita")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVisita { get; set; }

        [Required(ErrorMessage = "Tem de indicar a Relação Familiar")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "Relação Familiar muito pequeno. Tem de ter pelo menos 2 letras")]
        [UIHint("Insira a Relação Familiar, deve ter pelo menos 2 letras")]
        public string RelacaoFamiliar { get; set; }
    }
}