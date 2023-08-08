using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using ep.Service.Email;
using Microsoft.AspNetCore.DataProtection;
using System.Net;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class MessageController : CustomControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;
        private readonly IEmailService _emailService;
        private readonly IMessageService _messageService;
        private readonly IRepositoryWrapper _repository;

        public MessageController(
            IConfiguration configuration,
            IMapper mapper, 
            ILogger<MessageController> logger, 
            IRepositoryWrapper repository, 
            IEmailService emailService,
            IMessageService messageService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _emailService = emailService;
            _messageService = messageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<IActionResult> PostMessage(MessageRequest createDto)
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
        public async Task<IActionResult> SendEmail([FromBody] EmailView email)
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("queue")]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            try
            {
                var result = await _messageService.SendMessageResult(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return HandleException(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("secrets")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Customer>>> GetSecrets()
        {
            var secretName = "DBConn";
            var secretValue = _configuration[secretName];
            var vaultUri = new Uri($"https://andy-kv-test.vault.azure.net/");
            var client = new KeyClient(vaultUri, new DefaultAzureCredential());
            var key = await client.GetKeyAsync("Abcd");
            var value = key.Value.Properties.Version;

            if (secretValue == null)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error: No secret named {secretName} was found...");
            }
            else
            {
                return Content($"Secret value: {secretValue}" +
                    Environment.NewLine + Environment.NewLine +
                    "This is for testing only! Never output a secret " +
                    "to a response or anywhere else in a real app!");
            }
        }
    }
}
