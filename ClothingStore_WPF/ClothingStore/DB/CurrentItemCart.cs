//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothingStore.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CurrentItemCart
    {
        public int CurrentItemID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual CurrentItem CurrentItem { get; set; }
    }
}
