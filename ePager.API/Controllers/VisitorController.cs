using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePager.Data.Interfaces;
using ePager.Domain.Models;
using ePager.Data.Persistant;

namespace WebAPIePager.Controllers
{
    [Route("api/[controller]")]
    public class VisitorController : Controller
    {
        private readonly ILogger<VisitorController> _logger;
        private readonly IMessageRepository _messageRepository;
        private readonly IVisitorRepository _visitorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VisitorController(
            ILogger<VisitorController> logger, 
            IMessageRepository messageRepository, 
            IVisitorRepository visitorRepository, 
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _visitorRepository = visitorRepository;
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create-visitor")]
        public async Task PostVisitor([FromBody] Visitor visitor)
        {
            try
            {
                var message = new Message
                {
                    CreatedOn = DateTimeOffset.UtcNow,
                    OrderNo = visitor.OrderNo,
                    Name = visitor.Name,
                    Recipient = visitor.Mobile,
                    Status = MessageStatus.Created,
                    ShopId = visitor.ShopId
                };

                visitor.CreatedOn = DateTimeOffset.UtcNow;

                await _messageRepository.CreateAsync(message);
                await _visitorRepository.CreateAsync(visitor);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}
