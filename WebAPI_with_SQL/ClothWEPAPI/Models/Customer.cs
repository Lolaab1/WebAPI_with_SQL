// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ClothWEPAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? PhoneNumber { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}