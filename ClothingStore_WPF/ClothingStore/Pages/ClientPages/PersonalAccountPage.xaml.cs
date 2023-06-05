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
using static ClothingStore.ClassHelper.CurrentUser;
using ClothingStore.Pages.PublicPages;
using ClothingStore.DB;
using ClothingStore.ClassHelper;

namespace ClothingStore.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
       
        
        public PersonalAccountPage()
        {

            InitializeComponent();
            
            if(CurrentManager != null )
            {
                tb_FName.Text = CurrentManager.FName;
                tb_Patronymic.Text = CurrentManager.Patronymic;
                tb_Phone.Text = CurrentManager.Phone;
                tb_LName.Text = CurrentManager.MName;
            }

            if (CurrentCustomer != null)
            {
                tb_FName.Text = CurrentCustomer.FName;
                tb_Patronymic.Text = CurrentCustomer.Patronymic;
                tb_Phone.Text = CurrentCustomer.Phone;
                tb_LName.Text = CurrentCustomer.LName;
            }

            if (CurrentDirector != null)
            {
                tb_FName.Text = CurrentDirector.FName;
                tb_Patronymic.Text = CurrentDirector.Patronymic;
                tb_Phone.Text = CurrentDirector.Phone;
                tb_LName.Text = CurrentDirector.MName;
            }

        }
       

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            CurrentDirector = null;
            CurrentCustomer = null;
            CurrentManager = null;
            if (!windowFrame.CanGoBack && !windowFrame.CanGoForward)
            {
                return;
            }

            var entry = windowFrame.RemoveBackEntry();
            while (entry != null)
            {
                entry = windowFrame.RemoveBackEntry();
            }

            windowFrame.Navigate(new HomePage());

        }
    }
}
