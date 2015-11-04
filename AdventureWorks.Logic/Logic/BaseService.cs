using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Logic
{
    using AdventureWorks.Enumerations;
    using AdventureWorks.Business.Extensions;
    public abstract class BaseService
    {
        #region Private Fields

        protected readonly DataAccessMethodEnum DataAccessMethod;

        #endregion

        #region Constructors

        public BaseService()
        {
            DataAccessMethod = System.Configuration.ConfigurationManager.AppSettings["DataAccessMethod"].ToEnum<DataAccessMethodEnum>();
        }

        #endregion
    }
}
