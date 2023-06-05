using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public List<string> selectedColor = new List<string>();
        public List<ColorItem> data = new List<ColorItem>();
        
        public TestWindow()
        {
            InitializeComponent();
            ObservableCollection<ModelGroup> custdata = new ObservableCollection<ModelGroup>();

            data = Context.ColorItem.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                custdata.Add(new ModelGroup() { Name = data.ToList()[i].ColorTitle });
            }

            lst.ItemsSource = custdata;
            //lst.ItemsSource = typeof(Colors).GetProperties();
        }

        public class ModelGroup
        {
            public string Name { get; set; }
            
        }

        private void btn_GetId_Click(object sender, RoutedEventArgs e)
        {

            //for (int i = 0; i < selectedGroups.Count; i++)
            //{
            //    var id = data.ToList().Where(x => x.GruopTitle == selectedGroups[i]).FirstOrDefault().CustomerGroupID;
            //    MessageBox.Show(id.ToString());
            //    //selectedGroups.RemoveAt(i);
            //}


        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;


            if (!cb.IsChecked.Value)
            {

                selectedColor.Remove(cb.Content.ToString());
               
            }
            if (selectedColor.Count < 4 || selectedColor.Count < 0)
            {
               
                lv_Header.Visibility = Visibility.Visible;
                tb_Count.Visibility = Visibility.Collapsed;
                tb_Count.Text = "";
            }

            if (selectedColor.Contains(cb.Content))
            {
                return;
            }
            


            if (cb.IsChecked.Value)
            {
                
                selectedColor.Add(cb.Content.ToString());

            }
            if (selectedColor.Count > 3)
            {
               
                lv_Header.Visibility = Visibility.Collapsed;
                tb_Count.Visibility = Visibility.Visible;
                tb_Count.Text = selectedColor.Count.ToString();
            }

           
           
           

           


        }




    }

}