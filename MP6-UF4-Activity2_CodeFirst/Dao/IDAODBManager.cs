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
        #region Constant
        
        public const string CUSTOMER_FILE_PATH = "./Files/CUSTOMERS.csv";
        public const string PAYMENTS_FILE_PATH = "./Files/PAYMENTS.csv";
        public const string EMPLOYEES_FILE_PATH = "./Files/EMPLOYEES.csv";
        public const string OFFICES_FILE_PATH = "./Files/OFFICES.csv";
        public const string ORDERS_FILE_PATH = "./Files/ORDERS.csv";
        public const string PRODUCTLINES_FILE_PATH = "./Files/PRODUCTLINES.csv";
        public const string PRODUCTS_FILE_PATH = "./Files/PRODUCTS.csv";
        public const string ORDERDETAILS_FILE_PATH = "./Files/ORDERDETAILS.csv";

        #endregion

        #region Importations

        public bool ImportPayments();
        public bool ImportCustomers();
        public bool ImportEmployees();
        public bool ImportOffices();
        public bool ImportOrders();
        public bool ImportProductLines();
        public bool ImportProducts();
        public bool ImportOrderDetails();


        #endregion

        #region Functions
  
        public Task<List<Orders>> GetOrdersWithDetails();

        public Task<List<Orders>> GetShippedOrders();

        public Task<List<Products>> GetProductsByScale();

        public Task<ICollection<Object>> GetProductsLinesWithProducts();

        public Task<ICollection<Orders>> GetInfoProductsOrders(int customerId);

        public Task<int> CountCustomersByEmployee(int employeeId);

        public Task<ICollection<Customers>> GetCustomersWithFirstNameChar(char firstChar);

        public Task<ICollection<Object>> GetListPaymentsDate();

        public Task<ICollection<Offices>> GetAllOfficeInfo();

        #endregion
    }
}
