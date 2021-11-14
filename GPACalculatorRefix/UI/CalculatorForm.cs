using GPACalculatorRefix.Models;
using GPACalculatorRefix.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.UI
{
    public class CalculatorForm
    {
        private readonly ICalculatorService _calcService;

        public CalculatorForm(ICalculatorService calculatorService)
        {
            _calcService = calculatorService;
        }

        public Result CacluateGPA(int inputEntry, string mode)
        {
            Console.Write("\nEnter number of courses: ");
            var numberOfCourses = int.Parse(Console.ReadLine());

            var listOfRecords = new List<CourseRecord>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                Console.Write($"\n\n({i + 1}) Enter course name eg(Maths-101): ");
                var courseName = Console.ReadLine();

                Console.Write("\nEnter course unit: ");
                var courseUnit = int.Parse(Console.ReadLine());

                Console.Write("\nEnter score: ");
                var score = int.Parse(Console.ReadLine());

                listOfRecords.Add(new CourseRecord
                {
                    CourseName = courseName,
                    inputEntryNumber = inputEntry,
                    CourseUnit = courseUnit,
                    Score = score
                });
            }

            return _calcService.CalculateGPA(listOfRecords, mode);
        }

    }
}
