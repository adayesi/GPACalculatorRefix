using GPACalculatorRefix.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Services.Interface
{
    public interface ICalculatorService
    {
        public Result CalculateGPA(List<CourseRecord> records, string mode);
        public List<CourseRecordExtended> GradeRecords(List<CourseRecord> records);
        public Result GetResult(int entryNumber);

        public Task<bool> DeleteRecordsAsync(int entryNumber);

        //public bool DeleteRecord(string id);
        //public List<CourseRecord> GetAllRecords();
        //public List<CourseRecord> GetRecords(int entryNumber);
    }
}
