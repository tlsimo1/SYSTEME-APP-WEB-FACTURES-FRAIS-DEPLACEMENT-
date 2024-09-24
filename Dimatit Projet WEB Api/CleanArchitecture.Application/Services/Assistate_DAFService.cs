using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class Assistate_DAFService: IAssistate_DAFService
    {
        private IAssistate_DAFRepository _repository;
        public Assistate_DAFService(IAssistate_DAFRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Edit_StatusAssDAF(int id)
        {
            return await _repository.Edit_StatusAssDAF(id);
        }

        public async Task<IEnumerable<dynamic>> GetAllFacturesAssDAF()
        {
            return await _repository.GetAllFacturesAssDAF();
        }

        public async Task<dynamic> GetFactureAssDAF(int numFacAss)
        {
            return await _repository.GetFactureAssDAF(numFacAss);
        }

        public async Task<dynamic> GetFactureParDateAssDAF(DateTime date)
        {
            return await _repository.GetFactureParDateAssDAF(date);
        }
    }
}
