using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Logger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarn(string message);
        void LogDebug(string message);
    }
}
