
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
                    fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        int customerNumber = Convert.ToInt32(fields[0].ToLower().Equals("null") ? 0 : fields[0]);
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
                        int salesRepEmployeeNumber = Convert.ToInt32(fields[11].ToLower().Equals("null") ? 0 : fields[11]);
                        decimal creditLimit = Convert.ToDecimal(fields[12].ToLower().Equals("null") ? (decimal)0 : fields[12]);

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
                        fields = parser.ReadFields();
                    }
                }
                companyDBContext.SaveChanges();
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
                    fields = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        int employeeNumber = Convert.ToInt32(fields[0].Equals("null") ? 0 : fields[0]);
                        string lastName = fields[1];
                        string firstName = fields[2];
                        string extension = fields[3];
                        string email = fields[4];
                        string officeCode = fields[5];
                        int reportsTo = Convert.ToInt32(fields[6].Equals("null") ? 0 : fields[6]);
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
                        fields = parser.ReadFields();
                    }
                }
                companyDBContext.SaveChanges();
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
