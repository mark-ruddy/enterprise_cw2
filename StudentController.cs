namespace University{
  public class StudentController : Controller {
    private StudentRepository repository = null;

    public StudentController() {
      this.repository = new StudentRepository();
    }

    public StudentController(StudentRepository repository) {
      this.repository = repository;
    }

    [HttpGet]
    public ActionResult index() {
      List<Student> students = (List<Student>)repository.SelectAll();
      return View(students);
    }

    [HttpGet]
    public ActionResult Details(int ID) {
      Student studentWithID = repository.SelectByID(ID);
      return View(studentWithID);
    }

    [HttpPost]
    public ActionResult Create(Student student) {
      if (ModelState.IsValid) {
        repository.Insert(student);
        repository.Save();
        return RedirectToAction("index");
      } else {
        return View(student);
      }
    }

    [HttpPost]
    public ActionResult Edit(Student student) {
      if (ModelState.IsValid) {
        repository.Update(student);
        repository.Save();
        return RedirectToAction("Index");
      } else {
        return View(student);
      }
    }

    [HttpGet, ActionName("Edit")]
    public ActionResult ConfirmEdit(int ID) {
      List<Student> students = (List<Student>)repository.SelectAll();
      ViewBag.Students = student;
      Student existing = repository.SelectByID(ID);
      return View(existing);
    }

    [HttpPost]
    public ActionResult Delete(int ID, int? replacementID) {
      repository.Delete(ID, replacementID);
      repository.Save();
      return RedirectToAction("Index");
    }

    [HttpGet, ActionName("Delete")]
    public ActionResult ConfirmDelete(int ID) {
      List<Student> students = (List<Student>)repository.SelectAll();
      students.RemoveAll(s => s.StudentID == ID);

      ViewBag.Students = students;
      Student studentWithID = repository.SelectByID(ID);
      return View(studentWithID);
    }
  }
}
