using MP6_UF4_Activity2_CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Dao
{
    public class DAODBManagerFactory
    {
        public static IDAODBManager CreateDAODBManager(CompanyDBContext companyDBContext)
        {
            return new DAODBManager(companyDBContext);
        }
    }
}
