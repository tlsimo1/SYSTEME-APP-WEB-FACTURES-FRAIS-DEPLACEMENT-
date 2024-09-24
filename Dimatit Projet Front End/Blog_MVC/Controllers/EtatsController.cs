using Blog_MVC.Helps;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Blog_MVC.ViewModel;
using System.ComponentModel;
using System.Data;
using AspNetCore.Reporting;

namespace Blog_MVC.Controllers
{
    public class EtatsController : Controller
    {
        private readonly IWebHostEnvironment _IWebHostEnv;
        

        public EtatsController(IWebHostEnvironment iWebHostEnv)
        {
            _IWebHostEnv = iWebHostEnv;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [HttpPost]
        public IActionResult Index([FromBody] List<dynamic> ListFacture)
        {
            GetUserInfo_ViewModel userInfo = new GetUserInfo_ViewModel();

            userInfo = GlobalVariable.G_UserInfo;
            

            List<GetFactureViewModel> GetFactureViewModel = new List<GetFactureViewModel>();
            foreach (dynamic item in ListFacture)
            {
                GetFactureViewModel _getFactureViewModel = new GetFactureViewModel();
                var data = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                _getFactureViewModel.date_Facture =data.date_Facture.ToString("dd/MM/yyyy");
                _getFactureViewModel.numFacture = data.numFacture;
                _getFactureViewModel.iD_facture = data.iD_facture;
                _getFactureViewModel.date_Saisie = data.date_Saisie.ToString("dd/MM/yyyy"); 
                _getFactureViewModel.totalTTC = data.totalTTC;
                _getFactureViewModel.fournisseur= data.fournisseur;
                GetFactureViewModel.Add(_getFactureViewModel);
            }
            GlobalVariable.ListFacture = GetFactureViewModel;
            return View(userInfo);
        }
        public IActionResult GenerateRDLC_EtatFacture()
        {
            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(GlobalVariable.ListFacture);
            string minType = "";
            int extension = 1;
            var path2 = $"{_IWebHostEnv.WebRootPath}\\Repots\\GetAll_Facure.rdlc";
            Dictionary<string, string> parametters = new Dictionary<string, string>();
            parametters.Add("param1", "Frais Provision");
            parametters.Add("param2", DateTime.Now.ToString("dd/mm/yyyyy"));

            LocalReport localReport = new LocalReport(path2);
            localReport.AddDataSource("getAllFacture", dt2);
            int ext = (int)(DateTime.Now.Ticks >> 10);
            //var res2 = localReport.Execute(RenderType.Pdf, ext, parametters);
            var res2 = localReport.Execute(RenderType.Pdf);
            return File(res2.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,
                        "ListFacture.pdf");
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
    }
}
