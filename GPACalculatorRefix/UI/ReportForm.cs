using GPACalculatorRefix.Commons;
using GPACalculatorRefix.Models.DTOs;
using GPACalculatorRefix.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.UI
{
    public class ReportForm
    {
        private readonly ICalculatorService _calcService;

        public ReportForm(ICalculatorService calculatorService)
        {
            _calcService = calculatorService;
        }


        public void ViewDetails(int entryNumber)
        {
            if (entryNumber < 1)
                entryNumber = 1;

            var res = _calcService.GetResult(entryNumber);
            var report = new ReportDto();
            report.Results.Add(res);
            Print(report);
        }


        public static void Print(ReportDto report)
        {

            if (report.Equals(null))
                throw new Exception("Report is enpty!");

            int widthOfTable = 85;
            Console.Clear();

            Utilities.PrintLine(widthOfTable);
            Utilities.PrintRow(widthOfTable, "COURSE NAME", "COURSE UNIT", "SCORE", "GRADE", "GRADE POINT", "QUALITY POINT");
            Utilities.PrintLine(widthOfTable);

            foreach (var RP in report.Results)
            {
                foreach (var record in RP.CourseRecords)
                {

                    Utilities.PrintRow(widthOfTable, record.CourseName, record.CourseUnit.ToString(),
                        record.Score.ToString(), record.Grade.ToString(), record.GradeUnit.ToString(), record.QualityPoint.ToString());
                }
            }

            Utilities.PrintLine(widthOfTable);

            Console.WriteLine($"Your GPA is: " + report.Results[0].GPA);

            Console.WriteLine($"\nGPA is calculated using the formula: ");
            Console.WriteLine("GPA = (total QP) / (total course units)");

            Console.ReadLine();
        }
    }
}
