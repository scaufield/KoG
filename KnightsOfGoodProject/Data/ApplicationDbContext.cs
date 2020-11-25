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
   
         public DbSet<TextField> TextFields { get; set; }
         public DbSet<ServiceItem> ServiceItems { get; set; }
         public DbSet<ApplicationUser> ApplicationUser { get; set; }
         public DbSet<EventsAndUserModel> EventsAndUser { get; set; }

      
        //Заполняем БД значениями по умолчанию
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            //Если сущности нет в БД то создаем нового пользователя - значит эта строчка
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            //В этой таблице связываем админа с его ролью
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            //Создаем три объекта в бд, - это наши текстовые поля
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

            modelBuilder.Entity<EventsAndUserModel>()
                .HasKey(t => new { t.UserId, t.EventId });



            modelBuilder.Entity<EventsAndUserModel>()
                .HasOne(sc => sc.User)
                .WithMany(c => c.UserEvents)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventsAndUserModel>()
                .HasOne(sc => sc.Event)
                .WithMany(s => s.Users)
                .HasForeignKey(sc => sc.EventId);


        }
    }
}
