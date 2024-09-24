using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Facture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_facture { get; set; }
        public string NumFacture { get; set; }
        public string Fournisseur { get; set; }
        public DateTime Date_Facture { get; set; }
        public DateTime Date_Saisie { get; set; }
        public double TotalTTC { get; set; }
        //public ICollection<Achat> Achats { get; set; }
        //public ICollection<Comptabilite> Comptabilite { get; set; }
        //public ICollection<Assistate_DAF> Assistate_DAF { get; set; }
        //public ICollection<Bureau_Ordre> Bureau_Ordre { get; set; }
        //public ICollection<Chef_Comptabilite> Chef_Comptabilite { get; set; }
    }
}
