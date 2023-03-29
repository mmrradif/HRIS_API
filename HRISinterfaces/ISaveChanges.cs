using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces
{
    public interface ISaveChanges:IDisposable
    {
        Task CompleteAsync();
    }
}
