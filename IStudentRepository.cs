namespace University{
  interface IStudentRepository{
    IEnumerable<Student> SelectAll();
    Student SelectByID(int id);
    void Insert(Student.obj);
    void Update(Student.obj);
    void Delete(int id, int? replacementID);
    void Save();
  }
}
