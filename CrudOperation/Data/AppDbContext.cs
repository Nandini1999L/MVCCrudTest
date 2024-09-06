using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace CrudOperation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=testDB") { }
       
        public DbSet<Employee> Employees {  get; set; }
    }
}