using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Core
{
    using AdventureWorks.Data.Interfaces;
    using global::Dapper;
    using System.Data;
    using Extensions;
    using System.Data.SqlClient;
    using System.Configuration;

    public class EmployeeDA : BaseDA, IEmployeeDA
    {
        #region Constructors

        public EmployeeDA(IDbConnection connection) : base(connection)
        {
        }

        public EmployeeDA() : this(new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString))
        {
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetAllEmployees()
        {
            // SQL query
            string query = "SELECT e.BusinessEntityId, p.FirstName, p.MiddleName, p.LastName, e.JobTitle "
                + "FROM HumanResources.Employee AS e INNER JOIN Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID";

            // Query the DB , map to Employee BOs
            return cnn.Query<BusinessObjects.Employee>(query).ToList();
        }

        public BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id)
        {
            // Parameterised SQL query
            string query = "SELECT e.BusinessEntityId, p.FirstName, p.MiddleName, p.LastName, e.JobTitle "
                + "FROM HumanResources.Employee AS e INNER JOIN Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID "
                + "WHERE e.BusinessEntityID = @BusinessEntityID";

            // Query the DB for Id, map to Employee BO, get first (we're filtering on unique primary key)
            var employee = cnn.Query<BusinessObjects.Employee>(query, new { BusinessEntityID = id }).FirstOrDefault();

            // Return employee BO, null if none found
            return employee;
        }

        public Task<BusinessObjects.Employee> GetEmployeeByBusinessEntityIdAsync(int id)
        {
            // Parameterised SQL query
            string query = "SELECT e.BusinessEntityId, p.FirstName, p.MiddleName, p.LastName, e.JobTitle "
                + "FROM HumanResources.Employee AS e INNER JOIN Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID "
                + "WHERE e.BusinessEntityID = @BusinessEntityID";

            // Query the DB for Id, map to Employee BO, get first (we're filtering on unique primary key)
            return Task.Run(() => cnn.Query<BusinessObjects.Employee>(query, new { BusinessEntityID = id }).FirstOrDefault());
        }

        public void UpdateEmployee(BusinessObjects.Employee employee)
        {
            // Paramaterised SQL query, update both tables
            string query = "UPDATE HumanResources.Employee SET JobTitle = @JobTitle WHERE BusinessEntityID = @BusinessEntityID; "
                + "UPDATE Person.Person SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName WHERE BusinessEntityID = @BusinessEntityID";

            // Send SQL to DB
            int rowsAffected = cnn.Execute(query, employee.MapToParams());
        }

        #endregion
    }
}
