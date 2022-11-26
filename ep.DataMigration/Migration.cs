using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.DataMigration
{
    public class Migration
    {
        private readonly ILogger<Migration> _logger;
        
        public Migration(ILogger<Migration> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation($"------- Migration starts ------");

            Console.Write("Are you sure you want to proceed this? [y/n]", Console.ForegroundColor = ConsoleColor.Yellow);
            string key = Console.ReadLine() ?? "";
            if (key.ToUpper() != "Y")
            {
                _logger.LogInformation("------ Migration cancled -----");
                Environment.Exit(-1);
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

         

            stopWatch.Stop();

            var elapsedTime = GetElapsedTime(stopWatch);
            _logger.LogInformation($"----- Migration completed. RunTime: {elapsedTime} ------");
            Environment.Exit(-1);
        }

        private string GetElapsedTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return elapsedTime;
        }
    }
}
