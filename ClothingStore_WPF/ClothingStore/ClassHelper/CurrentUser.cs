using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public class CurrentUser
    {
        public static Employee CurrentManager { get; set; } = null;
        public static Customer CurrentCustomer { get; set; }= null;
        public static Employee CurrentDirector { get; set; }= null;

    }
}
