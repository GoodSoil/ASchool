using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ASchoolSystem.DAL
{
    public interface IDataContextProvider
    {
        IDataContext Instance();
        IDataContext Instance(string connectionStringName);
    }
}
