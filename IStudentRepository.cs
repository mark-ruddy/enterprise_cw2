using System.Data.Entity;
using University.Model.Student;

namespace University{
  interface IStudentRepository{
    IEnumerable<Student> SelectAll();
    Student SelectByID(int id);
    void Insert(Student student);
    void Update(Student student);
    void Delete(int id, int? replacementID);
    void Save();
  }
}
