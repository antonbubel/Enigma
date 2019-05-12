namespace Enigma.Infrastructure.Exceptions
{
    public class ApplicationAuthenticationException : ApplicationException
    {
        public ApplicationAuthenticationException(string message)
            : base(message)
        {
        }
    }
}
