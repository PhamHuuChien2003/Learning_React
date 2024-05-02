using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Message;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDBContext _context;
        public MessageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Message> CreateAsync(Message messageModel)
        {
            await _context.Message.AddAsync(messageModel);
            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<Message?> DeleteAsync(int id)
        {
            var messageModel = await _context.Message.FirstOrDefaultAsync(x=>x.MessageId == id);
            if (messageModel == null )
            {
                return null;
            }
            _context.Message.Remove(messageModel);
            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Message.Include(c=>c.RelationshipMember).ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Message.Include(c=>c.RelationshipMember).FirstOrDefaultAsync(i=>i.MessageId == id);
        }

        public async Task<Message?> UpdateAsync(int id, UpdateMessageRequestDto messageDto)
        {
            var existingMessage = await _context.Message.FirstOrDefaultAsync(x=>x.MessageId == id);
            if(existingMessage == null)
            {
                return null;
            }
            var messageUpdateModel = messageDto.ToMessageFromUpdateDTO  ();
            existingMessage.Content = messageUpdateModel.Content;
            await _context.SaveChangesAsync();
            return existingMessage;
        }
    }
}