using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class AchatService : IAchatService
    {
        private IAchatRepository _iAchatRepository;
        public AchatService(IAchatRepository iAchatRepository)
        {
            _iAchatRepository = iAchatRepository;
        }
        public async Task<int> Edit_StatusAchat(int id)
        {
            return await _iAchatRepository.Edit_StatusAchat(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesAchats()
        {
            return await _iAchatRepository.GetAllFacturesAchats();
        }

        public async Task<dynamic> GetFactureAchat(int numFac)
        {
            return await _iAchatRepository.GetFactureAchat(numFac);
        }

        public async Task<dynamic> GetFactureParDateAchat(DateTime date)
        {
            return await _iAchatRepository.GetFactureParDateAchat(date);
        }
    }
}
