using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace M17E_Lar.Models
{
    public class MedicaIdoso
    {
        [Key]
        public int ID_MedicaIdoso { get; set; }

        [ForeignKey("medicamento")]
        [Display(Name = "Medicamento")]
        [Required(ErrorMessage = "Tem de indicar um Idoso")]
        public int ID_Medicamento { get; set; }
        public Medicamento medicamento { get; set; }

        [ForeignKey("idoso")]
        [Display(Name = "Idoso")]
        [Required(ErrorMessage = "Tem de indicar um Idoso")]
        public int ID_Idoso { get; set; }
        public Idoso idoso { get; set; }

        [Display(Name = "Início")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data de entrada")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_inicio { get; set; }

        [Display(Name = "Término")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_fim { get; set; }
         
        [Display(Name = "X/por dia")]
        [Required(ErrorMessage = "Tem de Indicar o número de vezes ao dia")]
        [StringLength(2)]
        [UIHint("Insira a quantidade de vezes ao dia")]
        public string Dose { get; set; }

        [Display(Name = "Observações")]
        public string Obs { get; set; }

        [NotMapped]
        public int diasfaltam
        {
            get
            {
             
        
                    TimeSpan diferenca = data_fim - data_inicio;
                    return (int)diferenca.TotalDays;
                
            }
        }

    }
}