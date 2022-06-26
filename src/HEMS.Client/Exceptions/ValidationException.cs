using System.Net;

namespace HEMS.Client.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(List<string>? errors = default)
            : base("Validation Failures Occured.", errors, HttpStatusCode.BadRequest)
        {
        }
    }
}
