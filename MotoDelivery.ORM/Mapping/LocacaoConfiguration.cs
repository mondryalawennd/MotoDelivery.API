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
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {

            builder.HasKey(l => l.LocacaoId);

            builder.HasOne<Entregador>()
                .WithMany()
                .HasForeignKey(l => l.EntregadorId);

            builder.HasOne<Moto>()
                .WithMany()
                .HasForeignKey(l => l.MotoId);

            builder.Property(l => l.ValorDiaria)
               .IsRequired();

            builder.Property(l => l.DataInicio)
          .IsRequired()
          .HasConversion(
              v => v.ToUniversalTime(),
              v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(l => l.DataTermino)
                   .IsRequired()
                   .HasConversion(
                       v => v.ToUniversalTime(),
                       v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(l => l.DataPrevisaoTermino)
                   .IsRequired()
                   .HasConversion(
                       v => v.ToUniversalTime(),
                       v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(l => l.Plano)
                       .IsRequired()
                       .HasConversion<int>(); // converte o enum para inteiro no banco
        }
    }

}
