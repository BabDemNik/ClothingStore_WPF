using ClothingStore.ClassHelper;
using ClothingStore.Pages.EmployeesPages.DirectorPages;
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
using static ClothingStore.ClassHelper.NavigateClass;

namespace ClothingStore.Pages.EmployeesPages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            
            btn_ListEmployee.Visibility = Visibility.Collapsed;
            if (CurrentUser.CurrentDirector != null)
            {
                btn_ListEmployee.Visibility = Visibility.Visible;
              
            }

            if (CurrentUser.CurrentManager != null)
            {
                btn_ListEmployee.Visibility = Visibility.Collapsed;
               

            }

            if (CurrentUser.CurrentCustomer !=null)
            {
                btn_ListEmployee.Visibility = Visibility.Collapsed;
                btn_ListProduct.Visibility = Visibility.Collapsed;
            }

            if (CurrentUser.CurrentManager == null && CurrentUser.CurrentDirector == null)
            {
                //btn_ListEmployee.Visibility = Visibility.Collapsed;
                //btn_ListProduct.Visibility = Visibility.Collapsed;
            }

        }
        private void btn_ListEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            NavigatePage(mainFrame, windowFrame, new ListEmployeePage());
               
           
        }

        private void btn_ListProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage(mainFrame, windowFrame, new ListProductPage());
        }
    }
}
