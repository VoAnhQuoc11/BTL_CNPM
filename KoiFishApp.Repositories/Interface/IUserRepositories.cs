using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Intrefaces
{
    public interface IUserRepositories
    {
        Task<User> GetUserByIdAsync(string userId);

        Task<bool> UpdateFullNameAsync(string userId, string fullName);
        Task<bool> UpdateEmailAsync(string userId, string email);
        Task<bool> UpdatePhoneAsync(string userId, string phone);
        Task<bool> UpdateStatusAsync(string userId, bool status);
        Task<bool> UpdateImageAsync(string userId, string imageUrl);
        Task<bool> UpdateBirthDateAsync(string userId, DateOnly birthDate);
        Task<bool> UpdateGenderAsync(string userId, bool gender);



        User? GetUserByUsernameAndPassword(string username, string password);
    }
}
