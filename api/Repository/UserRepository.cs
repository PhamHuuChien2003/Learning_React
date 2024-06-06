using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Helper;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.User.FirstOrDefaultAsync(x=>x.UserId == id);
            if (userModel == null )
            {
                return null;
            }
            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync(UserQueryObject userQuery)
        {
            var user = _context.User.Include(c=>c.Posts).Include(c=>c.RelationshipMembers).AsQueryable();
            if (!string.IsNullOrWhiteSpace(userQuery.UserAccountID))
            {
                user = user.Where(s => s.UserAccountID.Contains(userQuery.UserAccountID));
            }

            if (!string.IsNullOrWhiteSpace(userQuery.FirstName))
            {
                user = user.Where(s => s.FirstName.Contains(userQuery.FirstName));
            }
             return await user.ToListAsync();
        }

        public async Task<User?> GetByAccountIdAsync(string id)
        {
             return await _context.User.FirstOrDefaultAsync(i=>i.UserAccountID == id);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.Include(c=>c.Posts).Include(c=>c.RelationshipMembers).FirstOrDefaultAsync(i=>i.UserId == id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(x=>x.UserId == id);
            if(existingUser == null)
            {
                return null;
            }
            
            var userUpdateModel = userDto.ToUserFromUpdateDTO();
            existingUser.FirstName = userUpdateModel.FirstName;
            existingUser.LastName = userUpdateModel.LastName;
            existingUser.Age=userUpdateModel.Age;
            await _context.SaveChangesAsync();
            return existingUser;
            
        }
    }
}