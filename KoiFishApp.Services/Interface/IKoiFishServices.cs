using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Interface
{
     public interface IKoiFishServices
    {
          Task<List<KoiFish>> KoiFish();
          Task AddKoiFishAsync(KoiFish koiFish);
    }
}
