using Ingenium.Modules.Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingenium.Modules.Contacts.ORM.Configurations;

internal sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact", "Contacts").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(256);
        builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(256);
        builder.Property(x => x.IsActive).HasColumnName("IsActive");
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
        builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(256);
        builder.Property(x => x.TelephoneNumber).HasColumnName("TelephoneNumber").HasMaxLength(32);
    }
}