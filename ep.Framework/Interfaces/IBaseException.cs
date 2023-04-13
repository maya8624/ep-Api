namespace ep.Framework.Interfaces
{
    public interface IBaseException
    {
        public int ErrorCode { get; set; }
        public string? Details { get; set; }
    }
}
