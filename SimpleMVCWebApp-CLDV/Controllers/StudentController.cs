using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SimpleMVCWebApp_CLDV.Models;

namespace SimpleMVCWebApp_CLDV.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> _students = new List<Student>();

        // GET: Student
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = _students.Count + 1;
                _students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/1 (example: edit student with ID 1)
        public IActionResult Edit(int id)
        {
            Student student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(); // Resource not found
            }

            return View(student);
        }

        // POST: Student/Edit/1 (example: edit student with ID 1)
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Student existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                    existingStudent.Grade = student.Grade;
                    // Update other properties as needed

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound(); // Resource not found
                }
            }

            return View(student);
        }

        
        public IActionResult Delete(int id)
        {
            Student studentToDelete = _students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete == null)
            {
                return NotFound(); // If student not found, return 404 Not Found
            }

            return View(studentToDelete);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] 
        public IActionResult DeleteConfirmed(int id)
        {
            Student studentToDelete = _students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                _students.Remove(studentToDelete);
                
                return RedirectToAction("Index"); // Redirect to student list after deletion
            }

            return NotFound(); // If student not found, return 404 Not Found
        }


    }
}
