using Newtonsoft.Json;
using NLog;

namespace WebApi.Domain.Services
{
    public class BaseService
    {
        private static  Logger _logger;

        protected NLog.Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetCurrentClassLogger();
                }
                return _logger;
            }
        }
        public ServiceResponse<T> Respond<T>(T data = default)
        {
            return new ServiceResponse<T>()
            {
                Result = data
            };
        }

        protected void LogError<T>(string message, T data)
        {
            Logger.Error("Error: {0}, Data: {1}", message, JsonConvert.SerializeObject(data));
        }

        protected void LogErrorWithException<T>(string message, T data, Exception ex)
        {
            Logger.Error("Error: {0},  Data: {1}, Exception: {2}", message, JsonConvert.SerializeObject(data), ex);
        }

        protected void LogWarningWithData<T>(string message, T data)
        {
            Logger.Warn("Warning: {0},  Data: {1}", message, JsonConvert.SerializeObject(data));
        }
        protected void LogWarning(string message)
        {
            Logger.Warn("Warning: {0}", message);
        }
        protected void LogInfo<T>(string message, T data)
        {
            Logger.Info("Info: {0},  Data: {1}", message, JsonConvert.SerializeObject(data));
        }

        protected void LogDebugMessage(string message)
        {
            Logger.Debug("Debug: {0}", message);
        }
    }
}
