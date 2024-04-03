using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Message;
using api.Models;

namespace api.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto ToMessageDto(this Message messageModel)
        {
            return new MessageDto
            {
                MessageId = messageModel.MessageId,
                Content = messageModel.Content,
                SendMessageTime = messageModel.SendMessageTime,
                RelationshipMemberId = messageModel.RelationshipMemberId,
            };
        }
        public static Message ToMessageFromCreateDTO(this CreateMessagerequestDto messageDto)
        {
            return new Message
            {
                Content = messageDto.Content,
                SendMessageTime = messageDto.SendMessageTime,
                RelationshipMemberId = messageDto.RelationshipMemberId,
            };
        }
    }
}