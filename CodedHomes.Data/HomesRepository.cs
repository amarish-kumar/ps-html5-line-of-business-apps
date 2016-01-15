using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodedHomes.Models;
using System.Data.Entity;

namespace CodedHomes.Data
{
    public class HomesRepository : GenericRepository<Home>
    {
        public HomesRepository(DbContext context):base(context)
        {
        }
    }
}
