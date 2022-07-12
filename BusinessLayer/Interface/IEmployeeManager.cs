﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeManager
    {
        public string AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public string UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int? id);
    }
}
