using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClothingStore.ClassHelper
{
    class NavigateClass
    {
        public static Frame authorizationFrame;
        public static Frame mainFrame;
        public static Frame menuFrame;
        public static Frame windowFrame;



        public static void NavigatePage(Frame frame, Frame window, Page page)
        {
            if (page == null) 
            { 
                frame.Visibility = Visibility.Collapsed;
                return;
            }
            if (window == null)
            {
                var entry = frame.RemoveBackEntry();
                while (entry != null)
                {
                    entry = frame.RemoveBackEntry();
                }
                frame.Navigate(page);
                return;
            }


            if (window.CanGoBack)
            {
                
                var entry = window.RemoveBackEntry();
                while (entry != null)
                {
                    entry = window.RemoveBackEntry();
                }


            }

            frame.Navigate(page);



        }
        

    }
}
