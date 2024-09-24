using Blog_MVC.ViewModel;

namespace Blog_MVC.Helps
{
    public static class GlobalVariable
    {
        public static List<Get_Frais_avancementViewModel> ListFraisAvancement { get; set; }
        public static List<Get_Frais_ModeRegelementViewModel> ListFraisModeRegelement { get; set; }
        public static List<Get_CirculationViewModel> ListCirculation { get; set; }

        public static List<GetFraisANT_ViewModel> ListFraisANT { get; set; }

        public static List<Get_FraisProvViewModel> ListFraisProv { get; set; }
        public static List<GetFactureViewModel> ListFacture { get; set; }
        public static GetUserInfo_ViewModel G_UserInfo { get; set; }
    }
}
