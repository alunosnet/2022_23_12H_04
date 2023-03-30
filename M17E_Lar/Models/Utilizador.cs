using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace M17E_Lar.Models
{
    public class Utilizador
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Indique um nome de utilizador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Indique uma password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Indique o perfil do utilizador")]
        public int Perfil { get; set; }
        //DropDown Perfil


        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }

    }
}