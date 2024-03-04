using MP6_UF4_Activity2_CodeFirst.Model;
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
        public const string ORDERS_FILE_PATH = "./Files/ORDERS.csv";
        public const string PRODUCTLINES_FILE_PATH = "./Files/PRODUCTLINES.csv";
        public const string PRODUCTS_FILE_PATH = "./Files/PRODUCTS.csv";
        public const string ORDERDETAILS_FILE_PATH = "./Files/ORDERDETAILS.csv";

        // Importations
        public bool ImportPayments();
        public bool ImportCustomers();
        public bool ImportEmployees();
        public bool ImportOffices();
        public bool ImportOrders();
        public bool ImportProductLines();
        public bool ImportProducts();
        public bool ImportOrderDetails();


        public Task<List<Orders>> GetOrdersWithDetails();

        public Task<List<Orders>> GetShippedOrders();

        public Task<List<Products>> GetProductsByScale();

        
        public Task<ICollection<Object>> GetEmployeesOfficesInfo();
    }
}
