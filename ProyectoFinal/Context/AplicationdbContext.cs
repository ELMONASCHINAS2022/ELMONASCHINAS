using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Context
{
    public class AplicationdbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server = localhost; database = proyectofinal; user = root; password=");
        }

        public DbSet<Usuario> Usuarios { get; set; }
         
    }
}
