using BargheNovin.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.DataBaseContext
{
    public class BargheNovinDBContext : DbContext
    {
        public BargheNovinDBContext(DbContextOptions<BargheNovinDBContext> options) : base(options)
        {

        }

        #region Logo
        #endregion
    }

}
