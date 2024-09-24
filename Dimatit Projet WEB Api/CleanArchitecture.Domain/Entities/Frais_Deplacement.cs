using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Frais_Deplacement
    {
        [Key]
        public int ID_Frais { get; set; }
        public DateTime Date_Saisie { get; set; }
        public float Frais_Kilometrique { get; set; }
        public float? FraisDeplacement { get; set; }
        public DateTime? Periode_Deplacement { get; set; }
        public string Circulation { get; set; }
        public DateTime? Date_Regelement { get; set; }
        public string Reprise_Frais { get; set; }
        public DateTime? Date_Avancement { get; set; }
        public float Montant_Avance { get; set; }
        public string Mat_PER { get; set; }
        public string Ville_Region { get; set; }
        public string Mode_Reglement { get; set; }
        public DateTime? Date_Preparation { get; set; }
        public DateTime? Periode_De { get; set; }
        public DateTime? Periode { get; set; }
        public int Personnel_id { get; set; }
    }
}
