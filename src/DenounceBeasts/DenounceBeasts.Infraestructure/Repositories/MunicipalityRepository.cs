using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using DenounceBeasts.Infraestructure.Core;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    public class MunicipalityRepository: GenericRepository<Municipality>
    {

        readonly DataContext _context;

        public MunicipalityRepository(DataContext context): base(context)
        {
            _context = context;
        }
          
        public IEnumerable<Municipality> GetAllWithSectors()
        {
            var _municipalities = _context.Municipalities.Include(s => s.Sectors)
                .ToList();

            return _municipalities;
        }
         
        public void Update(int id, Municipality request)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);

            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;

            _context.Municipalities.Update(existing);
            _context.SaveChanges();
        }
         
    }
}
