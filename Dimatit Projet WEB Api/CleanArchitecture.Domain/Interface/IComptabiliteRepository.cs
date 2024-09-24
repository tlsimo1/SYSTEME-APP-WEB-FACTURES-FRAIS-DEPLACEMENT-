using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interface
{
    public interface IComptabiliteRepository
    {
        Task<IEnumerable<dynamic>> GetAllFacturesCmp();
        Task<int> Edit_StatusCmp(int id);
        Task<dynamic> GetFactureCmp(int numFac);
        Task<dynamic> GetFactureParDateCmp(DateTime date);
    }
}
