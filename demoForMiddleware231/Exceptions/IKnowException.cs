namespace demoForMiddleware231.Exceptions
{
    public interface IKnowException
    {
        public string Message { get; }

        public int ErrorCode { get; }

        public object[] ErrorData { get; }
    }
}
