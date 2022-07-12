using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // To add New Employee Record
        public string AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.Salary);
                cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@notes", employee.Notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return "Employee Added Successfully";
                }
                else
                {
                    return "Employee Added Unsuccessfull";
                }
            }
        }

        // To View All Employee Details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.ProfileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.Salary = Convert.ToInt32(rdr["salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.Notes = Convert.ToString(rdr["notes"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        // Get details of a particular employee
        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel employee = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                string sqlQuery = "SELECT * FROM employee_payroll WHERE EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.ProfileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.Salary = Convert.ToInt32(rdr["salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.Notes = Convert.ToString(rdr["notes"]);
                }
            }
            return employee;
        }

        // Delete Employee
        public string DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return " Employee Deleted Successfully";
                }
                else
                {
                    return null;
                }
            }
        }

        // To Update New Employee Record
        public string UpdateEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.Salary);
                cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@notes", employee.Notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return "Employee Updated Successfully";
                }
                else
                {
                    return " Employee Update Unsuccessfull";
                }
            }
        }
    }
}
