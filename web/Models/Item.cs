//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Item
    {
        public int Id { get; set; }
        public int Category_id { get; set; }
        public string name { get; set; }
        public string img_path { get; set; }    
        public  Category Category { get; set; }
        
    }
}
