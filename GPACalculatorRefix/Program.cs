using GPACalculatorRefix.Models.DTOs;
using GPACalculatorRefix.Services;
using GPACalculatorRefix.UI;
using System;

namespace GPACalculatorRefix
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate the GlobalConfig
            GlobalConfig.Instantiate();

            DisplayWelcomeMessage();
            int inputEntry;
            try
            {
                inputEntry = (GlobalConfig._inMemoryRepository.RowCount() + 1);
            }
            catch { inputEntry = 1; }

            Console.WriteLine($"Entry number: {inputEntry}\n");
            int option = GetUserChoiceOfOption();

            try
            {
                if (option < 1 || option > 4)
                    throw new Exception("Invalid entry operation choice!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // options pipline flow
            switch (option)
            {
                case 1:

                    try
                    {
                        var calc = new CalculatorForm(GlobalConfig._calculatorService);
                        var res = calc.CacluateGPA(inputEntry, "add");
                        var report = new ReportDto();
                        report.Results.Add(res);

                        // print result
                        DisplayWelcomeMessage();
                        ReportForm.Print(report);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 2:
                    try
                    {
                        var calc = new ReportForm(GlobalConfig._calculatorService);
                        Console.WriteLine("Enter the entry number of the desired record you want...");
                        var entryNum = int.Parse(Console.ReadLine());
                        calc.ViewDetails(entryNum);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3:

                    break;

                case 4:

                    break;
            }



        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Todays date: " + DateTime.Now.ToShortDateString());
            Console.WriteLine("\n");
        }

        static int GetUserChoiceOfOption()
        {
            Console.WriteLine("What would you like to use the GPA Calculator for today?");
            Console.WriteLine("\n");
            Console.WriteLine("PRESS 1 To Calculate GPA");
            Console.WriteLine("PRESS 2 To View result by entry number");
            Console.WriteLine("PRESS 3 To View all results");
            Console.WriteLine("PRESS 4 To Delete result by entry number");

            Console.WriteLine("\n");

            int choice = int.Parse(Console.ReadLine());

            return choice;
        }


    }
}
