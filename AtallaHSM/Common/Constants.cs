using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtallaHSM.Common
{
    public struct LogLevel
    {
        public const string FATAL = "FATAL";
        public const string ERROR = "ERROR";
        public const string WARN = "WARN";
        public const string INFO = "INFO";
        public const string DEBUG = "DEBUG";
        public const string TRACE = "TRACE";
    }
    public struct LogPriority
    {
        public const string HIGH = "HIGH";
        public const string MEDIUM = "MEDIUM";
        public const string LOW = "LOW";
    }
    public struct LogSeverity
    {
        public const string ALERT = "ALERT";
    }

}
