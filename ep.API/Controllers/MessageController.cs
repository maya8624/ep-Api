namespace ep.API.Controllers
{   
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MessageController> _logger;
        private readonly IRepositoryWrapper _repository;

        public MessageController(IMapper mapper, ILogger<MessageController> logger, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Message))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<IActionResult> PostMessage(MessageCreateDto createDto)
        {
            try
            {
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
    }
}
