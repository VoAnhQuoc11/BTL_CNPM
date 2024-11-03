using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interface
{
        public interface IKoiFishRepositories
    {
        Task<List<KoiFish>> GetAllKoiFish();
        Task AddKoiFish(KoiFish koiFish);
    }
}
