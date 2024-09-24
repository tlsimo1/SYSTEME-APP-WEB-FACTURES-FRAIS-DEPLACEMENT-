namespace Blog_MVC.ViewModel
{
    public class GetFactureViewModel
    {
        public int iD_facture { get; set; }
        public string numFacture { get; set; }
        public string date_Facture { get; set; }
        public string date_Saisie { get; set; }
        public string fournisseur { get; set; }
        public double totalTTC { get; set; }
    }
}
