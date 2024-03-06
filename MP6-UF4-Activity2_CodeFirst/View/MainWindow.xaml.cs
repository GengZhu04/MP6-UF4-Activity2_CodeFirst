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
        private List<Offices> listOffices = new List<Offices>();
        private int indexOffice, indexEmployee, indexCustomer;

        public MainWindow()
        {
            InitializeComponent();

            daoManager = DAODBManagerFactory.CreateDAODBManager(companyDBContext);
            //GetImports();
            //Get();

            #region LoadsDataBase Information
            //LoadGrid();
            #endregion

            cmbEzSelect.Items.Clear();
            cmbEzSelect.Items.Add("GetProductsLinesWithProducts");
            cmbEzSelect.Items.Add("GetListPaymentsDate");
            cmbEzSelect.Items.Add("GetEmployeesOfficesInfo");

            cmbEzSelect.Items.Add("GetOrdersOrderedByDate");
            cmbEzSelect.Items.Add("GetShippedOrdersRecentThan");
            cmbEzSelect.Items.Add("GetProductsByScale");
            cmbEzSelect.Items.Add("GetInfoCustomerProductsOrders");
            cmbEzSelect.Items.Add("SearchCustomerByFirtsLetter");
            cmbEzSelect.SelectedIndex = 0;

            cmbAllEmpls.Loaded += CmbAllEmpls_Loaded;

            // Insert Special Price Randomly
            //Create20RandomSpeacialPrice();

            // Load Data
            dgOffices.Loaded += DgOffices_Loaded;
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

        #region MEGA SWITCH

        private async void cmbEzSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbEzSelect.SelectedIndex)
            {
                //Facil
                case 0:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetProductsLinesWithProducts();
                    break;

                case 1:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetListPaymentsDate();
                    break;

                case 2:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetEmployeesOfficesInfo();
                    break;
                    //Vigilar
                case 3:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    dgEzSelect.ItemsSource = await daoManager.GetOrdersOrderedByDate();
                    dgEzSelect.Columns[7].Visibility = Visibility.Collapsed;
                    dgEzSelect.Columns[8].Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    spSerchDate.Visibility = Visibility.Visible;
                    dgEzSelect.ItemsSource = new List<object>();
                    break;
                case 5:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Visible;
                    dgEzSelect.ItemsSource = new List<object>();
                    
                    
                    break;
                case 6:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Visible;
                    object[] tmpCustomer = (object[])await daoManager.GetAllCustomerID();
                    List<int> listCustomers = tmpCustomer
                        .Select(c => ((int)c.GetType().GetProperty("CustomerID").GetValue(c)))
                        .ToList();
                    cmbCustomers.ItemsSource = listCustomers;
                    
                    break;
                case 7:
                    spSerchDate.Visibility = Visibility.Collapsed;
                    spSerchScale.Visibility = Visibility.Collapsed;
                    spSerchCustomer.Visibility = Visibility.Collapsed;
                    spSerchCustomerByFirtsLetter.Visibility = Visibility.Visible;
                    dgEzSelect.ItemsSource = new List<object>();
                    break;
                
                default:
                    dgEzSelect.ItemsSource = await daoManager.GetProductsLinesWithProducts();
                    break;
            }

        }
        private async void btnSearchByDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            DateTime.TryParse(tbDate.Text, out date);
            dgEzSelect.ItemsSource = await daoManager.GetShippedOrdersRecentThan(date);
            dgEzSelect.Columns[7].Visibility = Visibility.Collapsed;
            dgEzSelect.Columns[8].Visibility = Visibility.Collapsed;
        }
        private async void btnSearchByScale_Click(object sender, RoutedEventArgs e)
        {
            string scale = tbScale.Text;
            dgEzSelect.ItemsSource = await daoManager.GetProductsByScale(scale);
            dgEzSelect.Columns[3].Visibility = Visibility.Collapsed;
            dgEzSelect.Columns[10].Visibility = Visibility.Collapsed;
            dgEzSelect.Columns[11].Visibility = Visibility.Collapsed;
        }
        private async void btnSearchCustomerByFirtsLetter_Click(object sender, RoutedEventArgs e)
        {
            char letter;

            if (char.TryParse(tbCustomerByFirtsLetter.Text, out letter))
            {
                dgEzSelect.ItemsSource = await daoManager.GetCustomersWithFirstNameChar(letter);
                dgEzSelect.Columns[9].Visibility = Visibility.Collapsed;
                dgEzSelect.Columns[14].Visibility = Visibility.Collapsed;
                dgEzSelect.Columns[15].Visibility = Visibility.Collapsed;
                dgEzSelect.Columns[16].Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Please enter a valid single letter.");
            }
            
            
            
        }
        private async void cmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(cmbCustomers.SelectedItem.ToString());
            dgEzSelect.ItemsSource = await daoManager.GetInfoProductsOrders(id);
        }

        private async void cmbAllEmpls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(cmbAllEmpls.SelectedItem.ToString());
            object[] tmpEmployee = (object[])await daoManager.GetAllEmployeeID();
            List<string> name = tmpEmployee
                .Where(e => ((int)e.GetType().GetProperty("EmployeeID").GetValue(e)) == id)
                .Select(e => ((string)e.GetType().GetProperty("EmployeeFirstName").GetValue(e)))
                .ToList();
            int countCustomers = await daoManager.CountCustomersByEmployee(id);
            tbOutput.Text = $"The {id} Employee ID That Has Name {name[0]} Has {countCustomers} Customers";
        }

        private async void CmbAllEmpls_Loaded(object sender, RoutedEventArgs e)
        {
            object[] tmpEmployee = (object[])await daoManager.GetAllEmployeeID();
            List<int> listEmployees = tmpEmployee
                .Select(c => ((int)c.GetType().GetProperty("EmployeeID").GetValue(c)))
                .ToList();
            cmbAllEmpls.ItemsSource = listEmployees;
            cmbAllEmpls.SelectedIndex = 0;
        }

        #endregion

        #region megaJoin

        private async void DgOffices_Loaded(object sender, RoutedEventArgs e)
        {
            listOffices = (List<Offices>)await daoManager.GetAllOfficeInfo();
            dgOffices.ItemsSource = listOffices;
        }

        private void btnViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = listOffices[indexOffice].Employees;
            dgEmployees.Columns[7].Visibility = Visibility.Collapsed;
            dgEmployees.Columns[9].Visibility = Visibility.Collapsed;
            dgEmployees.Columns[11].Visibility = Visibility.Collapsed;
        }

        private void btnViewCustomer_Click(object sender, RoutedEventArgs e)
        {
            List<Employees> listEmployees = new List<Employees>(listOffices[indexOffice].Employees);
            dgCustomers.ItemsSource = listEmployees[indexEmployee].Customers;
            dgCustomers.Columns[13].Visibility = Visibility.Collapsed;
            dgCustomers.Columns[15].Visibility = Visibility.Collapsed;
            dgCustomers.Columns[16].Visibility = Visibility.Collapsed;
            dgCustomers.Columns[17].Visibility = Visibility.Collapsed;
        }

        private void btnViewPayments_Click(object sender, RoutedEventArgs e)
        {
            List<Employees> listEmployees = new List<Employees>(listOffices[indexOffice].Employees);
            List<Customers> listCustomers = new List<Customers>(listEmployees[indexEmployee].Customers);
            dgPayments.ItemsSource = listCustomers[indexCustomer].Payments;
            dgPayments.Columns[1].Visibility = Visibility.Collapsed;
        }

        private void dgOffices_SelectedCellsChanged(object sender, EventArgs e)
        {
            indexOffice = dgOffices.SelectedIndex;
            dgPayments.ItemsSource = new List<object>();
            dgCustomers.ItemsSource = new List<object>();
            dgEmployees.ItemsSource = new List<object>();
        }

        private void dgEmployees_SelectedCellsChanged(object sender, EventArgs e)
        {
            indexEmployee = dgEmployees.SelectedIndex;
            dgPayments.ItemsSource = new List<object>();
            dgCustomers.ItemsSource = new List<object>();
        }

        private void dgCustomers_SelectedCellsChanged(object sender, EventArgs e)
        {
            indexCustomer = dgCustomers.SelectedIndex;
            dgPayments.ItemsSource = new List<object>();
        }

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
