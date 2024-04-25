using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Message;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMessageRepository _messageRepo;
        public MessageController(ApplicationDBContext context, IMessageRepository messageRepo)
        {
            _context = context;
            _messageRepo =messageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var message =await _messageRepo.GetAllAsync();
            var messageDto =message.Select(s => s.ToMessageDto());

            return Ok(messageDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message =await _messageRepo.GetByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessagerequestDto createMessageDto)
        {
            var messageModel = createMessageDto.ToMessageFromCreateDTO();
            await _messageRepo.CreateAsync(messageModel);
            return CreatedAtAction(nameof(GetById),new {id=messageModel.MessageId},messageModel.ToMessageDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateMessageRequestDto updateMessageDto)
        {
            var messageModel =await _messageRepo.UpdateAsync(id, updateMessageDto);
            if (messageModel == null) 
            {
                return NotFound();
            }
            return Ok(messageModel.ToMessageDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var messageModel = _messageRepo.DeleteAsync(id);
            if (messageModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}