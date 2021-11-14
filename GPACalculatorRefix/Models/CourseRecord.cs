using GPACalculatorRefix.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Models
{
    public class CourseRecord
    {
        public string Id = Guid.NewGuid().ToString();
        private string _courseName;
        public string CourseName
        {
            get { return Utilities.FirstCharacterToUpper(_courseName); }
            set
            {
                _courseName = Utilities.RemoveDigitFromStart(value.Trim());
                _courseName = Utilities.FirstCharacterToUpper(_courseName);
            }
        }

            public int inputEntryNumber;
            public int CourseUnit;
            public double Score;
        
    }
}
