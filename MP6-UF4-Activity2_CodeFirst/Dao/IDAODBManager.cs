using System;
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
        public const string PAYMENTS_FILE_PATH = "./Files/PAYMENTS.csv";
        public const string EMPLOYEES_FILE_PATH = "./Files/EMPLOYEES.csv";
        public const string OFFICES_FILE_PATH = "./Files/OFFICES.csv";

        // Importations
        public bool ImportPayments();
        public bool ImportCustomers();
        public bool ImportEmployees();
        public bool ImportOffices();
    }
}
