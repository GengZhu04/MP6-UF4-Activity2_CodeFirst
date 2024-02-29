using MP6_UF4_Activity2_CodeFirst.Dao;
using MP6_UF4_Activity2_CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MP6_UF4_Activity2_CodeFirst.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyDBContext companyDBContext = new CompanyDBContext();
        private IDAODBManager daoManager;

        public MainWindow()
        {
            InitializeComponent();

            daoManager = DAODBManagerFactory.CreateDAODBManager(companyDBContext);

            //daoManager.ImportOffices();
            //daoManager.ImportEmployees();
            //daoManager.ImportCustomers();
            //daoManager.ImportPayments();
            //daoManager.ImportOrders();
            //daoManager.ImportProductLines();
            //daoManager.ImportProducts();
            daoManager.ImportOrderDetails();
        }
    }
}
