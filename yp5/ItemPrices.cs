//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace yp5
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemPrices
    {
        public int PriceID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> PriceDate { get; set; }
    
        public virtual Items Items { get; set; }
    }
}
