using MCExercise.Models.Relations.Many_to_Many;
using MCExercise.Models.Relations.One_to_Many;
using MCExercise.Models.Relations.One_to_One;
using Microsoft.EntityFrameworkCore;

namespace MCExercise.Data
{
    public class MCExerciseContext : DbContext 
    {

        public DbSet<University> Universities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Attempt> Attempts { get; set; }

        public MCExerciseContext(DbContextOptions<MCExerciseContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<University>()
                   .HasMany(university => university.Categories)
                   .WithOne(category => category.University);

            builder.Entity<Category>()
                   .HasMany(category => category.Exercises)
                   .WithOne(exercise => exercise.Category);

            builder.Entity<Exercise>()
                   .HasMany(exercise => exercise.Answers)
                   .WithOne(answer => answer.Exercise);

            builder.Entity<User>()
                   .HasOne(user => user.Photo)
                   .WithOne(photo => photo.User)
                   .HasForeignKey<Photo>(photo => photo.UserId);

            builder.Entity<Attempt>()
                   .HasKey(attempt => new { attempt.UserId, attempt.ExerciseId, attempt.AttemptDateTime });

            builder.Entity<Attempt>()
                   .HasOne<User>(attempt => attempt.User)
                   .WithMany(user => user.Attempts)
                   .HasForeignKey(attempt => attempt.UserId);

            builder.Entity<Attempt>()
                   .HasOne<Exercise>(attempt => attempt.Exercise)
                   .WithMany(exercise => exercise.Attempts)
                   .HasForeignKey(attempt => attempt.ExerciseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Attempt>()
                   .HasOne<Answer>(attempt => attempt.Answer)
                   .WithMany(answer => answer.Attempts)
                   .HasForeignKey(attempt => attempt.AnswerId);
            base.OnModelCreating(builder);
        }
    }
}
