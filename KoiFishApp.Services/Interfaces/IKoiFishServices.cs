﻿using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Interfaces
{
    public interface IKoiFishServices
    {

        Task<List<KoiFish>> KoiFish();
        Task AddKoiFishAsync(KoiFish koiFish);
        //
        Task DeleteKoiFishAsync(int id);
        Task<KoiFish?> GetKoiFishByIdAsync(int id);
        Task<List<Pond>> GetAllPondsAsync();
        Task UpdateKoiFishAsync(KoiFish koiFish);
        Task<bool> KoiFishExistsAsync(int id);
        //
        
    }
}
