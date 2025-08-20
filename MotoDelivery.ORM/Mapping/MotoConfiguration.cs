using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.ORM.Mapping
{
    public class MotoConfiguration : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.HasKey(m => m.Identificador);

            builder.Property(m => m.Identificador)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(m => m.Ano)
                .IsRequired();

            builder.Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Placa)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(m => m.Placa)
                .IsUnique();
        }
    }
}
