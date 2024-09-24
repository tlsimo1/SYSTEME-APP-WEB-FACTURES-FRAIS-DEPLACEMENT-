using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Blog_MVC.ViewModel
{
    public class Get_Frais_avancementViewModel
    {
      
        public Get_Frais_avancementViewModel()
        {
        }
        public string Circulation { get; set; }
        public string Nom { get; set; }
        public string Matricule { get; set; }
        public string DateAvance { get; set; }
        public string VilleRegion { get; set; }
        public Double Total { get; set; }
    }
}
