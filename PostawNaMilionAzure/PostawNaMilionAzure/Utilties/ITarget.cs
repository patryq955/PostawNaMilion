using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostawNaMilionAzure.Utilties
{
    public interface ITarget
    {
        TDo GetItem<T, TDo>(T _vM)
                    where TDo : class, new()
                    where T : class;
    }
}
