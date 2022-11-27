using ep.Data.Interfaces;
using ep.Data.Persistant;
using ep.Data.Wrappers;
using ep.DataMigration.Models;
using ep.Domain.Models;
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
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<Migration> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _businessFile = "business.csv";

        public Migration(IRepositoryWrapper repository, ILogger<Migration> logger, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task Run()
        {
            _logger.LogInformation($"------- Migration starts ------");
            ConfirmMessage();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var businesses = GetBussinesses();
            await SaveBussiness(businesses);

            stopWatch.Stop();

            var elapsedTime = GetElapsedTime(stopWatch);
            _logger.LogInformation($"----- Migration completed. RunTime: {elapsedTime} ------");
            Environment.Exit(-1);
        }

        private void ConfirmMessage()
        {
            Console.Write("*** Are you sure you want to proceed this? [y/n]", Console.ForegroundColor = ConsoleColor.Red);
            string key = Console.ReadLine() ?? "";
            if (key.ToUpper() != "Y")
            {
                _logger.LogInformation("------ Migration cancled -----");
                Environment.Exit(-1);
            }
        }

        private async Task SaveBussiness(IList<Business> businesses)
        {
            try
            {
                _logger.LogInformation("Saving businesses starts");

                foreach (var business in businesses)
                    await _repository.Business.CreateAsync(business);

                var result = await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"Saving businesss completed. Total: {result} saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error SaveBusiness. mgessage: {ex.Message}");
                throw;
            }
        }

        private static string GetElapsedTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            return elapsedTime;
        }

        private IList<Business> GetBussinesses()
        {
            var records = CsvImporter.ReadCsvFile<BusinessRecord>(_businessFile);
            _logger.LogInformation($"Total Records: {records.Count} from {_businessFile}");

            var businesses = from r in records
                             select new Business
                             {
                                 ABN = r.ABN,
                                 Address = r.Address,
                                 Owner = $"{r.Firstname} {r.Lastname}",
                                 Email = r.Email,
                                 Name = r.BusinessName,
                                 Phone = r.Phone,
                                 Latitude = r.Latitude,
                                 Longitude = r.Longitude,
                             };

            return businesses.ToList();
        }
    }
}
