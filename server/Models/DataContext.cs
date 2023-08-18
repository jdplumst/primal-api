using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public required DbSet<Pokemon> Pokemon { get; set; }
        public required DbSet<Type> Type { get; set; }
        public required DbSet<Size> Size { get; set; }
        public required DbSet<Weight> Weight { get; set; }
        public required DbSet<EggGroup> EggGroup { get; set; }
        public required DbSet<Diet> Diet { get; set; }
        public required DbSet<Habitat> Habitat { get; set; }
        public required DbSet<Proficiency> Proficiency { get; set; }
        public required DbSet<Skill> Skill { get; set; }
        public required DbSet<Passive> Passive { get; set; }
        public required DbSet<Move> Move { get; set; }

    }
}
