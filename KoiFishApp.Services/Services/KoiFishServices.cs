using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Services
{
    public class KoiFishServices : IKoiFishServices
{
    private readonly IKoiFishRepositories _repositories;
    public KoiFishServices(IKoiFishRepositories repositories)
    {
        _repositories = repositories;
    }
    public Task<List<KoiFish>> KoiFish()
    {
        return _repositories.GetAllKoiFish();
    }
}
}
