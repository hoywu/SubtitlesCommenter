namespace SubtitlesCommenter.Exceptions
{
    internal class UnknownStyleException : Exception
    {
        public UnknownStyleException()
        {
        }
        public UnknownStyleException(string message) : base(message)
        {
        }
        public UnknownStyleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
