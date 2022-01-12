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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("message-by-orderno")]
        public async Task<Message> GetMessage(int shopId, string orderNo)
        {
            // CHECK: check possibility of duplicate order numbers.

            //return new Message
            //{
            //    Id = 1,
            //    Count = 0,
            //    Name = "Andy",
            //    Image = "cake.png",
            //    OrderNo = "Order No: 20211203-01",
            //    Text = "Order No.: 2021-12-03-01 is ready to pick up.",
            //    Status = MessageStatus.Created,
            //    CreatedOn = DateTimeOffset.UtcNow,
            //};

            var result = await _repository.GetByOrderNoAsync(shopId, orderNo);
            return result;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("create-meessage")]
        public async Task PostMessage(Message message)
        {
            await _repository.CreateAsync(message);
            await _unitOfWork.CompleteAsync();
        }

        [HttpPut("update-message")]
        public async Task PutMessage(Message message)
        {
            _repository.Update(message);
            await _unitOfWork.CompleteAsync();
        }
    }
}
