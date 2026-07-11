using DenounceBeasts.Domain.Core;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Infraestructure.Core
{
    public class GenericRepository<T> where T: BaseEntity
    {

        readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
         
        public IEnumerable<T> GetAll()
        {
            var entities = _context.Set<T>().ToList();
            return entities;
        }
          
        public T GetById(int id)
        {
            var entity = _context.Set<T>()
                .FirstOrDefault(m => m.Id == id);

            return entity;
        }



        public int Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
         
        public void Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(m => m.Id == id);

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


    }
}
