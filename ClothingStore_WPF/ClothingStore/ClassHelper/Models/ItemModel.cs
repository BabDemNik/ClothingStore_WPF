using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.ClassHelper
{
    public class ItemModel
    {
        //пол 
        public CustomerGroup Groups { get; set; }

        //категория
        public CategoryItem Categories { get; set; }

        //тип
        public TypeСlothes Types { get; set; }

        //бренд и модель
        public GeneralItem GeneralItems { get; set; }

        //цвет, размер, активность, цена
        public CurrentItem CurrentItems { get; set; }

        public Visibility visibility { get; set; }

        public int id { get; set; }
        public string group { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public bool isActive { get; set; }
        public decimal? price { get; set; }
        public byte[] photoPath { get; set; }
        public ItemModel(CurrentItem item)
        {
            

            id = item.CurrentItemID;
            GeneralItems = Context.GeneralItem.Where(x => x.GeneralItemID == item.GeneralItemID).First();
            group = Context.CustomerGroup.Where(x => x.CustomerGroupID == GeneralItems.CustomerGroupID).First().GruopTitle;
            type = Context.TypeСlothes.Where(x => x.TypeID == GeneralItems.TypeID).First().TypeTitle;
            Types = Context.TypeСlothes.Where(x => x.TypeID == GeneralItems.TypeID).First();
            category = Context.CategoryItem.Where(x => x.CategoryID == Types.CategoryID).First().CategoryTitle;
            brand = Context.GeneralItem.Where(x => x.GeneralItemID == GeneralItems.GeneralItemID).First().Brand;
            model = Context.GeneralItem.Where(x => x.GeneralItemID == GeneralItems.GeneralItemID).First().Model;
            color = Context.ColorItem.Where(x => x.ColorID==item.ColorID).First().ColorTitle;
            size = Context.SizeItem.Where(x => x.SizeID==item.SizeID).First().SizeTitle;
            isActive = item.IsActive;
            price = item.Price;


            var photo = Context.PhotoItem.ToList().Where(x => x.CurrentItemID == item.CurrentItemID).FirstOrDefault();
            if (photo!=null)
            {
                photoPath = photo.PhotoPath;
            }
            else 
            {
              
                photoPath = File.ReadAllBytes("C:\\Users\\Mike\\source\\repos\\ClothingStore\\ClothingStore\\Res\\Images\\defImg.jpeg");
            }

        }
        public ItemModel() 
        {
        }

       

        public static List<ItemModel> RefreshCatalog()
        {
            List<CurrentItem> data = new List<CurrentItem>();
            data = Context.CurrentItem.ToList();
            List<ItemModel> products = new List<ItemModel>();
            foreach (var i in data)
            {

                List<TypeСlothes> types = new List<TypeСlothes>();

                ItemModel product = new ItemModel(i);


                product.visibility = Visibility.Collapsed;
                if (CurrentUser.CurrentCustomer != null)
                {
                    product.visibility = Visibility.Collapsed;
                }

                if (CurrentUser.CurrentManager != null)
                {
                    product.visibility = Visibility.Visible;
                }


                products.Add(product);
            }

            return products;
        }
        public static void AddProducts (List<List<string>> lists)
        {
            foreach (List<string> selected in lists)
            {
                MessageBox.Show(selected.ToString());
            }
        }

    }
}
