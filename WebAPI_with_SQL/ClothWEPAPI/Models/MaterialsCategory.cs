// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ClothWEPAPI.Models
{
    public partial class MaterialsCategory
    {
        public int MaterialsId { get; set; }
        public int CategoriesId { get; set; }

        public virtual Category Categories { get; set; }
        public virtual Material Materials { get; set; }
    }
}