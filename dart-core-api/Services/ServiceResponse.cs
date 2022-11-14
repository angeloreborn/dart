using dart_core_api.Helper;

namespace dart_core_api.Services
{
    public class ServiceResponse
    {
        public Error? Error { get; set; }
        public ServiceResponse()
        {

        }

    }
    public class ServiceResponse<T> : ServiceResponse where T : class
    {
        public T? Value { get; set; }
        public ServiceResponse(T? value = null)
        {
            Value = value;
        }
    }

}
