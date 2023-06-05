using ClothingStore.ClassHelper;
using ClothingStore.DB;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.Pages.EmployeesPages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>


    public partial class AddProductPage : Page
    {
        public List<string> selectedGroups = new List<string>();
        public List<string> selectedCategory = new List<string>();
        public List<string> selectedTypeСlothes = new List<string>();
        public List<string> selectedSize= new List<string>();
        public List<string> selectedColor= new List<string>();
        List<CustomerGroup> ListCustomerGroup = new List<CustomerGroup>();
        List<CategoryItem> ListCategory = new List<CategoryItem>();        
        List<TypeСlothes> ListTypeСlothes = new List<TypeСlothes>();
        List<SizeItem> ListSize= new List<SizeItem>();
        List<ColorItem> ListColor= new List<ColorItem>();
        List<ModelColor> Models = new List<ModelColor>();

        public AddProductPage()
        {
            InitializeComponent();
            GetItems(lv_CustomersGroups.Name);
            GetItems(lv_Category.Name);
            GetItems(lv_TypeСlothes.Name);
            GetItems(lv_Size.Name);
            GetItems(lv_Color.Name);
            PutItems<CustomerGroup>(lv_CustomersGroups, ListCustomerGroup, selectedGroups);
            PutItems<CategoryItem>(lv_Category, ListCategory, selectedCategory);
            PutItems<TypeСlothes>(lv_TypeСlothes, ListTypeСlothes, selectedTypeСlothes);
            PutItems<SizeItem>(lv_Size, ListSize, selectedSize);
            PutItems<ColorItem>(lv_Color, ListColor, selectedColor);

            lv_CustomersGroups.ItemsSource = ListCustomerGroup;
            lv_Category.ItemsSource = ListCategory;
            lv_TypeСlothes.ItemsSource = ListTypeСlothes;
            lv_Color.ItemsSource = ListColor;
            lv_Size.ItemsSource= ListSize;
            //lv_Size.ItemsSource = GetItems(lv_Size.Name);
            //lv_Header.ItemsSource = typeof(Colors).GetProperties();
            
        }

        public void GetItems(string lv)
        {
           
            //MessageBox.Show(lv);
            switch (lv)
            {
                case "lv_CustomersGroups":
                   
                    for (int i = 0; i < Context.CustomerGroup.Count(); i++)
                    {
                    
                        ListCustomerGroup.Add(Context.CustomerGroup.ToList()[i]);
                    }
                    
                    break;
                case "lv_Category":
                    for (int i = 0; i < Context.CategoryItem.Count(); i++)
                    {
                        ListCategory.Add(Context.CategoryItem.ToList()[i]);
                    }
                    break;
                case "lv_TypeСlothes":
                    for (int i = 0; i < Context.TypeСlothes.Count(); i++)
                    {
                        ListTypeСlothes.Add(Context.TypeСlothes.ToList()[i]);
                    }    
                    break;
                case "lv_Size":
                    for (int s = 0; s < Context.SizeItem.Count(); s++)
                    {
                        ListSize.Add(Context.SizeItem.ToList()[s]);
                    }
                    break;
                case "lv_Color":
                    for (int i = 0; i < Context.ColorItem.Count(); i++)
                    {
                        ListColor.Add(Context.ColorItem.ToList()[i]);
                    }
                    
                    break;
                default:
                    break;
            }

            
        }

        public void PutItems<T>(ListBox lv, List<T> list, List<string> selected)
        {
            

            if (lv.Items == null)
            {
                lv.ItemsSource = list;
            }

            if (selected.Count==0)
            {
                lv.ItemsSource = null;
                lv.ItemsSource = list;
                selected.Clear();

                
            }
        }

      
        
       
      
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;

            

            switch (cb.Name)
            {
                case "cb_CustomerGroup":
                    if (cb.IsChecked.Value)
                    {
                        tb_CustomersGroups.Text = cb.Content.ToString();
                        selectedGroups.Add(cb.Content.ToString());
                    }

                    if (!cb.IsChecked.Value)
                    {
                        tb_CustomersGroups.Text = "";
                        selectedGroups.Remove(cb.Content.ToString());
                    }


                    if (selectedGroups.Count >= 2)
                    {
                        tb_CustomersGroups.Text = selectedGroups.Count.ToString();


                    }

                    if (selectedGroups.Count < 2 && selectedGroups.Count > 0)
                    {
                        tb_CustomersGroups.Text = selectedGroups[0].ToString();
                    }
                    break;
                case "cb_Category":


                    if (cb.IsChecked.Value)
                    {
                        tb_Category.Text = cb.Content.ToString();
                        selectedCategory.Add(cb.Content.ToString());
                    }

                    if (!cb.IsChecked.Value)
                    {
                        tb_Category.Text = "";
                        selectedCategory.Remove(cb.Content.ToString());
                    }
                    
                    if (selectedCategory.Count == 0 || !cb.IsChecked.Value)
                    {
                        PutItems<SizeItem>(lv_Size, ListSize, selectedSize);
                    }

                    if (selectedCategory.Count == 0 || !cb.IsChecked.Value)
                    {
                        PutItems<TypeСlothes>(lv_TypeСlothes, ListTypeСlothes, selectedTypeСlothes);
                    }



                    if (selectedCategory.Count >= 2)
                    {
                        tb_Category.Text = selectedCategory.Count.ToString();
                    }

                  

                    List<CategoryItem> IdCatedory = new List<CategoryItem>();
                    List<SizeItem> size = new List<SizeItem>();
                    List<TypeСlothes> type = new List<TypeСlothes>();
                    if (selectedCategory.Count >= 2)
                    {

                        
                        for (int i = 0; i < ListCategory.Count; i++)
                        {

                            for (int id = 0; id <selectedCategory.Count ; id++)
                            {
                                if (ListCategory[i].CategoryTitle == selectedCategory[id])
                                {
                                  
                                    IdCatedory.Add(ListCategory[i]);
                                }
                            }
                           
                           
                           
                        }
                     

                       
                        

                        for (int i = 0; i < ListSize.Count; i++)
                        {
                            for (int id = 0; id < IdCatedory.Count; id++)
                            {
                                if (ListSize[i].CategoryID == IdCatedory[id].CategoryID)
                                {
                                    size.Add(ListSize[i]);
                                }
                            }   
                            
                        }

                        for (int i = 0; i < ListTypeСlothes.Count; i++)
                        {
                            for (int id = 0; id < IdCatedory.Count; id++)
                            {
                                if (ListTypeСlothes[i].CategoryID == IdCatedory[id].CategoryID)
                                {
                                    type.Add(ListTypeСlothes[i]);
                                }
                            }
                        }
                      




                        
                        if (size != null)
                        {
                            PutItems<SizeItem>(lv_Size, size, selectedSize);
                        }
                        else
                        {
                            PutItems<SizeItem>(lv_Size, ListSize, selectedSize);
                        }

                        if (type != null)
                        {
                            PutItems<TypeСlothes>(lv_TypeСlothes, type, selectedTypeСlothes);
                        }
                        else
                        {
                            PutItems<TypeСlothes>(lv_TypeСlothes, ListTypeСlothes, selectedTypeСlothes);

                        }
                        
                    }



                    if (selectedCategory.Count < 2 && selectedCategory.Count > 0)
                    {
                        tb_Category.Text = selectedCategory[0].ToString();
                    }

                    if (selectedCategory.Count==1)
                    {
                        for (int i = 0; i < selectedCategory.Count; i++)
                        {
                            IdCatedory =ListCategory.FindAll(x => x.CategoryTitle == selectedCategory[i]);
                            size = ListSize.FindAll(x => x.CategoryID == IdCatedory[i].CategoryID);
                            type = ListTypeСlothes.FindAll(x => x.CategoryID == IdCatedory[i].CategoryID);
                        }
                     
                        if (size != null)
                        {
                            PutItems<SizeItem>(lv_Size, size, selectedSize);
                        }
                        else
                        {
                            PutItems<SizeItem>(lv_Size, ListSize, selectedSize);
                        }

                        if (type != null)
                        {
                            PutItems<TypeСlothes>(lv_TypeСlothes, type, selectedTypeСlothes);
                        }
                        else
                        {
                            PutItems<TypeСlothes>(lv_TypeСlothes, ListTypeСlothes, selectedTypeСlothes);

                        }


                    }
                   


                   
                   


                    break;
                case "cb_TypeСlothes":

                    

                    if (cb.IsChecked.Value)
                    {
                        tb_TypeСlothes.Text = cb.Content.ToString();
                        selectedTypeСlothes.Add(cb.Content.ToString());
                    }

                    if (!cb.IsChecked.Value)
                    {
                        tb_TypeСlothes.Text = "";
                        selectedTypeСlothes.Remove(cb.Content.ToString());
                    }


                    if (selectedTypeСlothes.Count >= 2)
                    {
                        tb_TypeСlothes.Text = selectedTypeСlothes.Count.ToString();


                    }

                    if (selectedTypeСlothes.Count < 2 && selectedTypeСlothes.Count > 0)
                    {
                        
                        tb_TypeСlothes.Text = selectedTypeСlothes[0].ToString();
                    }
                    break;
                case "cb_Size":


                    if (!cb.IsChecked.Value)
                    {
                        tb_Size.Text = "";
                        selectedSize.Remove(cb.Content.ToString());
                    }
                    if (selectedSize.Contains(cb.Content))
                    {
                        break;
                    }
                    if (cb.IsChecked.Value)
                    {
                        tb_Size.Text = cb.Content.ToString();
                        selectedSize.Add(cb.Content.ToString());
                    }

                   


                    if (selectedSize.Count >= 2)
                    {
                        tb_Size.Text = selectedSize.Count.ToString();


                    }

                    if (selectedSize.Count < 2 && selectedSize.Count > 0)
                    {

                        tb_Size.Text = selectedSize[0].ToString();
                    }
                    break;

                case "cb_Color":




                    if (!cb.IsChecked.Value)
                    {

                        selectedColor.Remove(cb.Content.ToString());

                    }
                    if (selectedColor.Count < 4 || selectedColor.Count < 0)
                    {

                        lv_Header.Visibility = Visibility.Visible;
                        tb_CountColor.Visibility = Visibility.Collapsed;
                        tb_CountColor.Text = "";
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
                        tb_CountColor.Visibility = Visibility.Visible;
                        tb_CountColor.Text = selectedColor.Count.ToString();
                    }




                    break;

                default:
                    break;

                
            }


            

           

        }

        public class ModelColor
        {
            public string Name;
            
        }
       
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            

           
            



            List<int> idGenerals = new List<int>();

          
            for (int group = 0; group < selectedGroups.Count; group++)
            {
               
                for (int type = 0; type < selectedTypeСlothes.Count; type++)
                {
                    GeneralItem general = new GeneralItem();
                    int idGeneralItem = Context.GeneralItem.Max(x => x.GeneralItemID);
                    int idType = ListTypeСlothes.Where(x => x.TypeTitle == selectedTypeСlothes[type]).FirstOrDefault().TypeID;
                    int idGroup = ListCustomerGroup.Where(x => x.GruopTitle == selectedGroups[group]).FirstOrDefault().CustomerGroupID;
                    general.GeneralItemID = idGeneralItem+1;
                    
                    general.TypeID=idType;
                    general.CustomerGroupID= idGroup;
                    general.Model = "1";
                    general.Brand = "1";

                    Context.GeneralItem.Add(general);
                    idGenerals.Add(general.GeneralItemID);
                    Context.SaveChanges();

                }
            }

            for (int id = 0; id < idGenerals.Count; id++)
            {

                for (int size = 0; size < selectedSize.Count; size++)
                {
                  
                    for (int color = 0; color < selectedColor.Count; color++)
                    {
                        CurrentItem product = new CurrentItem();
                        int idCurrentItem = Context.CurrentItem.Max(x => x.CurrentItemID);
                        int idColor = ListColor.Where(x => x.ColorTitle == selectedColor[color]).FirstOrDefault().ColorID;
                        int idSize = ListSize.Where(x => x.SizeTitle == selectedSize[size]).FirstOrDefault().SizeID;
                        product.CurrentItemID = idCurrentItem + 1;
                        product.GeneralItemID = idGenerals[id];
                        product.ColorID = idColor;
                        product.SizeID = idSize;
                        product.IsActive = true;
                        product.Price = 1000;
                        Context.CurrentItem.Add(product);
                        Context.SaveChanges();

                    }
                }
            }





           
        }
        }
    }
    

