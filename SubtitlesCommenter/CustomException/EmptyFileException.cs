namespace SubtitlesCommenter.CustomException
{
    internal class EmptyFileException : Exception
    {
        public EmptyFileException()
        {
        }
        public EmptyFileException(string message) : base(message)
        {
        }
        public EmptyFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
