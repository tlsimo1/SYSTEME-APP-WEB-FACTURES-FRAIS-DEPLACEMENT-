using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Personnel
    {
        [Key]
        public int ID_Personnel { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Activite_Service { get; set; }
        public int Analytique_id { get; set; }
    }
}
