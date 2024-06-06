using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(UserQueryObject userQuery);
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(int id , UpdateUserRequestDto userDto);
        Task<User?> DeleteAsync(int id);
        Task<User?> GetByAccountIdAsync(string id);
    }
}