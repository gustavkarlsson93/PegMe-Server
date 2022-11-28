using System.Net;

namespace API.ErrorResponse
{
    public class APIException : Exception
    {
        public HttpStatusCode Status { get; }
        public APIException(HttpStatusCode status, string message ) :base( message )
        {
            Status = status;
        }
    }
}
