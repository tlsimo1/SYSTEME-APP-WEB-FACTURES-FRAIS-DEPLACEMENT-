using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interface
{
    public interface IChef_ComptabiliteRepository
    {
        Task<IEnumerable<dynamic>> GetAllFacturesChefCmp();
        Task<int> Edit_StatusChefCmp(int id);
        Task<dynamic> GetFactureChefCmp(int numFac);
        Task<dynamic> GetFactureParDateChefCmp(DateTime date);
    }
}
