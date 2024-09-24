using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ComptabiliteService : IComptabiliteService
    {
        private IComptabiliteRepository _repository;
        public ComptabiliteService(IComptabiliteRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Edit_StatusCmp(int id)
        {
            return await _repository.Edit_StatusCmp(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesCmp()
        {
            return await _repository.GetAllFacturesCmp();
        }

        public async Task<dynamic> GetFactureCmp(int numFac)
        {
            return await _repository.GetFactureCmp(numFac);
        }

        public async Task<dynamic> GetFactureParDateCmp(DateTime date)
        {
            return await _repository.GetFactureParDateCmp(date);
        }
    }
}
