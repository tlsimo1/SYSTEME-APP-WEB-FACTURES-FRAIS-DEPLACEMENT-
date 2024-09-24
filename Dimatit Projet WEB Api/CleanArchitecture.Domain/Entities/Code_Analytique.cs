using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Code_Analytique
    {
        [Key]
        public int ID_Analytique { get; set; }
        public string Activite_Service { get; set; }
        public string CodeAnalytique { get; set; }
    }
}
