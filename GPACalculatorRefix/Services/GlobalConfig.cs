using GPACalculatorRefix.Commons;
using GPACalculatorRefix.Data.Repositories.File.Implementation;
using GPACalculatorRefix.Data.Repositories.File.Interface;
using GPACalculatorRefix.Data.Repositories.InMemory.Implementations;
using GPACalculatorRefix.Data.Repositories.InMemory.Interface;
using GPACalculatorRefix.Services.Implementation;
using GPACalculatorRefix.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Services
{
    public static class GlobalConfig
    {
        public static ICalculatorService _calculatorService;
        public static IInMemoryRepository _inMemoryRepository;
        public static IFileRepository _fileRepository { get; set; }

        public static string _path = Utilities.GetApsolutePath("Courses.txt");


        public static void Instantiate()
        {
            _inMemoryRepository = new InMemoryRepository();
            _fileRepository = new FileRepository(_path);

            //------------------- Services taking injections ---------------------

            _calculatorService = new CalculatorService(_inMemoryRepository, _fileRepository);
        }
    }
}
