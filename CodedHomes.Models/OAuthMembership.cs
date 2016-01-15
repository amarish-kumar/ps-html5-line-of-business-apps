using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodedHomes.Models
{
    /// <summary>
    /// simple membership
    /// </summary>
    public class OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
