using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodedHomes.Models
{
    /// <summary>
    /// audit fields
    /// </summary>
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
