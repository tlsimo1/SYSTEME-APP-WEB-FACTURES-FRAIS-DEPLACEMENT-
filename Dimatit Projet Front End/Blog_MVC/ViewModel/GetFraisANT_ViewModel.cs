namespace Blog_MVC.ViewModel
{
    public class GetFraisANT_ViewModel
    {
        public string Circulation { get; set; }
        public string Nom { get; set; }
        public string Matricule { get; set; }
        public string CodeAnalytique { get; set; }

        public Double Total_frais_Deplacement { get; set; }
        public Double Total_frais_KM { get; set; }
        public Double Total_frais_AV { get; set; }

        public DateTime Date_Saisie { get; set; }
    }
}
