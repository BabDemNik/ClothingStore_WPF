using ClothingStore.ClassHelper;
using ClothingStore.DB;
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
using static ClothingStore.ClassHelper.ItemModel;
using static ClothingStore.ClassHelper.NavigateClass;

namespace ClothingStore.Pages.EmployeesPages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        List<ItemModel> products = new List<ItemModel>();
        public ListProductPage()
        {
            InitializeComponent();
            products = RefreshCatalog();
            lv_Product.ItemsSource= products;

        }
        

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage(mainFrame, windowFrame, new ListPage());
        }
    }
}
