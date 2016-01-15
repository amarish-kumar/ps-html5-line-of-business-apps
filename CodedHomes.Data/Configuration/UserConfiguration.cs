﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodedHomes.Models;
using System.Data.Entity.ModelConfiguration;

namespace CodedHomes.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(p => p.Id).HasColumnOrder(0);

            this.Property(p => p.Username).IsRequired().HasMaxLength(200);
            this.Property(p => p.FirstName).IsOptional().HasMaxLength(200);
            this.Property(p => p.LastName).IsOptional().HasMaxLength(100);

            // relationship with roles
            this.HasMany(a => a.Roles).WithMany(b => b.Users).Map(m => {
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
                m.ToTable("webpages_UsersInRoles");
            });
        }
    }
}
