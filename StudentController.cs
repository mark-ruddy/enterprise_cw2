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
      List<Student> model = (List<Student>)repository.SelectAll();
      return View(model);
    }

    [HttpGet]
    public ActionResult Details(int id) {
      Student existing = repository.SelectByID(id);
      return View(existing);
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

    [HttpGet, ActionName("Edit")]
    public ActionResult ConfirmEdit(int id) {
      List<Student> students = (List<Student>)repository.SelectAll();
      ViewBag.Students = student;
      Student existing = repository.SelectByID(id);
      return View(existing);
    }

    // TODO: continue with solution
  }
}
