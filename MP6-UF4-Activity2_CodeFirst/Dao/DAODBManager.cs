using MP6_UF4_Activity2_CodeFirst.Model;
using System;
using System.Collections.Generic;
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
    }
}
