namespace ep.Framework.Interfaces
{
    public interface IBusinessException
    {
        public int ErrorCode { get; set; }
        public string? Details { get; set; }
    }
}
