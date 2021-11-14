using GPACalculatorRefix.Data;
using GPACalculatorRefix.Data.Repositories.File.Interface;
using GPACalculatorRefix.Data.Repositories.InMemory.Interface;
using GPACalculatorRefix.Models;
using GPACalculatorRefix.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Services.Implementation
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInMemoryRepository _inMemoryRepo;
        private readonly IFileRepository _fileRepo;
        private readonly List<ICRUDReository> _crudRepo;

        public CalculatorService(IInMemoryRepository inMemoryRepoaitory, IFileRepository fileRepository)
        {
            _inMemoryRepo = inMemoryRepoaitory;
            _fileRepo = fileRepository;
            _crudRepo = new List<ICRUDReository>();
            _crudRepo.Add(fileRepository);
            _crudRepo.Add(inMemoryRepoaitory);
        }

        // calculate quality Point
        private List<CourseRecordExtended> CalculateQualityPoint(List<CourseRecordExtended> records)
        {
            if (records == null)
                throw new Exception("Null entry for list of records in CalculateQualityPoint - method");

            foreach (var record in records)
            {
                record.QualityPoint = record.CourseUnit * record.GradeUnit;
            }
            return records;
        }


        // calucluate GPA
        public Result CalculateGPA(List<CourseRecord> records, string mode)
        {
            if (records.Equals(null))
                throw new Exception("Null entry for list of records in CalculateGPA - method");

            double totalQualityPoint = 0;
            double totalCourseUnit = 0;

            // store the new record entry
            var resultSucceded = false;
            if (mode.Equals("add"))
                resultSucceded = this.SaveRecordsAsync(records).Result;

            // Grade score
            var gradedResult = GradeRecords(records);

            // calculate Quality Point
            var calculatedQP = CalculateQualityPoint(gradedResult);


            foreach (var record in calculatedQP)
            {
                totalQualityPoint += record.QualityPoint;
                totalCourseUnit += record.CourseUnit;
            }

            var gpa = totalQualityPoint / totalCourseUnit;


            var rs = new Result
            {
                CourseRecords = calculatedQP,
                GPA = gpa.ToString("F")
            };

            return rs;
        }



        // grade score
        public List<CourseRecordExtended> GradeRecords(List<CourseRecord> records)
        {
            if (records.Equals(null))
                throw new Exception("Null entry for list of records in GetGrade - method");

            var gradeSystem = GradeSystem.Grades;
            var found = false;

            var extendedRecord = new List<CourseRecordExtended>();

            foreach (var r in records)
            {
                extendedRecord.Add(
                    new CourseRecordExtended { CourseName = r.CourseName, CourseUnit = r.CourseUnit, Score = r.Score }
                );
            }

            foreach (var record in extendedRecord)
            {
                for (int i = 0; i < gradeSystem.Count; i++)
                {
                    if (record.Score >= gradeSystem[i].MinScore && record.Score <= gradeSystem[i].MaxScore)
                    {
                        record.Grade = gradeSystem[i].Grade;
                        record.GradeUnit = gradeSystem[i].GradePoint;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    throw new Exception("No matching grade found for " + record.Score);
                }

            }

            return extendedRecord;

        }



        // grade student
        public Result GetResult(int entryNumber)
        {
            if (entryNumber < 1)
                throw new Exception("Null entry for list of records in GetResult - method");

            // get records to be graded from repository
            var records = _fileRepo.GetCourseRecordsByEntryNumberAsync(entryNumber).Result;


            return CalculateGPA(records, "read");

        }



        private async Task<bool> SaveRecordsAsync(List<CourseRecord> records)
        {

            if (records.Equals(null))
                throw new Exception("Null entry for list of records in SaveRecord - method");

            // add to both repositories
            foreach (var repo in _crudRepo)
            {
                await repo.AddAsync(records);
            }


            return true;

        }



        public async Task<bool> DeleteRecordsAsync(int entryNumber)
        {
            if (entryNumber < 1)
                throw new Exception("Invalid entry number for records in DeleteRecords - method");

            var records = await _inMemoryRepo.GetCourseRecordsByEntryNumberAsync(entryNumber);

            foreach (var repo in _crudRepo)
            {
                await repo.RemoveAsync(records);
            }

            return true;
        }


    }
}
