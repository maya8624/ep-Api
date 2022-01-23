using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ePager.Domain.Dtos;
using ePager.Data.Interfaces;
using ePager.Domain.Models;
using ePager.Data.Persistant;
using ePager.Data.Wrappers;
using AutoMapper;
using System.Collections.Generic;

namespace WebAPIePager.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;
        private readonly IRepositoryWrapper _wrapper;

        public MessageController(IMapper mapper, ILogger<MessageController> logger, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _logger = logger;
            _wrapper = wrapper;
        }
                
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("create-message")]
        //public async Task<IActionResult> PostMessage(MessageCreateDto messageCreateDto)
        //{
        //    //var result = await CheckAnyAsync(message.ShopId, message.OrderNo);
        //    //if (result is not null) return;

        //    var message = _mapper.Map<Message>(messageCreateDto);            
        //    var messageDetail = _mapper.Map<MessageDetail>(messageCreateDto.MessageDetail);
        //    await _wrapper.Message.CreateAsync(message);
        //    await _wrapper.MessageDetail.CreateAsync(messageDetail);
        //    await _wrapper.UnitOfWork.CompleteAsync();

        //    return Ok();
        //    // return MessageReadDto?
        //}

        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPut("update-message")]
        //public async Task PutMessage(MessageCreateDto messageCreateDto)
        //{
        //    var existingMessage = await _wrapper.Message.CheckAnyAsync(messageCreateDto.ShopId, messageCreateDto.OrderNo);
        //    if (existingMessage is false)
        //    {
        //        return;
        //    }

        //    var message = _mapper.Map<Message>(messageCreateDto);
        //    _wrapper.Message.Update(message);
        //    await _wrapper.UnitOfWork.CompleteAsync();
        //}
    }
}
