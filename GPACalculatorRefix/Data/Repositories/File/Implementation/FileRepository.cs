using GPACalculatorRefix.Data.Repositories.File.Interface;
using GPACalculatorRefix.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Data.Repositories.File.Implementation
{
    public class FileRepository : IFileRepository
    {
        private readonly string _path;

        public FileRepository(string path)
        {
            _path = path;
        }

        public Task<bool> AddAsync<T>(List<T> entities)
        {
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                foreach (var entity in entities)
                {
                    var record = entity as CourseRecord;
                    var line = "";
                    line += record.CourseName + ",";
                    line += record.CourseUnit + ",";
                    line += record.inputEntryNumber + ",";
                    line += record.Score;

                    sw.WriteLine(line);
                }

                sw.WriteLine(sw.NewLine);

            }

            return Task.Run(() => true);
        }

        public Task<List<CourseRecord>> GetCourseRecordsByEntryNumberAsync(int entryNumber)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                var records = new List<CourseRecord>();

                var result = sr.ReadToEnd();

                var splittedByNewLine = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var item in splittedByNewLine)
                {
                    if (!item.Equals(""))
                    {
                        var splittedItem = item.Split(",");

                        if (Convert.ToInt32(splittedItem[2]) > entryNumber)
                            return Task.Run(() => records);


                        if (splittedItem[2].ToString().Trim().Equals(entryNumber.ToString()))
                        {
                            records.Add(
                                new CourseRecord { CourseName = splittedItem[0], CourseUnit = Convert.ToInt32(splittedItem[1]), Score = Convert.ToInt32(splittedItem[3]) }
                            );
                        }
                    }



                }

                return Task.Run(() => records);

            }
        }

        public Task<HashSet<int>> GetEntryNumbersDistinctAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync<T>(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public int RowCount()
        {
            throw new NotImplementedException();
        }
    }
}
