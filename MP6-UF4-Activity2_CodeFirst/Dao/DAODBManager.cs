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
            throw new NotImplementedException();
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
