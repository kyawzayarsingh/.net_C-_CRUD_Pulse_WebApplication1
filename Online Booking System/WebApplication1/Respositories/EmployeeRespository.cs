using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Data;
using WebApplication1.DTOs.Info;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Respositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly TravelTourDBContext _context;
        private bool _isDisposed = false;

        public EmployeeRespository()
        {
            _context = new TravelTourDBContext();
        }


        public async Task<IList<Info>> GetAllInfoesAsync()
        {
            var infos = await _context.Infos.ToListAsync();
            //IList<InfoResponse> infoResponses = infos.Select(r => new InfoResponse()
            //{
            //    Id = r.Id,
            //    Name = r.Name,
            //    FatherName = r.FatherName

            //}).ToList();

            return infos;
        }

        public async Task<Info> GetInfoByIdAsync(int id)
        {
            if(await _context.Infos.AsNoTracking().AnyAsync(r=> r.Id == id))
            {
                var info = await _context.Infos.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id);
                return info;
            }

            return null;
        }

        public async Task<bool> UpdateInfoByIdAsync(Info info)
        {
            _context.Entry(info).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddInfoAsync(Info info)
        {
           if(info != null)
            {
                _context.Infos.Add(info);
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> DeleteInfoByIdAsync(int id)
        {
            var info = await _context.Infos.FindAsync(id);
            if(info == null)
            {
                return false;
            } else
            {
                _context.Infos.Remove(info);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this._isDisposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }

                this._isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}