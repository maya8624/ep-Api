using ep.Contract.Dtos;
using ep.Service.Email;

namespace ep.API.Controllers
{   
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;
        private readonly IEmailService _emailService;
        private readonly IRepositoryWrapper _repository;

        public MessageController(IMapper mapper, ILogger<MessageController> logger, IRepositoryWrapper repository, IEmailService emailService)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _emailService = emailService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<IActionResult> PostMessage(MessageCreateDto createDto)
        {
            try
            {
                //TODO: move the logic to the service class
                if (createDto == null)
                    return BadRequest();
                var message = _mapper.Map<Message>(createDto);
                message.CreatedOn = DateTimeOffset.UtcNow;
                await _repository.Message.CreateAsync(message);
                await _repository.UnitOfWork.CompleteAsync();
                return Ok(message.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailReadDto email)
        {
            try
            {
                var message = new EmailMessage
                (
                    new string[] { email.To, "maya8624@hotmail.com" },
                    email.Subject,
                    email.Content
                );
                await _emailService.SendEmailAsync(message);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
