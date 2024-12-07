using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static AM.Applicationcore.Interfaces.IGenericRepository;

namespace AM.Infrastructure;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AMContext _context;
        private readonly DbSet<T> _dbset; //intermidiate variable to store the dbset 
    //will be filled by the context



    //why we have not do dependency injection for the context? : because we are not using the context in the constructor
    public GenericRepository(AMContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            _dbset.RemoveRange(_dbset.Where(where));
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            //return _dbset.FirstOrDefault(where);
            return _dbset.Where(where).FirstOrDefault(); //FirstOrDefault() is used to return the first element of a sequence or a default value if the sequence contains no elements.
    }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public T GetById(params object[] keyValues)
        {
            return _dbset.Find(keyValues);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }

//functionality of Patternes and Practices : is to provide a set of guidelines, best practices, and recommendations that help development teams to build better software

//Generic repository : 

