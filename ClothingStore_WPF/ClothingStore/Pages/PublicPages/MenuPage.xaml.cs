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
using static ClothingStore.ClassHelper.NavigateClass;
using static ClothingStore.ClassHelper.MenuClass;
using ClothingStore.Pages.PublicPages;
using ClothingStore.Pages.ClientPages;
using System.Diagnostics;
using ClothingStore.Pages.EmployeesPages;
using ClothingStore.Pages.EmployeesPages.ManagerPages;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
      
        public MenuPage()
        {
            InitializeComponent();
            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            MenuClass.buttonPersonalAccount = btn_PersonalAccount;
            MenuClass.buttonAddEdit = btn_AddEdit;
            MenuClass.buttonLists = btn_Lists;
            if (CurrentUser.CurrentCustomer!=null )
            {
                MenuClass.buttonPersonalAccount.Visibility = Visibility.Visible;
                MenuClass.buttonLogin.Visibility = Visibility.Collapsed;
                buttonAddEdit.Visibility = Visibility.Visible;
                buttonLists.Visibility = Visibility.Visible;
            }

            if (CurrentUser.CurrentManager != null )
            {
                MenuClass.buttonPersonalAccount.Visibility = Visibility.Visible;
                MenuClass.buttonLogin.Visibility = Visibility.Collapsed;
            }

            if (CurrentUser.CurrentDirector != null)
            {
                MenuClass.buttonPersonalAccount.Visibility = Visibility.Visible;
                MenuClass.buttonLogin.Visibility = Visibility.Collapsed;
            }
            if (CurrentUser.CurrentCustomer==null && CurrentUser.CurrentManager==null && CurrentUser.CurrentDirector==null)
            {
                MenuClass.buttonPersonalAccount.Visibility = Visibility.Collapsed;
                MenuClass.buttonLogin.Visibility = Visibility.Visible;
            }
         


            if (CurrentUser.CurrentManager == null && CurrentUser.CurrentDirector == null || CurrentUser.CurrentCustomer!=null )
            {
              //buttonAddEdit.Visibility = Visibility.Collapsed;
              //buttonLists.Visibility= Visibility.Collapsed;
            }
           
        }

        private void bt_Login_Click(object sender, RoutedEventArgs e)
        {
            SetIsEnabledFalse();  
            NavigatePage(authorizationFrame, windowFrame, new AuthorizationPage());
            authorizationFrame.Visibility = Visibility.Visible;
        }

        private void bt_Catalog_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            NavigatePage(mainFrame, windowFrame, new CatalogePage());
        }

        private void btn_Cart_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            NavigatePage(mainFrame, windowFrame, new CartPage());
            
        }

        private void btn_PersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            NavigatePage(mainFrame, windowFrame, new PersonalAccountPage());
        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            NavigatePage(mainFrame, windowFrame, new AddEditPage());
        }

        private void btn_Lists_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            NavigatePage(mainFrame, windowFrame, new ListPage());
        }
    }
}

