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
    public class EntregadorConfiguration : IEntityTypeConfiguration<Entregador>
    {
        public void Configure(EntityTypeBuilder<Entregador> builder)
        {
            builder.HasKey(m => m.Identificador);

            builder.Property(m => m.Identificador)
                .IsRequired()
                .HasMaxLength(36);


            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.DataNascimento)
              .IsRequired()
              .HasColumnType("date");

            builder.Property(e => e.CNPJ)
                .HasMaxLength(20);

            builder.Property(e => e.NumeroCNH)
                .HasMaxLength(20);

            builder.Property(e => e.TipoCNH)
                .HasMaxLength(10);

            builder.Property(e => e.ImagemCNHUrl)
                .HasMaxLength(200);

        }
    }
}