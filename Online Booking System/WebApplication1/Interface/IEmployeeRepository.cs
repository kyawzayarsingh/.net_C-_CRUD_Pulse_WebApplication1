using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DTOs.Info;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IEmployeeRepository : IDisposable
    {
        Task<IList<Info>> GetAllInfoesAsync();
        Task<Info> GetInfoByIdAsync(int id);
        Task<bool> UpdateInfoByIdAsync(Info info);
        Task<bool> AddInfoAsync(Info info);
        Task<bool> DeleteInfoByIdAsync(int id);
    }
}
