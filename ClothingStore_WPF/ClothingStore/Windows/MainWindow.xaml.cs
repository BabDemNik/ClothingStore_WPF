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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassHelper.NavigateClass.authorizationFrame = AuthorizationFrame;
            ClassHelper.NavigateClass.windowFrame = windowFrame;
            //AuthorizationFrame.Navigate(new AuthorizationPage());
            ClassHelper.NavigateClass.authorizationFrame.Visibility= Visibility.Collapsed;
            windowFrame.Navigate(new HomePage());
        }

        private void AuthorizationFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            var fa = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.7));
            (e.Content as Page).BeginAnimation(OpacityProperty, fa);
        }
    }
}
