using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Core
{
    public abstract class BaseDA
    {
        #region Protected Fields

        protected readonly AdventureWorks2012Entities Db;

        #endregion

        #region Constructors

        protected BaseDA()
        {
            // Create new DB context
            Db = new AdventureWorks2012Entities();
        }

        #endregion
    }
}
