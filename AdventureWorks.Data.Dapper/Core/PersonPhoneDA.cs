using AdventureWorks.Data.Dapper.Extensions;
using AdventureWorks.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Core
{
    public class PersonPhoneDA : BaseDA, IPersonPhoneDA
    {
        #region Constructors

        public PersonPhoneDA(IDbConnection connection) : base(connection)
        {
        }

        public PersonPhoneDA() : base(new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString))
        {
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.PersonPhone> GetEmployeePersonPhonesByBusinessEntityId(int id)
        {
            // SQL query for phone numbers for a particular employee
            string query = "SELECT e.BusinessEntityID, p.PhoneNumber, p.PhoneNumberTypeID "
                + "FROM HumanResources.Employee AS e INNER JOIN Person.PersonPhone AS p ON e.BusinessEntityID = p.BusinessEntityID "
                + "WHERE e.BusinessEntityID = @BusinessEntityID";

            // Return queried objects in list
            return cnn.Query<BusinessObjects.PersonPhone>(query, new { BusinessEntityID = id }).ToList();
        }

        public Task<BusinessObjects.PersonPhone> GetPhoneNumberAsync(int businessEntityId, string phoneNumber, int phoneNumberType)
        {
            // SQL to get a particular phone number
            // Being an employee is not a requirement for this
            string query = "SELECT BusinessEntityId, PhoneNumber, PhoneNumberTypeID FROM Person.PersonPhone "
                + "WHERE BusinessEntityID = @BusinessEntityID AND PhoneNumber = @PhoneNumber AND PhoneNumberTypeID = @PhoneNumberType";

            // Return object if found
            return Task.Run(() => 
                cnn.Query<BusinessObjects.PersonPhone>(
                    query, 
                    new { BusinessEntityID = businessEntityId, PhoneNumber = phoneNumber, PhoneNumberType = phoneNumberType })
                .FirstOrDefault());
        }

        public void AddPhoneNumber(BusinessObjects.PersonPhone phoneNumber)
        {
            // SQL query adding new row to Person.PersonPhone
            string query = "INSERT INTO Person.PersonPhone (BusinessEntityID, PhoneNumber, PhoneNumberTypeID) "
                + "VALUES (@BusinessEntityID, @PhoneNumber, @PhoneNumberTypeID)";

            // Execute query
            cnn.Execute(query, phoneNumber.MapToParams());
        }

        public void DeletePhoneNumber(BusinessObjects.PersonPhone phoneNumber)
        {
            // SQL query deleting row from Person.PersonPhone
            string query = "DELETE FROM Person.PersonPhone "
                + "WHERE BusinessEntityID = @BusinessEntityID AND PhoneNumber = @PhoneNumber AND PhoneNumberTypeID = @PhoneNumberTypeID";

            // Execute query
            cnn.Execute(query, phoneNumber.MapToParams());
        }

        #endregion
    }
}
