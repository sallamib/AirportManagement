using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AM.Applicationcore.Interfaces.IGenericRepository;

namespace AM.Applicationcore.Interfaces;


    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IGenericRepository<T> Repository<T>() where T : class;

    //void Dispose(); // hidden by IDisposable : https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0
}
