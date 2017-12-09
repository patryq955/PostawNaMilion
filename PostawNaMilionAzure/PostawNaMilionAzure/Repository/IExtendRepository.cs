using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostawNaMilionAzure.Repository
{
    public interface IExtendRepository<T> : IRepository<T> where  T : class
    {
        IEnumerable<T> GetOverviewAll(Func<T, bool> predicate = null);
        T GetIdAll(int id);
    }
}
