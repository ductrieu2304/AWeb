//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_Auction.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
        }
    
        public int CatID { get; set; }
        public string CatName { get; set; }
        public Nullable<int> ParentID { get; set; }
    
        public virtual ICollection<Category> Categories { get; set; }
        public virtual Category Category1 { get; set; }
    }
}