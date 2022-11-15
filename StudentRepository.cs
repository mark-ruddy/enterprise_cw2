using System.Data.Entity;
using static University.Model;

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
      return db.Students.OrderBy(s => s.Surname).ToList();
    }

    public Student SelectByID(int ID) {
      return db.Students.Find(ID);
    }

    public void Insert(Student student) {
      db.Students.Add(student);
    }

    public void Update(Student student) {
      db.Entry(student).State = EntityState.Modified;
    }

    public void Delete(int ID, int? replacementID) {
      Student existing = db.Students.Find(ID);
      db.Students.Remove(existing);
    }

    public void Save() {
      db.SaveChanges();
    }

    public IEnumerable<String> CountryList() {
      var listOfCountries = File.ReadLines("countries.list").Select(line => new String(line)).ToList();
      return listOfCountries;
    }
  }
}
