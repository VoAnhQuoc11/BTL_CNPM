using QLCKTN.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLCKTN.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        Task<List<User>> GetUsers();
        Boolean UpFullName(string id, string fullName);
        Boolean UpPassword(string id, string password);
        Boolean UpBirthDate(string id, DateTime date);
        Boolean UpGender(string id, bool gender);

        Boolean UpImagine(string id, string image);
        Boolean UpStatus(string id, bool status);
        Boolean UpPhone(string id, string phone);
        Boolean UpEmail(string id, string email);

        Task<User> GetUserById(string id);
    }
}
