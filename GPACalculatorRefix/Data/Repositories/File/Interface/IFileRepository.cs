using GPACalculatorRefix.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Data.Repositories.File.Interface
{
    public interface IFileRepository : ICRUDReository
    {
        Task<List<CourseRecord>> GetCourseRecordsByEntryNumberAsync(int entryNumber);
    }
}
