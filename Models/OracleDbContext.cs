using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_form_1.Models;

namespace web_form_1.Models
{ 
public class OracleDbContext : DbContext
{
        static OracleDbContext()
        {
            Database.SetInitializer<OracleDbContext>(null);
        }

        public OracleDbContext(): base("name=OracleDbContext")
        {
        
        }
}
}