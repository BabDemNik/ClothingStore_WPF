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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.MenuClass;


namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            ClassHelper.NavigateClass.mainFrame = mainFrame;
            ClassHelper.NavigateClass.menuFrame = menuFrame;
            menuFrame.Navigate(new MenuPage());
            mainFrame.Navigate(new CatalogePage());
            buttonCatalog.IsEnabled = false;
            
        }

        private void mainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var fa = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.7));
            (e.Content as Page).BeginAnimation(OpacityProperty, fa);
        }


        
    }
}
