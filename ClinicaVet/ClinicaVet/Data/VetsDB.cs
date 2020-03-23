using ClinicaVet.Models; //Reconhecer os 'meus' Models
using Microsoft.EntityFrameworkCore; // reconhecer DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Data
{
    /// <summary>
    /// representa a BD do nosso sistema (Clinica Veterinária)
    /// à custa de um ORM (Object Relation Maper) - Entity Framework Core- Camada em cima do ASP
    /// para fazermos isto temos de adicionar componentes ao nosso sistema :
    ///  *** Install-Package Microsoft.EntityFrameworkCore.SqlServer ***
    /// *** Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.2 ***
    /// ###################################################################################################
    /// Tools - NutGet Package Manager - Package Manager Console (para isntalar pela consola)
    /// NuGet -> repositório de componentes (no fundo é uma bibilioteca)
    /// </summary>
    public class VetsDB : DbContext // DbContext sabe interagir com a BD
    {
        /// <summary>
        /// construtor que define e configura a BD
        /// </summary>
        /// <param name="options"> parametros de configuracao</param>
        public VetsDB(DbContextOptions<VetsDB> options) : base(options) { }

        // adicionar as 'tabelas' à BD
        public DbSet<Animais> Animais{ get; set; }
        public DbSet<Donos> Donos{ get; set; }
        public DbSet<Veterinarios> Veterinarios{ get; set; }
        public DbSet<Consultas> Consulta{ get; set; }
        // ver ficheiro startup
    }
}
