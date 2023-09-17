using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prc3Web3BerzerkCodes.Modelos;

namespace prc3Web3BerzerkCodes.Data
{
    public class prc3Web3BerzerkCodesContext : DbContext
    {
        public prc3Web3BerzerkCodesContext (DbContextOptions<prc3Web3BerzerkCodesContext> options)
            : base(options)
        {
        }

        public DbSet<prc3Web3BerzerkCodes.Modelos.Asignatura> Asignatura { get; set; } = default!;

        public DbSet<prc3Web3BerzerkCodes.Modelos.Estudiante>? Estudiante { get; set; }

        public DbSet<prc3Web3BerzerkCodes.Modelos.Nota>? Nota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Notas)
                .WithOne(n => n.Estudiante)
                .HasForeignKey(n => n.EstudianteId);

            modelBuilder.Entity<Asignatura>()
                .HasMany(a => a.Notas)
                .WithOne(n => n.Asignatura)
                .HasForeignKey(n => n.AsignaturaId);
        }
    }
}
