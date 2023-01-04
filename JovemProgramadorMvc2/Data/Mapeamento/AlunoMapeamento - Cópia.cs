using JovemProgramadorMvc2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Data.Mapeamento
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.ToTable("EnderecoAluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.IdAluno).HasColumnType("int");
            builder.Property(t => t.logradouro).HasColumnType("varchar(200)");
            builder.Property(t => t.complemento).HasColumnType("varchar(200)");
            builder.Property(t => t.bairro).HasColumnType("varchar(50)");
            builder.Property(t => t.localidade).HasColumnType("varchar(50)");
            builder.Property(t => t.uf).HasColumnType("varchar(2)");
            builder.Property(t => t.ddd).HasColumnType("varchar(3)");
        }
    }
}
