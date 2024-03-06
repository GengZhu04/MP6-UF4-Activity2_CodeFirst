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
  
        public Task<List<Orders>> GetOrdersOrderedByDate();

        public Task<List<Orders>> GetShippedOrdersRecentThan(DateTime date);

        public Task<List<Products>> GetProductsByScale(string scale);

        public Task<ICollection<Object>> GetProductsLinesWithProducts();

        public Task<ICollection<Orders>> GetInfoProductsOrders(int customerId);

        public Task<int> CountCustomersByEmployee(int employeeId);

        public Task<ICollection<Customers>> GetCustomersWithFirstNameChar(char firstChar);

        public Task<ICollection<Object>> GetListPaymentsDate();

        public Task<ICollection<Offices>> GetAllOfficeInfo();

        public Task<ICollection<Object>> GetEmployeesOfficesInfo();

        public Task<bool> DeleteEmployee(int id);

        public Task<bool> UpdateEmployee(int employeeNumber, string employeesName, string employeesLastName, string extent, int? reportTo, string officeCode, string email, string job);
        
        public Task<bool> AddEmployee(string employeesName, string employeesLastName, int? reportTo, string officeCode, string job);

        public Task<int> CountProductsWithProductLine(string productLine);

        public Task<ICollection<Object>> GetAllCustomerID();

        public Task<ICollection<Object>> GetAllEmployeeID();

        public Task<ICollection<Object>> GetAllProductID();

        #endregion

        #region PART 4

        public bool InsertSpecialPrice(int customerNumber, string productCode, decimal specialPrice);

        #endregion

        #region Funcions Interficie

        public Task<List<Employees>> GetAllEmployees();

        #endregion
    }
}
