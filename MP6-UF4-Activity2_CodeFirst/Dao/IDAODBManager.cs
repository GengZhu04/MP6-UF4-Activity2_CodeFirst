﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Dao
{
    public interface IDAODBManager
    {
        // Constant
        public const string CUSTOMER_FILE_PATH = "./Files/CUSTOMERS.csv";
        public const string EMPLOYEES_FILE_PATH = "./Files/EMPLOYEES.csv";
      
        public bool ImportCustomers();
        public bool ImportEmployees();
    }
}
