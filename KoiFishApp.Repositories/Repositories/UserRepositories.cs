using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly QlcktnContext _context;

        public UserRepositories(QlcktnContext context)
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
            await _context.SaveChangesAsync();
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

        public User CreateUser(string Id, string username, string fullname, string password, string imageUrl, bool gender, DateOnly birthDate, string phone, bool status, string email)
        {
            User user = new User();
            user.Id = Id;
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;
            user.Image = imageUrl;
            user.BirthDate = birthDate;
            user.Phone = phone;
            user.Status = status;
            user.Email = email;
            return user;

        }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<bool> UpUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DelUser(string userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null) return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> DelUser(User user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null) return false;

                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<List<User>> GetAllUser()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

    }
}