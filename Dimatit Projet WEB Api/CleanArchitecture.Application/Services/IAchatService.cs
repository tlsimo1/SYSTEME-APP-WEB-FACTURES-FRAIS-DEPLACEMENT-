using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IAchatService
    {
        Task<IEnumerable<dynamic>> GetAllFacturesAchats();
        Task<int> Edit_StatusAchat(int id);
        Task<dynamic> GetFactureAchat(int numFac);
        Task<dynamic> GetFactureParDateAchat(DateTime date);
    }
}
