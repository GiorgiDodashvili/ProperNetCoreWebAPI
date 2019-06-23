using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProperWebAPI.Domain;

namespace ProperWebAPI.Data
{
    //mysql user:WebApiUser password: n4C1YI8oVEXIV57i1OSOxukInaDavI
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
