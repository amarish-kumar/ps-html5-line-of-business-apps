using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodedHomes.Models;
using System.Data.Entity;

namespace CodedHomes.Data
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(DbContext context):base(context)
        {
        }
    }
}
