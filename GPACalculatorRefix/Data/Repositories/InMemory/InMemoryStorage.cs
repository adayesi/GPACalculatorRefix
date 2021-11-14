using GPACalculatorRefix.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Data.Repositories.InMemory
{
    public class InMemoryStorage
    {
        public static List<CourseRecord> CourseRecords { get; set; } = new List<CourseRecord>();
    }
}
