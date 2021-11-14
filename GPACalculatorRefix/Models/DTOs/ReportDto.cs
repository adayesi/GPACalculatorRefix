using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculatorRefix.Models.DTOs
{
    public class ReportDto
    {
        public List<Result> Results;

        public ReportDto()
        {
            Results = new List<Result>();
        }
    }
}
