using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M17E_Lar.Models
{
    public class Familiar
    {
        [Key]
        public int FamiliarID { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nome do Familiar")]
        [StringLength(100)]
        [MinLength(2, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do cliente, deve ter pelo menos 3 letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tem de indicar a morada do familiar")]
        [StringLength(100)]
        [MinLength(4, ErrorMessage = "A Morada é  muito pequeno. Tem de ter pelo menos 4 letras")]
        [UIHint("Insira a morada do cliente, deve ter pelo menos 4 letras")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Tem de indicar um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Tem de indicar o telefone do familiar")]
        [StringLength(9)]
        [MinLength(9, ErrorMessage = "O Telemóvel tem de ter 9 números")]
        [UIHint("Insira o Nº de telefone do familiar")]
        public string Telefone { get; set; }

        //[Required(ErrorMessage = "Indique uma password")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
            
        //public int Perfil = 2;

        public virtual List<Visita> listaVisitas { get; set; }

    }
}