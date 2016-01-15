using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodedHomes.Models
{
    /// <summary>
    /// simple membership
    /// </summary>
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        /// <summary>
        /// EF shit
        /// </summary>
        public ICollection<User> Users { get; set; }

        public Role()
        {
            this.Users = new List<User>();
        }
    }
}
