using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Logic
{
    using AdventureWorks.Enumerations;
    using AdventureWorks.Extensions;
    public abstract class BaseService
    {
        #region Private Fields

        protected readonly DataAccessMethodEnum DataAccessMethod;

        #endregion

        #region Constructors

        protected BaseService()
        {
            try
            {
                DataAccessMethod = System.Configuration.ConfigurationManager.AppSettings["DataAccessMethod"].ToEnum<DataAccessMethodEnum>();
            }
            catch(Exception e)
            {
                throw new Exception("Data access method configured incorrectly in config.", e);
            }
        }

        #endregion

        #region Public Properties

        protected int DataMethod
        {
            get
            {
                // Readability/succinctness
                return (int)DataAccessMethod;
            }
        }

        #endregion
    }
}
