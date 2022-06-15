﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_with_SQL.Models;

namespace WebAPI_with_SQL.Date
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
            public DbSet<Users> users { get; set; }
    
    }
}
