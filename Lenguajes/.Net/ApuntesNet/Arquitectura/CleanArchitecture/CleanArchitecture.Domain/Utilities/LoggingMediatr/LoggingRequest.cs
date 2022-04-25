using MediatR;

namespace CleanArchitecture.Domain.Utilities.LoggingMediatr
{
    public class LoggingRequest : INotification
    {
        public LoggingRequest(object log, LogType tipoLog)
        {
            Log = log;
            TipoLog = tipoLog;
        }

        public object Log { get; set; }
        public LogType TipoLog { get; set; }
    }
}
