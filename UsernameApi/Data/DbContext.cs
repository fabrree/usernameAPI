using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsernameApi.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }
        public DbSet<Username> Usernames { get; set; } 
        public DbSet<ApiKey> ApiKeys { get; set; } 
    }
