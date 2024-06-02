using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common
{
    /// <summary>
    /// Các thể hiện function chung của chương trình
    /// </summary>
    public static class LogCustom
    {
        public static ILogger _logger;

        public static void ConstructorLoger(ILogger logger)
        {
            _logger = logger;
        }
        public static void LogInfo(string mes)
        {
            _logger.Information(mes);
        }

        public static void LogError(string mes)
        {
            _logger.Error(mes);
        }

        public static void LogError(Exception ex, string info)
        {
            _logger.Error($"{info} | {ex.Message}");
        }
        public static void LogDebug(string mes)
        {
            _logger.Debug(mes);
        }
    }
}
