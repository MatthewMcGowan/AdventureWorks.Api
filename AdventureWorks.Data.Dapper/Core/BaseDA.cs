using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Core
{
    public class BaseDA
    {
        #region Protected Fields

        protected const string connectionStringKey = "AdventureWorks2012ConnectionString";
        protected IDbConnection cnn;

        #endregion

        #region Constructors

        public BaseDA(IDbConnection connection)
        {
            cnn = connection;
        }

        #endregion
    }
}
