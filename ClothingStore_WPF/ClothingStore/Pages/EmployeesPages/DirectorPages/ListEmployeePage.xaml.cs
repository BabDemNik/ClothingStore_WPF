using ClothingStore.DB;
using ClothingStore.Pages.EmployeesPages.ManagerPages;
using ClothingStore.Pages.PublicPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.EFClass;
using static ClothingStore.ClassHelper.NavigateClass;

namespace ClothingStore.Pages.EmployeesPages.DirectorPages
{
    /// <summary>
    /// Логика взаимодействия для ListEmployeePage.xaml
    /// </summary>
    
    public partial class ListEmployeePage : Page
    {
        List<Employee> employees= new List<Employee>();
        public ListEmployeePage()
        {
            InitializeComponent();
            GetList();
        }
        public void GetList()
        {
            employees = Context.Employee.ToList();
            lv_Employee.ItemsSource= employees;
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage(mainFrame, windowFrame, new ListPage());
        }
    }
}
