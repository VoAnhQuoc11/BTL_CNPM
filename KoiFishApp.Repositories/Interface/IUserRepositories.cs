
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
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
        Task<bool> DelUser(String userId);
        Task<bool> DelUser(User user);
        Task<bool> AddUser(User user);
        Task<bool> UpUser(User user);
        Task<List<User>> GetAllUser();

        User CreateUser(string Id,string username,string fullname,string password,string imageUrl,bool gender, DateOnly birthDate, string phone, bool status, string email);

        User? GetUserByUsernameAndPassword(string username, string password);
    }
}






