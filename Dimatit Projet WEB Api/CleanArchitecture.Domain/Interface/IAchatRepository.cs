using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interface
{
    public interface IAchatRepository
    {
        Task<IEnumerable<dynamic>> GetAllFacturesAchats();
        Task<int> Edit_StatusAchat(int id);
        Task<dynamic> GetFactureAchat(int numFac);
        Task<dynamic> GetFactureParDateAchat(DateTime date);
    }
}
