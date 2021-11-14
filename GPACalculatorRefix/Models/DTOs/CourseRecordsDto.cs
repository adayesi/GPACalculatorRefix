using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Models.DTOs
{
    public class CourseRecordsDto
    {
        public List<CourseRecord> CourseRecords { get; set; }


        public CourseRecordsDto()
        {
            CourseRecords = new List<CourseRecord>();
        }
    }
}
