using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KnightsOfGoodProject.Models;

namespace KnightsOfGoodProject.Data
{
    //Наследуемся от системного класса dbcontext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Проецируем наши классы на базу данных
   
       public DbSet<ApplicationUser> ApplicationUser { get; set; }

      
        //Заполняем БД значениями по умолчанию
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
