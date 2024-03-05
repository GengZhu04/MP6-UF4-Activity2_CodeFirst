
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic.FileIO;
using MP6_UF4_Activity2_CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MP6_UF4_Activity2_CodeFirst.Dao
{
    public class DAODBManager : IDAODBManager
    {
        private CompanyDBContext companyDBContext;

        public DAODBManager(CompanyDBContext companyDBContext) 
        {
            this.companyDBContext = companyDBContext;
        }

        #region Imports

        public bool ImportCustomers()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.CUSTOMER_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        int customerNumber = Convert.ToInt32(fields[0]);
                        string customerName = fields[1];
                        string contactLastName = fields[2];
                        string contactFirstName = fields[3];
                        string phone = fields[4];
                        string addressLine1 = fields[5];
                        string addressLine2 = fields[6];
                        string city = fields[7];
                        string state = fields[8];
                        string postalCode = fields[9];
                        string country = fields[10];
                        int? salesRepEmployeeNumber = fields[11].ToLower().Equals("null") ? null : Convert.ToInt32(fields[11]);
                        decimal? creditLimit = fields[12].ToLower().Equals("null") ? null: Convert.ToDecimal(fields[12]);

                        var newCustomer = new Customers()
                        {
                            CustomerNumber = customerNumber,
                            CustomerName = customerName,
                            ContactLastName = contactLastName,
                            ContactFirstName = contactFirstName,
                            Phone = phone,
                            AddressLine1 = addressLine1,
                            AddressLine2 = addressLine2,
                            City = city,
                            State = state,
                            Country = country,
                            SalesRepEmployeeNumber = salesRepEmployeeNumber,
                            CreditLimit = creditLimit
                        };

                        companyDBContext.Customers.Add(newCustomer);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newCustomer);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        public bool ImportEmployees()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.EMPLOYEES_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        int employeeNumber = Convert.ToInt32(fields[0].ToLower().Equals("null") ? "0" : fields[0]);
                        string lastName = fields[1];
                        string firstName = fields[2];
                        string extension = fields[3];
                        string email = fields[4];
                        string officeCode = fields[5];
                        int? reportsTo = fields[6].ToLower().Equals("null") ? null : Convert.ToInt32(fields[6]);
                        string jobTitle = fields[7];

                        var newEmployee = new Employees()
                        {
                            EmployeeNumber = employeeNumber,
                            LastName = lastName,
                            FirstName = firstName,
                            Extension = extension,
                            Email = email,
                            OfficeCode = officeCode,
                            ReportsTo = reportsTo,
                            JobTitle = jobTitle
                           
                        };

                        companyDBContext.Employees.Add(newEmployee);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch(Exception exc)
                        {
                            companyDBContext.Remove(newEmployee);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }
        
        public bool ImportOffices()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.OFFICES_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        string officeCode = fields[0];
                        string? city = fields[1];
                        string? phone = fields[2];
                        string? addressLine1 = fields[3];
                        string? addressLine2 = fields[4];
                        string? state = fields[5];
                        string? country = fields[6];
                        string? postalCode = fields[7];
                        string? territory = fields[8];


                        var newOffices = new Offices()
                        {
                            OfficeCode = officeCode,
                            City = city,
                            Phone = phone,
                            AddressLine1 = addressLine1,
                            AddressLine2 = addressLine2,
                            State = state,
                            Country = country,
                            PostalCode = postalCode,
                            Territory = territory
                        };

                        companyDBContext.Offices.Add(newOffices);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newOffices);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        public bool ImportPayments()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.PAYMENTS_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        int customerNumber = Convert.ToInt32(fields[0].ToLower().Equals("null") ? "0" : fields[0]);
                        string checkNumber = fields[1];
                        DateTime paymentDate;
                        DateTime.TryParse(fields[2], out paymentDate);
                        decimal amount = Convert.ToDecimal(fields[3].ToLower().Equals("null") ? "0" : fields[3]);

                        var newPayment = new Payments()
                        {
                            CustomerNumber = customerNumber,
                            CheckNumber = checkNumber,
                            PaymentDate = paymentDate,
                            Amount = amount
                        };

                        companyDBContext.Payments.Add(newPayment);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newPayment);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        public bool ImportOrders()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.ORDERS_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(fields[0]);
                        DateTime orderDate, requiredDate, shippedDate;
                        DateTime.TryParse(fields[1], out orderDate);
                        DateTime.TryParse(fields[2], out requiredDate);
                        DateTime.TryParse(fields[3], out shippedDate);
                        string status = fields[4];
                        string comments = fields[5];
                        int? customerNumber = fields[6].ToLower().Equals("null") ? null :Convert.ToInt32(fields[6]);

                        var newOrder = new Orders()
                        {
                            OrderNumber = orderNumber,
                            OrderData = orderDate,
                            RequiredDate = requiredDate,
                            ShippedDate = shippedDate,
                            Status = status,
                            Comments = comments,
                            CustomerNumberId = customerNumber,
                        };

                        companyDBContext.Orders.Add(newOrder);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newOrder);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }
        
        public bool ImportProductLines()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.PRODUCTLINES_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        string productLine = fields[0];
                        string textDescription = fields[1];
                        string? htmlDescription = fields[2];
                        byte[]? image = fields[3].ToLower().Equals("null") ? null : Convert.FromBase64String(fields[3]);


                        var newProductLine = new ProductLines()
                        {
                            ProductLine = productLine,
                            TextDescription = textDescription,
                            HtmlDescription = htmlDescription,
                            Imatge = image
                        };

                        companyDBContext.ProductLines.Add(newProductLine);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newProductLine);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        public bool ImportProducts()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.PRODUCTS_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        string productCode = fields[0];
                        string productName = fields[1];
                        string productLineId = fields[2];
                        string productScale = fields[3];
                        string productVendor = fields[4];
                        string productDescription = fields[5];
                        short quantityInStock = Convert.ToInt16(fields[6]);
                        decimal buyPrice = Convert.ToDecimal(fields[7]);
                        decimal mSRP = Convert.ToDecimal(fields[8]);




                        var newProduct = new Products()
                        {
                            ProductCode = productCode,
                            ProductName = productName,
                            ProductLineId = productLineId,
                            ProductScale = productScale,
                            ProductVendor = productVendor,
                            ProductDescription = productDescription,
                            QuantityInStock = quantityInStock,
                            BuyPrice = buyPrice,
                            MSRP = mSRP
                        };

                        companyDBContext.Products.Add(newProduct);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newProduct);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }
        
        public bool ImportOrderDetails()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(IDAODBManager.ORDERDETAILS_FILE_PATH))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(fields[0]);
                        string productCode = fields[1];
                        int qtyOrdered = Convert.ToInt32(fields[2]);
                        decimal priceEach = Convert.ToDecimal(fields[3]);
                        short orderLineNumber = Convert.ToInt16(fields[4]);

                        var newOrderDetails = new OrderDetails()
                        {
                            OrderNumber = orderNumber,
                            ProductCode = productCode,
                            QuantityOrdered = qtyOrdered,
                            PriceEach = priceEach,
                            OrderLineNumber = orderLineNumber
                        };

                        companyDBContext.OrderDetails.Add(newOrderDetails);
                        try
                        {
                            companyDBContext.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            companyDBContext.Remove(newOrderDetails);
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        #endregion

        #region Functions
        
        public async Task<List<Orders>> GetOrdersWithDetails()
        {
            return await companyDBContext.Orders
                .OrderBy(o => o.OrderDetails)
                .ToListAsync();
        }
        
        public async Task<List<Orders>> GetShippedOrders()
        {
            return await companyDBContext.Orders
                .Where(o => o.Status == "Shipped" && o.ShippedDate > new DateTime(2005, 1, 10))
                .ToListAsync();
        }
        public async Task<List<Products>> GetProductsByScale()
        {
            return await companyDBContext.Products
                .Where(p => p.ProductScale == "1:10")
                .OrderBy(p => p.ProductCode)
                .ToListAsync();
        }

        // Join ProductLines with Products and order ascending with ProductVendor
        public async Task<ICollection<Object>> GetProductsLinesWithProducts()
        {
            var productLines = companyDBContext.ProductLines
                .Join(companyDBContext.Products,
                pL => pL.ProductLine,
                p => p.ProductLineId,
                (productLine, product) => new
                {
                    ProductName = product.ProductName,
                    ProdictDescription = product.ProductDescription,
                    QuantityStock = product.QuantityInStock,
                    BuyPrice = product.BuyPrice,
                    TextDescription = productLine.TextDescription,
                    ProductVendor = product.ProductVendor
                })
                .OrderBy(pL => pL.ProductVendor)
                .ToArray();
            return productLines;
        }

        // Join orders with order details with product where customer id  order descending with date
        public async Task<ICollection<Orders>> GetInfoProductsOrders(int customerId)
        {
            var orderDetails = companyDBContext.Orders
                .Where(o => o.CustomerNumberId == customerId)
                .Include(o => o.OrderDetails)
                .ThenInclude(oD => oD.Product)
                .OrderByDescending(o => o.OrderData)
                .ToListAsync();
            return await orderDetails;
        }

        // Count Total Customers By Employee
        public async Task<int> CountCustomersByEmployee(int employeeId)
        {
            var totalCustomers = companyDBContext.Employees
                .Where(e => e.EmployeeNumber == employeeId)
                .SelectMany(e => e.Customers)
                .CountAsync();
            return await totalCustomers;
        }

        // Get Customers By the firstname character
        public async Task<ICollection<Customers>> GetCustomersWithFirstNameChar(char firstChar)
        {
            var customers = companyDBContext.Customers
                .Where(e => e.ContactFirstName.StartsWith(firstChar.ToString()))
                .ToListAsync();
            return await customers;
        }

        // Get List Count For All DatePayment
        public async Task<ICollection<Object>> GetListPaymentsDate()
        {
            var listCountPayments = companyDBContext.Payments
                .GroupBy(p => p.PaymentDate)
                .Select(group => new
                {
                    PaymentDate = group.Key,
                    CountPayments = group.Count()
                })
                .ToArray();
            return listCountPayments;
        }

        // Join Office With employees With Customers With Payments And Ordered by State Ascending
        public async Task<ICollection<Offices>> GetAllOfficeInfo()
        {
            var officeInfo = companyDBContext.Offices
                .Include(o => o.Employees)
                .ThenInclude(e => e.Customers)
                .ThenInclude(c => c.Payments)
                .OrderBy(o => o.State)
                .ToListAsync();
            return await officeInfo;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool done = false;
            try
            {

                var emplDelete = companyDBContext.Employees.FirstOrDefault(e => e.EmployeeNumber == id);
                if (emplDelete != null)
                {
                    companyDBContext.Employees.Remove(emplDelete);
                    await companyDBContext.SaveChangesAsync();
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return done;
        }

        public async Task<bool> UpdateEmployee(int employeeNumber, string employeesName, string employeesLastName, string extent, int? reportTo, string officeCode, string email, string job)
        {
            bool done = false;
            try
            {
                Random random = new Random();

                var maxIdEmpl = companyDBContext.Employees
                    .OrderByDescending(e => e.EmployeeNumber)
                    .Select(e => e.EmployeeNumber)
                    .FirstOrDefault();

                var emplUpdate = companyDBContext.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
                if (emplUpdate != null)
                {

                    emplUpdate.FirstName = employeesName;

                    emplUpdate.LastName = employeesLastName;

                    emplUpdate.Extension = extent;

                    emplUpdate.ReportsTo = reportTo;

                    emplUpdate.OfficeCode = officeCode;

                    emplUpdate.Email = email;

                    emplUpdate.JobTitle = job;

                    companyDBContext.Employees.Update(emplUpdate);
                    await companyDBContext.SaveChangesAsync();
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return done;
        }

        public async Task<bool> AddEmployee(string employeesName, string employeesLastName, int? reportTo, string officeCode, string job)
        {
            bool done = false;
            try
            {
                Random random = new Random();

                var maxIdEmpl = companyDBContext.Employees
                    .OrderByDescending(e => e.EmployeeNumber)
                    .Select(e => e.EmployeeNumber)
                    .FirstOrDefault();


                if (reportTo > maxIdEmpl)
                {
                    reportTo = random.Next(0, maxIdEmpl);
                }

                var newEmployee = new Employees
                {
                    EmployeeNumber = maxIdEmpl + 1,
                    LastName = employeesName,
                    FirstName = employeesLastName,
                    Extension = Convert.ToString("x" + random.Next(0, 10000)),
                    ReportsTo = reportTo,
                    Email = $"{employeesName}{employeesLastName}@example.com",
                    OfficeCode = officeCode,
                    JobTitle = job
                };

                companyDBContext.Employees.Add(newEmployee);
                await companyDBContext.SaveChangesAsync();
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return done;
        }

        public async Task<List<object>> GetEmployeesOfficesInfo()
        {
            var employeesOffices = await companyDBContext.Employees
                .Join(companyDBContext.Offices,
                    emplo => emplo.OfficeCode,
                    office => office.OfficeCode,
                    (emplo, office) => new {
                        OfficeCode = office.OfficeCode,
                        EmplF = emplo.FirstName,
                        EmplL = emplo.LastName,
                        City = office.City,
                        Phone = office.Phone,
                        Addres = office.AddressLine1,
                        Postal = office.PostalCode
                    })
                    .ToListAsync();

            return employeesOffices.Cast<object>().ToList();
        }

        public bool InsertSpecialPrice(Customers customer, Products product, decimal specialPrice)
        {
            bool done = false;
            try
            {
                SpecialPriceList specialPriceList = new SpecialPriceList() 
                {
                    ProductCode = product.ProductCode,
                    CustomerNumber = customer.CustomerNumber,
                    SpecialPrice = specialPrice
                };
                companyDBContext.SpecialPriceList.Add(specialPriceList);
                companyDBContext.SaveChanges();
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return done;
        }

        #endregion
    }
}
