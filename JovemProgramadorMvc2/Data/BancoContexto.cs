using JovemProgramadorMvc2.Data.Mapeamento;
using JovemProgramadorMvc2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc2.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        }

        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<EnderecoModel> EnderecoAluno { get; set; }
    }
}
