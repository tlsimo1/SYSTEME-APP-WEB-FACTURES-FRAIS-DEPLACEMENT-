using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class EtatsService : IEtatsService
    {
        private IEtatsRepository _iEtatsRepository;
        public EtatsService(IEtatsRepository iEtatsRepository)
        {
            _iEtatsRepository = iEtatsRepository;
        }
        public async Task<IEnumerable<dynamic>> Get_Frais_ANT()
        {
            return await _iEtatsRepository.Get_Frais_ANT();
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_Avancement()
        {
            return await _iEtatsRepository.Get_Frais_Avancement();
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_Circulation(string etat)
        {
            return await _iEtatsRepository.Get_Frais_Circulation(etat);
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_ParModReglement(string mode)
        {
            return await _iEtatsRepository.Get_Frais_ParModReglement(mode);
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_ParVirement(string mode)
        {
            return await _iEtatsRepository.Get_Frais_ParVirement(mode);
        }

        public async Task<IEnumerable<dynamic>> Get_Frais_Provision(DateTime dateDebut, DateTime dateFin)
        {
            return await _iEtatsRepository.Get_Frais_Provision(dateDebut, dateFin);
        }
    }
}
