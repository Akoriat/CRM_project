using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM_project.Models;

namespace CRM_project.Data
{
    public class CRM_projectContext : DbContext
    {
        public CRM_projectContext (DbContextOptions<CRM_projectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Exercise>()
            //    .HasOne(x => x.Teacher)
            //.WithMany(t => t.Exercises)
            //.HasForeignKey(e => e.TeacherID)
            //.OnDelete(DeleteBehavior.ClientSetNull) ; // Изменение настроек каскадного удаления
            /*
             * modelBuilder.Entity<Exercise>() 
             * Этот метод указывает на конфигурацию для сущности Exercise (предположительно, класс упражнений в вашем приложении).
             * .HasRequired(e => e.Teacher)
             * Этот метод указывает, что упражнение должно иметь преподавателя (внешний ключ TeacherId в таблице Exercise не может быть NULL).
             * .WithMany(t => t.Exercises)
             * Этот метод указывает, что связь между упражнениями и преподавателями является "один ко многим" (один преподаватель может иметь много упражнений).
             * .HasForeignKey(e => e.TeacherId)
             * Этот метод указывает, что внешний ключ TeacherId в таблице Exercise связан с атрибутом TeacherId в таблице Teacher.
             * .WillCascadeOnDelete(false)
             * Этот метод указывает, что каскадное удаление должно быть отключено для связи между упражнениями и преподавателями. 
             * То есть, когда преподаватель удаляется, упражнения, связанные с этим преподавателем, не будут автоматически удалены (чтобы избежать потенциальных циклических или множественных путей удаления).
             */
        }
        public DbSet<CRM_project.Models.Classroom> Classroom { get; set; } = default!;
        public DbSet<CRM_project.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<CRM_project.Models.Group> Group { get; set; } = default!;
        public DbSet<CRM_project.Models.Student> Student { get; set; } = default!;
        public DbSet<CRM_project.Models.Subject> Subject { get; set; } = default!;
        public DbSet<CRM_project.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<CRM_project.Models.TeacherAndSubject> TeacherAndSubject { get; set; } = default!;
    }
}
