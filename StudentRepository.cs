namespace University{
  public class StudentRepository : IStudentRepository {
    private UniversityContext db = null;

    public StudentRepository() {
      this.db = new UniversityContext();
    }

    public StudentRepository(UniversityContext db) {
      this.db = db;
    }

    public IEnumerable<Student> SelectAll() {
      // TODO: sort by surname
      return db.Students.OrderBy(s => s.Surname).ToList();
    }

    public Student SelectByID(int id) {
      return db.Students.Find(id);
    }

    public void Insert(Student student) {
      db.Students.Add(student);
    }

    public void Update(Student student) {
      db.Entry(student).State = EntityState.Modified;
    }

    public void Delete(int id, int? replacementId) {
      Student existing = db.Students.Find(id);
      db.Students.Remove(existing);
    }

    public void Save() {
      db.SaveChanges();
    }
  }
}
