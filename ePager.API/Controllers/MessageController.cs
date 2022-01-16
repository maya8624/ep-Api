using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ePager.Domain.Dtos;
using ePager.Data.Interfaces;
using ePager.Domain.Models;
using ePager.Data.Persistant;

namespace WebAPIePager.Controllers
{   
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageController(ILogger<MessageController> logger, IMessageRepository repository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpGet("message-by-shopid-orderno")]
        public async Task<ActionResult<Message>> GetByShopIdAndOrderNo(int shopId, string orderNo)
        {
            // CHECK: check possibility of duplicate order numbers.
            return await _repository.GetByShopIdAndOrderNo(shopId, orderNo);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create-message")]
        public async Task PostMessage(Message message)
        {
            var result = await GetByShopIdAndOrderNo(message.ShopId, message.OrderNo);
            if (result is not null) return;
            
            await _repository.CreateAsync(message);
            await _unitOfWork.CompleteAsync();

            // return MessageReadDto?
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("update-message")]
        public async Task PutMessage(Message message)
        {
            var existingMessage = GetByShopIdAndOrderNo(message.ShopId, message.OrderNo);
            if (existingMessage is null)
            {
                return;
            }

            _repository.Update(message);
            await _unitOfWork.CompleteAsync();
        }
    }
}
