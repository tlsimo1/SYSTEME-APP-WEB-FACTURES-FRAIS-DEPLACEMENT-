using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Assistate_DAF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Fac_Num { get; set; }
        public DateTime Date_Saisie { get; set; }
        public int Statut {get; set;}
        [ForeignKey("Facture")]
        public int id_facture { get; set; }
        public Facture Facture { get; set; }
    }
}
