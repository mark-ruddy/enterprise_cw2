using System.Data.Entity;

namespace University {
  public class UniversityContext : DbContext {
    public DbSet<Model.Student> Students { get; set; }
  }
}
