using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IEtatsService
    {
        Task<IEnumerable<dynamic>> Get_Frais_Avancement();

        Task<IEnumerable<dynamic>> Get_Frais_ANT();
        Task<IEnumerable<dynamic>> Get_Frais_Circulation(string etat);
        Task<IEnumerable<dynamic>> Get_Frais_ParVirement(string mode);
        Task<IEnumerable<dynamic>> Get_Frais_ParModReglement(string mode);
        Task<IEnumerable<dynamic>> Get_Frais_Provision(DateTime dateDebut, DateTime dateFin);
    }
}
