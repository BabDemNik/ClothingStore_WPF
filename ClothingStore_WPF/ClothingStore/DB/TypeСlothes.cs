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
    
    public partial class TypeСlothes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeСlothes()
        {
            this.GeneralItem = new HashSet<GeneralItem>();
        }
    
        public int TypeID { get; set; }
        public int CategoryID { get; set; }
        public string TypeTitle { get; set; }
    
        public virtual CategoryItem CategoryItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralItem> GeneralItem { get; set; }
    }
}
