﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ClothWEPAPI.Models
{
    public partial class Account
    {
        public int CurrencyAccountId { get; set; }
        public int CustomerAccountId { get; set; }
        public string Account1 { get; set; }

        public virtual Currency CurrencyAccount { get; set; }
        public virtual Customer CustomerAccount { get; set; }
    }
}