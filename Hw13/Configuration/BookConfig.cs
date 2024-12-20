﻿using Hw13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hw13.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasOne(b => b.Member).WithMany(u => u.Books).HasForeignKey(b => b.MemberId);
        }
    }
}
