﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodedHomes.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodedHomes.Data.Configuration
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            this.ToTable("webpages_OAuthMembership");

            // both keys
            this.HasKey(k => new { k.Provider, k.ProviderUserId });

            this.Property(p => p.Provider).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderUserId).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            this.Property(p => p.UserId).IsRequired();
        }
    }
}
