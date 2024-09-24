using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interface
{
    public interface IAssistate_DAFRepository
    {
        Task<IEnumerable<dynamic>> GetAllFacturesAssDAF();
        Task<int> Edit_StatusAssDAF(int id);
        Task<dynamic> GetFactureAssDAF(int numFacAss);
        Task<dynamic> GetFactureParDateAssDAF(DateTime date);
    }
}
