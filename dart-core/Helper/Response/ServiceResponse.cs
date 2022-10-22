using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core.Helper.Response
{
    public class ServiceResponse : ServiceResponseLogger
    {
        public ServiceResponseStatus ServiceResponseStatus { get; set; } = ServiceResponseStatus.REJECT;
        public ServiceResponseInformation ServiceResponseInformation { get; set; }
        public object? ServiceResponseMessage { get; set; }

        public ServiceResponse(bool enableLogging = false)
        {
            ServiceResponseInformation = new ServiceResponseInformation();
        }
        public ServiceResponse PassResponse(object? message = null)
        {
            ServiceResponseMessage = message;
            ServiceResponseStatus = ServiceResponseStatus.PASS;
            ServiceResponseInformation.ServiceResponseCompletionTimestamp = DateTime.UtcNow;
            ServiceResponseInformation.SetServiceResponseRuntime();
            return this;
        }
        public ServiceResponse RejectResponse(object? message = null)
        {
            ServiceResponseMessage = message;
            ServiceResponseStatus = ServiceResponseStatus.REJECT;
            ServiceResponseInformation.ServiceResponseCompletionTimestamp = DateTime.UtcNow;
            ServiceResponseInformation.SetServiceResponseRuntime();
            return this;
        }
        public ServiceResponse WarnResponse(object? message = null)
        {
            ServiceResponseMessage = message;
            ServiceResponseStatus = ServiceResponseStatus.WARN;
            ServiceResponseInformation.ServiceResponseCompletionTimestamp = DateTime.UtcNow;
            ServiceResponseInformation.SetServiceResponseRuntime();
            return this;
        }
    }

    public class ServiceResponse<TResult> : ServiceResponse
    {
        public ServiceResponse(bool enableLogging = false) : base(enableLogging)
        {
        }

        public TResult? Result { get; set; }
    }
}
