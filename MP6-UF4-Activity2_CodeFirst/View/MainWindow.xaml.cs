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
using static System.Formats.Asn1.AsnWriter;

namespace MP6_UF4_Activity2_CodeFirst.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyDBContext companyDBContext = new CompanyDBContext();
        private IDAODBManager daoManager;
        public const int TOTAL_INSERT_CUSTOMERS = 10;

        public MainWindow()
        {
            InitializeComponent();

            daoManager = DAODBManagerFactory.CreateDAODBManager(companyDBContext);
            //GetImports();
            //Get();

            #region LoadsDataBase Information
            //LoadGrid();
            #endregion

            // Insert Special Price Randomly
            //Create20RandomSpeacialPrice();
        }
        private async Task LoadGrid()
        {
            //GRUD
            dgAllEmployees.ItemsSource = await daoManager.GetAllEmployees();
        }


        private bool GetImports()
        {
            bool done = false;
            try
            {
                daoManager.ImportOffices();
                daoManager.ImportEmployees();
                daoManager.ImportCustomers();
                daoManager.ImportPayments();
                daoManager.ImportOrders();
                daoManager.ImportProductLines();
                daoManager.ImportProducts();
                daoManager.ImportOrderDetails();
                done = true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error In Import", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return done;

        }
        
        private async void Get()
        {
            //gridData.ItemsSource = await daoManager.GetOrdersOrderedByDate();

            //gridData.ItemsSource = await daoManager.GetShippedOrdersRecentThan();

            //gridData.ItemsSource = await daoManager.GetProductsByScale();

            //gridData.ItemsSource = await daoManager.GetProductsLinesWithProducts();

            //gridData.ItemsSource = await daoManager.GetInfoProductsOrders(141);

            //gridData.ItemsSource = await daoManager.GetCustomersWithFirstNameChar('A');

            //gridData.ItemsSource = await daoManager.GetListPaymentsDate();

            //gridData.ItemsSource = await daoManager.GetAllOfficeInfo();

            //gridData.ItemsSource = await daoManager.GetEmployeesOfficesInfo();

            //add
            //var result = await daoManager.AddEmployee("olek2323", "pomerantsev", 1002, "1", "IT");

            //del
            //var result = await daoManager.DeleteEmployee(1704);

            //update
            //var result = await daoManager.UpdateEmployee(1703,"El Rey","Artur","x4444",null,"1","aaaaaa","aa");
        }


        #region CRUD


        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeName.Text) || string.IsNullOrEmpty(employeeLastName.Text) ||
                string.IsNullOrEmpty(employeeDepertment.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
            }
            try
            {
                
                int? jefeId = !string.IsNullOrEmpty(employeeJefe.Text) ? Convert.ToInt32(employeeJefe.Text) : null;

                daoManager.AddEmployee(employeeName.Text, employeeLastName.Text, jefeId, employeeDepertment.Text, employeeJob.Text);
                await LoadGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the employee: {ex.Message}");
            }
            
            

        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(employeeUpdateId.Text) || string.IsNullOrEmpty(updateName.Text) || string.IsNullOrEmpty(updateeLastName.Text) ||
                string.IsNullOrEmpty(updateDepertment.Text) || (string.IsNullOrEmpty(updateExtent.Text) || updateExtent.Text.First() != 'x'))
                {
                    MessageBox.Show("Please fill in all the required fields.");
                }
                else
                {
                    int? jefeId = !string.IsNullOrEmpty(employeeJefe.Text) ? Convert.ToInt32(employeeJefe.Text) : null;

                    daoManager.UpdateEmployee(Convert.ToInt32(employeeUpdateId.Text), updateName.Text, updateeLastName.Text, updateExtent.Text, jefeId, updateDepertment.Text, updateEmail.Text, updateJob.Text);
                    await LoadGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the employee: {ex.Message}");
            }

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeDeleteId.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
            }
            try
            {
                daoManager.DeleteEmployee(Convert.ToInt32(employeeDeleteId.Text));
                await LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the employee: {ex.Message}");
            }
        }
        #endregion

        #region Directo grid

        private async void cmbEzSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbEzSelect.Items.Clear();
            cmbEzSelect.Items.Add("GetProductsLinesWithProducts");
            cmbEzSelect.Items.Add("GetListPaymentsDate");
            cmbEzSelect.Items.Add("GetEmployeesOfficesInfo");

            cmbEzSelect.Items.Add("GetOrdersWithDetails");
            cmbEzSelect.Items.Add("GetShippedOrders");
            cmbEzSelect.Items.Add("GetProductsByScale");
            cmbEzSelect.SelectedIndex = 0;

            

            switch (cmbEzSelect.SelectedIndex)
            {
                //Facil
                case 0:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetProductsLinesWithProducts();
                    break;

                case 1:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetListPaymentsDate();
                    break;

                case 2:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetEmployeesOfficesInfo();
                    break;
                    //Vigilar
                case 3:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetOrdersOrderedByDate();
                    break;
                case 4:
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    spSerchDate.Visibility = Visibility.Visible;
                    //dgEzSelect.ItemsSource = await daoManager.GetShippedOrdersRecentThan(date);
                    break;
                case 5:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Visible;
                    //dgEzSelect.ItemsSource = await daoManager.GetProductsByScale(scale);
                    break;
                case 6:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Visible;
                    //dgEzSelect.ItemsSource = await daoManager.GetInfoProductsOrders(cusId);
                    break;
                case 7:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchEmployee.Visibility = Visibility.Visible;
                    //dgEzSelect.ItemsSource = await daoManager.CountCustomersByEmployee(empId);
                    break;
                    

                default:
                    dgEzSelect.ItemsSource = await daoManager.GetProductsLinesWithProducts();
                    break;
            }

        }

        #endregion

        #region megaJoin



        #endregion

        #region Part 4

        private async void Create20RandomSpeacialPrice()
        {
            object[] tmpCustomer = (object[])await daoManager.GetAllCustomerID();
            List<(int CustomerID, string CustomerName)> listCustomers = tmpCustomer
                .Select(c => ((int)c.GetType().GetProperty("CustomerID").GetValue(c),
                              (string)c.GetType().GetProperty("CustomerName").GetValue(c)))
                .ToList();
            object[] tmpProduct = (object[]) await daoManager.GetAllProductID();
            List<(string ProductID, string ProductName, decimal ProductPrice)> listProducts = tmpProduct
                .Select(p => ((string)p.GetType().GetProperty("ProductID").GetValue(p),
                              (string)p.GetType().GetProperty("ProductName").GetValue(p),
                              (decimal)p.GetType().GetProperty("ProductPrice").GetValue(p)))
                .ToList();

            Random r = new Random();

            for (int i = 0; i < TOTAL_INSERT_CUSTOMERS; i++)
            {
                int indexCustomer = r.Next(listCustomers.Count);
                int indexProduct = r.Next(listProducts.Count);
                int oferta = r.Next(1, 51);
                decimal specialPrice = listProducts[indexProduct].ProductPrice - (listProducts[indexProduct].ProductPrice * (oferta / 100));
                daoManager.InsertSpecialPrice(listCustomers[indexCustomer].CustomerID, listProducts[indexProduct].ProductID, specialPrice);

                indexProduct = r.Next(listProducts.Count);
                oferta = r.Next(1, 51);
                specialPrice = listProducts[indexProduct].ProductPrice - (listProducts[indexProduct].ProductPrice * (oferta / 100));
                daoManager.InsertSpecialPrice(listCustomers[indexCustomer].CustomerID, listProducts[indexProduct].ProductID, specialPrice);
            }
        }

        #endregion

    }
}
