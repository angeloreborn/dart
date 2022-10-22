using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core.Helper.Response
{
    public class ServiceResponseInformation
    {
        public ServiceResponseInformation()
        {
            ServiceResponseDiagnostics.Start();
        }
        public ServiceResponseDiagnostics ServiceResponseDiagnostics = new ServiceResponseDiagnostics();
        public DateTime ServiceResponseInitiationTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime ServiceResponseCompletionTimestamp { get; set; }
        public RunTime ServiceResponseTimestampRunTime { get; set; }
        public RunTime ServiceResponseClockRunTime { get; set; }
        public void SetServiceResponseRuntime() 
        {
            TimeSpan timestampRunTimeSpan = ServiceResponseCompletionTimestamp - ServiceResponseInitiationTimestamp;
            
            ServiceResponseTimestampRunTime = new RunTime
            {
                Nanoseconds = timestampRunTimeSpan.TotalNanoseconds,
                Milliseconds = timestampRunTimeSpan.TotalNanoseconds / 1000000,
                Seconds = timestampRunTimeSpan.TotalNanoseconds / 1000000000
            };

            TimeSpan clockRunTimeSpan = ServiceResponseDiagnostics.Elapsed;
            ServiceResponseClockRunTime = new RunTime
            {
                Nanoseconds = clockRunTimeSpan.TotalNanoseconds,
                Milliseconds = clockRunTimeSpan.TotalNanoseconds / 1000000,
                Seconds = clockRunTimeSpan.TotalNanoseconds / 1000000000
            };

            ServiceResponseDiagnostics.Stop();
        }
    }

    public struct RunTime
    {
        public double Nanoseconds { get; set; }
        public double Milliseconds { get; set; }
        public double Seconds { get; set; }
    }
}
