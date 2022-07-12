using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository EmployeeRepository;
        public EmployeeManager(IEmployeeRepository EmployeeRepository)
        {
            this.EmployeeRepository = EmployeeRepository;
        }

        public string AddEmployee(EmployeeModel employee)
        {
            try
            {
                return EmployeeRepository.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return EmployeeRepository.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return EmployeeRepository.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                return EmployeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                return EmployeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
