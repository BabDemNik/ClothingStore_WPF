using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static ClothingStore.ClassHelper.EFClass;
using static ClothingStore.ClassHelper.ItemModel;
using static ClothingStore.ClassHelper.NavigateClass;
using ClothingStore.Pages;
using ClothingStore.Pages.PublicPages;
using System.Windows.Media;

namespace ClothingStore.ClassHelper
{
    class MenuClass
    {
        public static Button buttonLogin;
        public static Button buttonCatalog;
        public static Button buttonCart;
        public static Button buttonPersonalAccount;
        public static Button buttonAddEdit;
        public static Button buttonLists;
        public static void SetIsEnabledTrue(string pageactive)
        {
            
            switch (pageactive)
            {
                case "CatalogePage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = false;
                    buttonCart.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "CartPage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = false;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "AddEditPage":
                    if (CurrentUser.CurrentDirector != null)
                    {
                        NavigatePage(mainFrame, windowFrame, new AddEditPage()); 
                    }

                    if (CurrentUser.CurrentManager != null)
                    {
                        NavigatePage(mainFrame, windowFrame, new AddEditPage());
                    }
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = false;
                    buttonLists.IsEnabled = true;
                    break;
                case "ListPage":
                    if (CurrentUser.CurrentDirector != null)
                    {
                        NavigatePage(mainFrame, windowFrame, new AddEditPage());
                    }

                    if (CurrentUser.CurrentManager != null)
                    {
                        NavigatePage(mainFrame, windowFrame, new AddEditPage());
                    }
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;
                case "ListEmployeePage":
                    
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;

            }
                
           
           

        }
        public static void SetIsEnabledFalse()
        {

            buttonLogin.IsEnabled = false;
            buttonCatalog.IsEnabled = false;
            buttonCart.IsEnabled = false;
            buttonPersonalAccount.IsEnabled = false;
            buttonAddEdit.IsEnabled= false;
            buttonLists.IsEnabled = false;

        }

       
        public static void SetFocusButton(object sender)
        {
           
            Button button = (Button)sender;
            switch (button.Name) 
            {
                case "btn_Catalog":
                    buttonCatalog.IsEnabled= false;
                    buttonCart.IsEnabled= true;
                    buttonPersonalAccount.IsEnabled= true;
                    buttonLogin.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_Cart":
                   
                    buttonCart.IsEnabled = false;
                    buttonCatalog.IsEnabled = true;
                    buttonLogin.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_PersonalAccount":
                    buttonPersonalAccount.IsEnabled= false;
                    buttonCart.IsEnabled= true;
                    buttonCatalog.IsEnabled= true;
                    buttonLogin.IsEnabled= true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_AddEdit":
                    buttonAddEdit.IsEnabled = false;
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_Lists":
                    buttonAddEdit.IsEnabled = true;
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;

            }
        }
    }
}
