using AspNetCore.Reporting;
using Blog_MVC.Helps;
using Blog_MVC.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blog_MVC.Controllers
{
    public class FraisDeplacementController : Controller
    {
        private readonly IWebHostEnvironment _IWebHostEnv;

        public FraisDeplacementController(IWebHostEnvironment iWebHostEnv)
        {
            _IWebHostEnv = iWebHostEnv;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index(string roles, string userName)
        {
            string[] arrry = { };
            GetUserInfo_ViewModel userInfo = new GetUserInfo_ViewModel();
            try
            {
                if (userName == null)
                {
                    userInfo = GlobalVariable.G_UserInfo;
                    return View(userInfo);
                }
                userInfo.UserName = userName == null ? "" : userName;
                userInfo.Roles = roles == null ? arrry : roles.Split(',');
                GlobalVariable.G_UserInfo = userInfo;
                return View(userInfo);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //[HttpPost("GetEtatAvancee")]
        public async Task<IActionResult> GetEtatAvance([FromBody] List<dynamic> listOfObjects)
        {
            List<Get_Frais_avancementViewModel> Get_Frais_avancementViewModel = new List<Get_Frais_avancementViewModel>();
            foreach (dynamic item in listOfObjects)
            {
                Get_Frais_avancementViewModel _Get_Frais_avancementViewModel = new Get_Frais_avancementViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _Get_Frais_avancementViewModel.Circulation = data.Circulation;
                _Get_Frais_avancementViewModel.Nom = data.Nom;
                _Get_Frais_avancementViewModel.Total = data.Total;
                _Get_Frais_avancementViewModel.DateAvance = data.DateAvance;
                _Get_Frais_avancementViewModel.Matricule = data.Matricule;
                _Get_Frais_avancementViewModel.VilleRegion = data.VilleRegion;
                Get_Frais_avancementViewModel.Add(_Get_Frais_avancementViewModel);
            }
            GlobalVariable.ListFraisAvancement = Get_Frais_avancementViewModel;
            return View();
        }
        public async Task<IActionResult> GenerateRDLC()
        {
            string reportName = "GetFrais_avancement.rdlc";
            string minType = "";
            int extension = 1;
            var path = $"{_IWebHostEnv.WebRootPath}\\Repots\\{reportName}";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais d'avancement");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));
            DataTable dt = new DataTable();
            dt = ConvertToDataTable(GlobalVariable.ListFraisAvancement);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("get_FraisAvancement", dt);
            var res = localReport.Execute(RenderType.Pdf);
            return File(res.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                          "FraisAvancement.pdf");
        }
        public async Task<IActionResult> GetEtatModeRegelement([FromBody] List<dynamic> listModeRegelement)
        {
            List<Get_Frais_ModeRegelementViewModel> Get_Frais_ModeRegelementViewModel = new List<Get_Frais_ModeRegelementViewModel>();
            foreach (dynamic item in listModeRegelement)
            {
                Get_Frais_ModeRegelementViewModel _get_Frais_ModeRegelementViewModel = new Get_Frais_ModeRegelementViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _get_Frais_ModeRegelementViewModel.Circulation = data.Circulation;
                _get_Frais_ModeRegelementViewModel.Nom = data.Nom;
                _get_Frais_ModeRegelementViewModel.Total = data.Total;
                _get_Frais_ModeRegelementViewModel.ModeReglement = data.ModeReglement;
                _get_Frais_ModeRegelementViewModel.Matricule = data.Matricule;
                _get_Frais_ModeRegelementViewModel.VilleRegion = data.VilleRegion;
                Get_Frais_ModeRegelementViewModel.Add(_get_Frais_ModeRegelementViewModel);
            }
            GlobalVariable.ListFraisModeRegelement = Get_Frais_ModeRegelementViewModel;
            return View();
        }
        public IActionResult GenerateRDLCModeRegelement()
        {
            //var returnString = GenerateReportAsync("GetFraisParModeRegelement.rdlc");
            //return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, "GetFraisParModeRegelement.rdlc" + ".pdf");
            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(GlobalVariable.ListFraisModeRegelement);
            string minType = "";
            int extension = 1;
            var path2 = $"{_IWebHostEnv.WebRootPath}\\Repots\\GetFraisParModeRegelement.rdlc";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais par Mode Régelement");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));

            LocalReport localReport = new LocalReport(path2);
            localReport.AddDataSource("GetFraisParModeRegelement", dt2);
            int ext = (int)(DateTime.Now.Ticks >> 10);
            //var res2 = localReport.Execute(RenderType.Pdf, ext, parametters);
            var res2 = localReport.Execute(RenderType.Pdf);
            return File(res2.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                        "FraisParModeRegelement.pdf");
        }

        public async Task<IActionResult> GetEtatCirculation([FromBody] List<dynamic> listCirculation)
        {
            List<Get_CirculationViewModel> Get_CirculationViewModel = new List<Get_CirculationViewModel>();
            foreach (dynamic item in listCirculation)
            {
                Get_CirculationViewModel _get_CirculationViewModel = new Get_CirculationViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _get_CirculationViewModel.Circulation = data.Circulation;
                _get_CirculationViewModel.Nom = data.Nom;
                _get_CirculationViewModel.Total = data.Total;
                _get_CirculationViewModel.Matricule = data.Matricule;
                _get_CirculationViewModel.CodeAnalytique = data.CodeAnalytique;

                Get_CirculationViewModel.Add(_get_CirculationViewModel);
            }
            GlobalVariable.ListCirculation = Get_CirculationViewModel;
            return View();
        }
        public IActionResult GenerateRDLC_Circulation()
        {
            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(GlobalVariable.ListCirculation);
            string minType = "";
            int extension = 1;
            var path2 = $"{_IWebHostEnv.WebRootPath}\\Repots\\Get_Circulation.rdlc";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais par Circulation");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));

            LocalReport localReport = new LocalReport(path2);
            localReport.AddDataSource("get_Circulation", dt2);
            int ext = (int)(DateTime.Now.Ticks >> 10);
            //var res2 = localReport.Execute(RenderType.Pdf, ext, parametters);
            var res2 = localReport.Execute(RenderType.Pdf);
            return File(res2.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                        "FraisParCirculation.pdf");
        }


        public async Task<IActionResult> GetEtatFraisANT([FromBody] List<dynamic> listFraisANT)
        {
            List<GetFraisANT_ViewModel> GetFraisANT_ViewModel = new List<GetFraisANT_ViewModel>();
            foreach (dynamic item in listFraisANT)
            {
                GetFraisANT_ViewModel _getFraisANT_ViewModel = new GetFraisANT_ViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _getFraisANT_ViewModel.Circulation = data.Circulation;
                _getFraisANT_ViewModel.Nom = data.Nom;
                _getFraisANT_ViewModel.Total_frais_AV = data.Total_frais_AV;
                _getFraisANT_ViewModel.Matricule = data.Matricule;
                _getFraisANT_ViewModel.Total_frais_Deplacement = data.Total_frais_Deplacement;
                _getFraisANT_ViewModel.CodeAnalytique = data.CodeAnalytique;
                _getFraisANT_ViewModel.Total_frais_KM = data.Total_frais_KM;
                GetFraisANT_ViewModel.Add(_getFraisANT_ViewModel);
            }
            GlobalVariable.ListFraisANT = GetFraisANT_ViewModel;
            return View();
        }
        public IActionResult GenerateRDLC_FraisANT()
        {
            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(GlobalVariable.ListFraisANT);
            string minType = "";
            int extension = 1;
            var path2 = $"{_IWebHostEnv.WebRootPath}\\Repots\\Get_FraisANT.rdlc";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais ANT");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));

            LocalReport localReport = new LocalReport(path2);
            localReport.AddDataSource("get_FraisANT", dt2);
            int ext = (int)(DateTime.Now.Ticks >> 10);
            //var res2 = localReport.Execute(RenderType.Pdf, ext, parametters);
            var res2 = localReport.Execute(RenderType.Pdf);
            return File(res2.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                        "FraisANT.pdf");
        }


        public async Task<IActionResult> GetEtatFraisProv([FromBody] List<dynamic> listFraisProv)
        {
            List<Get_FraisProvViewModel> Get_FraisProvViewModel = new List<Get_FraisProvViewModel>();
            foreach (dynamic item in listFraisProv)
            {
                Get_FraisProvViewModel _get_FraisProvViewModel = new Get_FraisProvViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _get_FraisProvViewModel.TotalFR = data.TotalFR;
                _get_FraisProvViewModel.Nom = data.Nom;
                _get_FraisProvViewModel.TotalKM = data.TotalKM;
                _get_FraisProvViewModel.Matricule = data.Matricule;
                _get_FraisProvViewModel.TotalAV = data.TotalAV;
                _get_FraisProvViewModel.CodeAnalytique = data.CodeAnalytique;
                _get_FraisProvViewModel.DateSaisie = data.DateSaisie;
                _get_FraisProvViewModel.DateReglement = data.DateReglement;
                Get_FraisProvViewModel.Add(_get_FraisProvViewModel);
            }
            GlobalVariable.ListFraisProv = Get_FraisProvViewModel;
            return View();
        }
        public IActionResult GenerateRDLC_FraisProv()
        {
            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(GlobalVariable.ListFraisProv);
            string minType = "";
            int extension = 1;
            var path2 = $"{_IWebHostEnv.WebRootPath}\\Repots\\Get_FraisProv.rdlc";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais Provision");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));

            LocalReport localReport = new LocalReport(path2);
            localReport.AddDataSource("get_FraisProv", dt2);
            int ext = (int)(DateTime.Now.Ticks >> 10);
            //var res2 = localReport.Execute(RenderType.Pdf, ext, parametters);
            var res2 = localReport.Execute(RenderType.Pdf);
            return File(res2.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                        "FraisProvison.pdf");
        }

        public static DataTable ConvertToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }
            return table;
        }
        public byte[] GenerateReportAsync(string reportName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportAPI.dll", string.Empty);
            string rdlcFilePath = string.Format("D:\\CleanArchitecture\\Nouveau dossier (2)\\Dimatit Projet Front End - Copie\\Blog_MVC\\wwwroot\\Repots\\GetFraisParModeRegelement.rdlc", fileDirPath, reportName);
            //Dictionary<string, string> parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);



            report.AddDataSource("get_FraisModeRegelement", GlobalVariable.ListFraisModeRegelement);
            var result = report.Execute(GetRenderType("pdf"), 1);
            return result.MainStream;
        }
        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "word":
                    renderType = RenderType.Word;
                    break;
                case "excel":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }
    }
}
