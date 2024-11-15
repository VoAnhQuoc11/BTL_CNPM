using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly KoiFishApppContext _context; 

        public UserRepositories(KoiFishApppContext context)
        {
            _context = context;
        }
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }


        public async Task<bool> UpdateBirthDateAsync(string userId, DateOnly birthDate)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.BirthDate = birthDate;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEmailAsync(string userId, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email không được để trống", nameof(email));
            }
            var user = await GetUserByIdAsync(userId);
            if (user == null) return false;

            user.Email = email;
            _context.Users.Update(user);
             await _context.SaveChangesAsync();
             return true;
        }

        public async Task<bool> UpdateFullNameAsync(string userId, string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Họ và tên không được để trống", nameof(fullName));
            }
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.FullName = fullName;
            _context.Users.Update(user);
           await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateGenderAsync(string userId, bool gender)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.Gender = gender;
            _context.Users.Update(user);
             await _context.SaveChangesAsync() ;
            return true;
        }

        public async Task<bool> UpdateImageAsync(string userId, string imageUrl)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.Image = imageUrl;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePhoneAsync(string userId, string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Phone không được để trống", nameof(phone));
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.Phone = phone;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatusAsync(string userId, bool status)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.Status = status;
            _context.Users.Update(user);    
            await _context.SaveChangesAsync();
            return true;
        }

      

    }
}

    
