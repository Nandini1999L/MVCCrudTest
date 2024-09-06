using CrudOperation.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CrudOperation
{
    public class RegisterService
    {
        private readonly SqlConnection _connectionString;

        public RegisterService()
        {
            _connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["testDB"].ConnectionString);
        }

        public IEnumerable<Employee> GetEmployeeDetails()
        {
            try
            {
                return _connectionString.Query<Employee>("sp_GetEmployeeList", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employee details", ex);
            }
        }

        public string InsertUpdateEmployee(Employee employee)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FirstName", employee.FirstName);
                param.Add("@LastName", employee.LastName);
                param.Add("@Age", employee.Age);
                param.Add("@Gender", employee.Gender);
                param.Add("@Address", employee.Address);
                param.Add("@Phone", employee.Phone);
                param.Add("@Designation", employee.Designation);
                param.Add("@ID", employee.ID);

                string result = _connectionString.Query<string>("sp_InsertUpdateEmployee", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding employees", ex);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", id);
                return _connectionString.Query<Employee>("sp_GetEmployeeById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception("Error by getting employee", ex);
            }

        }

        public string RemoveEmployeeData(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", id);
                return _connectionString.Query<string>("sp_DeleteEmployeeData", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception("Error by getting employee", ex);
            }
        }
    }
}
