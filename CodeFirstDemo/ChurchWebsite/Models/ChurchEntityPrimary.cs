using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchWebsite.Models
{
  public   class ChurchEntityPrimary: DbContext
    {
      public ChurchEntityPrimary()
       {
           AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
       }
       public DbSet<UserInfo> UserInfo { get; set; }
       public DbSet<Leader> Leaders { get; set; }
       public DbSet<Ministry> Ministries { get; set; }
       public DbSet<Email> Emails { get; set; }
    }
}
