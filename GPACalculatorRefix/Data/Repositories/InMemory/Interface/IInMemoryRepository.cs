using GPACalculatorRefix.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Data.Repositories.InMemory.Interface
{
    public interface IInMemoryRepository : ICRUDReository
    {
        Task<List<CourseRecord>> GetCourseRecordsByEntryNumberAsync(int entryNumber);

        //Task<List<CourseRecord>> GetCourseRecordsAsync();
        //Task<CourseRecord> GetCourseRecord(string id);
    }
}
