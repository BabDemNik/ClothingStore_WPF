using ClothingStore.ClassHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ClothingStore.Pages;
using static ClothingStore.ClassHelper.NavigateClass;
using static ClothingStore.ClassHelper.MenuClass;
using ClothingStore.Pages.EmployeesPages.DirectorPages;
using ClothingStore.Pages.EmployeesPages.ManagerPages;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
      
        public AddEditPage()
        {
            InitializeComponent();
            btn_AddEmployee.Visibility = Visibility.Collapsed;
            if (CurrentUser.CurrentDirector != null)
            {
                btn_AddEmployee.Visibility = Visibility.Visible;
                    
            }

            if (CurrentUser.CurrentManager != null)
            {
                btn_AddEmployee.Visibility = Visibility.Collapsed;
                
            }

            if (CurrentUser.CurrentCustomer != null)
            {
                btn_AddEmployee.Visibility = Visibility.Collapsed;
                btn_AddProduct.Visibility = Visibility.Collapsed;
            }

            if (CurrentUser.CurrentManager==null && CurrentUser.CurrentDirector==null)
            {
                //btn_AddEmployee.Visibility = Visibility.Collapsed;
                //btn_AddProduct.Visibility = Visibility.Collapsed;
            }
        

        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage(mainFrame, windowFrame, new AddProductPage());
        }
    }
}
