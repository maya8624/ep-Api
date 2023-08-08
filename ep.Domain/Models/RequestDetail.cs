namespace ep.Domain.Models
{
    public class RequestDetail
    {
        public int Id { get; set; }

        public int Requests { get; set; }

        public int UserId { get; set; }

        public int RequestLimitId { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;

        public RequestLimit? RequestLimit { get; set; }

        public User? User { get; set; }
    }
}
