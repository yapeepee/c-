

namespace MyFirstAPI.Models.Exceptions
{
    public class NotFoundException : Exceptions
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}