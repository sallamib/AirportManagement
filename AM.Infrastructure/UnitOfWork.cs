using AM.Applicationcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AM.Applicationcore.Interfaces.IGenericRepository;

namespace AM.Infrastructure;


    public class UnitOfWork : IUnitOfWork
    {
        private readonly AMContext _context;
        private readonly Type _repisitoryType;
        private bool disposedValue; //detect redundant calls

    public UnitOfWork(AMContext context, Type repoType)
        {
            _context = context;
            _repisitoryType = repoType;
        }

    //to be checked 
        public IGenericRepository<T> Repository<T>() where T : class
        {
           // return new GenericRepository<T>(_context);
        return (IGenericRepository<T>)
            Activator.
            CreateInstance(_repisitoryType.MakeGenericType(typeof(T)), _context);
    }

        public int Save()
        {
            return _context.SaveChanges();
        }

    // IDisposable : is a base interface for types that support unmanaged resources. : https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0
    protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true); // intialisation 
            GC.SuppressFinalize(this); //Garbage Collection : https://docs.microsoft.com/en-us/dotnet/api/system.gc.suppressfinalize?view=net-6.0 : Requests that the system not call the finalizer for the specified object.
    }
    }

//Patern Idisposable : is a base interface for types that support unmanaged resources. : https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0
//Pattern unit of work : is to maintain a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
//Pattern Activator : Creates an instance of the specified type using that type's default constructor. : https://docs.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-6.0
//Pattern Generic Repository : is a pattern that allows you to define a common set of methods for performing CRUD operations on a collection of entities, where the entity type is generic.
//Pattern DbSet : Represents a collection of entities that can be queried, deleted, or have their properties updated. : https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-6.0
//Pattern DbSet.Find : Finds an entity with the given primary key values. If an entity with the given primary key values is being tracked by the context, then it is returned immediately without making a request to the database. : https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.find?view=efcore-6.0


