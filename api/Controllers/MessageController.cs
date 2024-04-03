using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Message;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var message = _context.Message.ToList()
                .Select(s => s.ToMessageDto());

            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var message = _context.Message.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateMessagerequestDto createMessageDto)
        {
            var messageModel = createMessageDto.ToMessageFromCreateDTO();
            _context.Message.Add(messageModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new {id=messageModel.MessageId},messageModel.ToMessageDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateMessageRequestDto updateMessageDto)
        {
            var messageModel = _context.Message.FirstOrDefault(x => x.MessageId == id);
            if (messageModel == null) 
            {
                return NotFound();
            }
            messageModel = updateMessageDto.ToMessageFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= messageModel.MessageId}, messageModel.ToMessageDto());
        }
    }
}