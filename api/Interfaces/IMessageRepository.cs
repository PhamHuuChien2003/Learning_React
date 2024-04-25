using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Message;
using api.Models;

namespace api.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task<Message> CreateAsync(Message messageModel);
        Task<Message?> UpdateAsync(int id , UpdateMessageRequestDto messageDto);
        Task<Message?> DeleteAsync(int id);
    }
}