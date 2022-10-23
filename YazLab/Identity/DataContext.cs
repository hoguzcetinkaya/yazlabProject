using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YazLab.Identity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dbConnection")
        {
        }
    }
}