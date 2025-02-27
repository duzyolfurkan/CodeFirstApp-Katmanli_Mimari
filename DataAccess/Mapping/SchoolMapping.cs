﻿using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class SchoolMapping : EntityTypeConfiguration<School>
    {
        public SchoolMapping()
        {
            this.HasKey(s => s.ID);
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(s => s.Name).HasMaxLength(100).HasColumnType("nvarchar").IsUnicode(true);

            //Öğretmen ile bireçok bağlantının çok kısmı bağlantı
            this.HasMany(s => s.Teachers)
                .WithRequired(t => t.School)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
