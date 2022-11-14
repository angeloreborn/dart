using System.Runtime.CompilerServices;

namespace dart_core_api.Helper
{
    public class Error : Exception
    {
        public int LineNumber { get; set; }
        public string? Call { get; set; }
        public string CustomMessage { get; set; }
        public Error(string Message, [CallerLineNumber] int LineNumber = 0, [CallerMemberName] string? Call = null) : base(Message)
        {
            this.CustomMessage = Message;
            this.LineNumber = LineNumber;
            this.Call = Call;
        }
    }
}
