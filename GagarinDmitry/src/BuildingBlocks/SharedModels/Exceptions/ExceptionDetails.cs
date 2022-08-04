using System.Text.Json;

namespace SharedModels.Exceptions
{
    public class ExceptionDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = null!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
