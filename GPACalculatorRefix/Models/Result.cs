using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Models
{
   public class Result
    {
        public List<CourseRecordExtended> CourseRecords;
        public string GPA;
        public Result()
        {
            CourseRecords = new List<CourseRecordExtended>();
        }
    }
}
