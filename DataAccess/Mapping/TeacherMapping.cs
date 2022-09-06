using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class TeacherMapping : EntityTypeConfiguration<Teacher>
    {
        public TeacherMapping()
        {
            this.HasKey(t => t.ID); //Teacher class içerisinde ID propertysini Primary Key olarak ayarladım.

            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired(); // ID kolonunu identity olarak ayarladım ve bu kolonun boş geçilemeyeceğini söyledim.

            this.Property(t => t.FirstName).HasMaxLength(25).HasColumnType("nvarchar"); //Maksimum uzunluk ve veri tipi verildi.

            // Bireçok bağlantının bir kısmı
            this.HasRequired(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
