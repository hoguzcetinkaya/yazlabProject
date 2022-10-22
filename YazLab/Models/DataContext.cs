using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YazLab.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dbConnection")
        {
        }

        

       
    }
}