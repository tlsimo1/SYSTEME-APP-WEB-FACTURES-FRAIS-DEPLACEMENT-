using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class Chef_ComptabiliteService: IChef_ComptabiliteService
    {
        private IChef_ComptabiliteRepository _repository;
        public Chef_ComptabiliteService(IChef_ComptabiliteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Edit_StatusChefCmp(int id)
        {
            return await _repository.Edit_StatusChefCmp(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesChefCmp()
        {
            return await _repository.GetAllFacturesChefCmp();
        }

        public async Task<dynamic> GetFactureChefCmp(int numFac)
        {
            return await _repository.GetFactureChefCmp(numFac);
        }

        public async Task<dynamic> GetFactureParDateChefCmp(DateTime date)
        {

            return await _repository.GetFactureParDateChefCmp(date);
        }
    }
}
