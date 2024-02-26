
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using MP6_UF4_Activity2_CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Dao
{
    public class DAODBManager : IDAODBManager
    {
        private CompanyDBContext companyDBContext;

        public DAODBManager(CompanyDBContext companyDBContext) 
        {
            this.companyDBContext = companyDBContext;
        }

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

    }
}
