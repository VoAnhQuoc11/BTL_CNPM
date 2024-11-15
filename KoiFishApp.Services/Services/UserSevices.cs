using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
using KoiFishApp.Sevices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Sevices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositories _repositories;

        public UserServices(IUserRepositories repositories)
        {
            _repositories = repositories;
        }

	    public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _repositories.GetUserByUsernameAndPassword(username, password);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _repositories.GetUserByIdAsync(userId);
        }

        public async Task<bool> UpdateBirthDateAsync(string userId, DateOnly birthDate)
        {
            return await _repositories.UpdateBirthDateAsync(userId, birthDate);
        }

        public async Task<bool> UpdateEmailAsync(string userId, string email)
        {
            return await _repositories.UpdateEmailAsync(userId, email);
        }

        public async Task<bool> UpdateFullNameAsync(string userId, string fullName)
        {
            return await _repositories.UpdateFullNameAsync(userId, fullName);
        }

        public async Task<bool> UpdateGenderAsync(string userId, bool gender)
        {
            return await _repositories.UpdateGenderAsync(userId, gender);
        }

        public async Task<bool> UpdateImageAsync(string userId, string imageUrl)
        {
            return await _repositories.UpdateImageAsync(userId, imageUrl);
        }

        public async Task<bool> UpdatePhoneAsync(string userId, string phone)
        {
            return await _repositories.UpdatePhoneAsync(userId, phone);
        }

        public async Task<bool> UpdateStatusAsync(string userId, bool status)
        {
            return await _repositories.UpdateStatusAsync(userId, status);
        }

      
    }
}
