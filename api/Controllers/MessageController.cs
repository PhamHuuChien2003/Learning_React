using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Message;
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
        public MessageController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var message =await _context.Message.ToListAsync();
            var messageDto =message.Select(s => s.ToMessageDto());

            return Ok(messageDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message =await _context.Message.FindAsync(id);

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
            await _context.Message.AddAsync(messageModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new {id=messageModel.MessageId},messageModel.ToMessageDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateMessageRequestDto updateMessageDto)
        {
            var messageModel =await _context.Message.FirstOrDefaultAsync(x => x.MessageId == id);
            if (messageModel == null) 
            {
                return NotFound();
            }
            var messageUpdateModel = updateMessageDto.ToMessageFromUpdateDTO();
            messageModel.Content = messageUpdateModel.Content;
            await _context.SaveChangesAsync();
            return Ok(messageModel.ToMessageDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var messageModel = _context.Message.FirstOrDefault(x => x.MessageId == id);
            if (messageModel == null) 
            {
                return NotFound();
            }
            _context.Message.Remove(messageModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}