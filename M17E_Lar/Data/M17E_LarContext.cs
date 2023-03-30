using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M17E_Lar.Data
{
    public class M17E_LarContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public M17E_LarContext() : base("name=M17E_LarContext")
        {
        }

        public System.Data.Entity.DbSet<M17E_Lar.Models.Utilizador> Utilizadors { get; set; }

        public System.Data.Entity.DbSet<M17E_Lar.Models.Familiar> Familiars { get; set; }

        public System.Data.Entity.DbSet<M17E_Lar.Models.Idoso> Idosoes { get; set; }

        public System.Data.Entity.DbSet<M17E_Lar.Models.Visita> Visitas { get; set; }

        public System.Data.Entity.DbSet<M17E_Lar.Models.Medicamento> Medicamentoes { get; set; }

        public System.Data.Entity.DbSet<M17E_Lar.Models.MedicaIdoso> MedicaIdosoes { get; set; }
    }
}
