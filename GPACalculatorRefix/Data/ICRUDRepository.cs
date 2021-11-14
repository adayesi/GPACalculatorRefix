using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorRefix.Data
{
    public interface ICRUDReository
    {
        Task<bool> AddAsync<T>(List<T> entities);
        Task<bool> RemoveAsync<T>(List<T> entities);
        int RowCount();
        Task<HashSet<int>> GetEntryNumbersDistinctAsync();
    }
}
