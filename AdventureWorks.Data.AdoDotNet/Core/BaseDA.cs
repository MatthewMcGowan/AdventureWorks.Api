using AdventureWorks.Data.TableAdapter.dsAdventureWorks2012TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.TableAdapter.Core
{
    using dsAdventureWorks2012TableAdapters;

    public abstract class BaseDA
    {
        #region Protected Fields

        protected EmployeePersonTableAdapter employeeAdapter;

        #endregion
    }
}
