namespace Blog_MVC.ViewModel
{
    public class Get_FraisProvViewModel
    {
        public string Nom { get; set; }
        public string Matricule { get; set; }
        public string CodeAnalytique { get; set; }

        public Double TotalFR { get; set; }
        public Double TotalKM { get; set; }
        public Double TotalAV { get; set; }

        public DateTime DateSaisie { get; set; }
        public DateTime DateReglement { get; set; }
    }
}
