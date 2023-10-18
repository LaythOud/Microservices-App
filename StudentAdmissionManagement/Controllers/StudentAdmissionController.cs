using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionManagement.Models;
using StudentAdmissionManagement.Data;
using System.Text.Json;


namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[Action]")]
    public class StudentAdmissionController : Controller
    {
        private readonly StudentAdmissionDetailsModelContext _context;

        public StudentAdmissionController(StudentAdmissionDetailsModelContext context)
        {
            _context = context;
        }

        // GET: StudentAdmission
        public string Index()
        {
            if (_context.StudentAdmissionDetailsModel != null && JsonSerializer.Serialize(_context.StudentAdmissionDetailsModel.ToList()) == "[]" && ModelState.IsValid)
            {
                var studentAdmissionDetailsModel = new StudentAdmissionDetailsModel
                {
                    StudentName = "Layth",
                    StudentClass = "MWS",
                    Approved = false
                };

                var studentAdmissionDetailsModel2 = new StudentAdmissionDetailsModel
                {
                    StudentName = "Kais",
                    StudentClass = "MWS",
                    Approved = false
                };

                var studentAdmissionDetailsModel3 = new StudentAdmissionDetailsModel
                {
                    StudentName = "Mohammad",
                    StudentClass = "MWS",
                    Approved = false
                };

                _context.Add(studentAdmissionDetailsModel);
                _context.Add(studentAdmissionDetailsModel2);
                _context.Add(studentAdmissionDetailsModel3);

                _context.SaveChanges();
            }

              return _context.StudentAdmissionDetailsModel != null ? 
                          JsonSerializer.Serialize(
                            _context.StudentAdmissionDetailsModel.
                            Where(b => !b.Approved).
                            ToList()
                          ) :
                          "Entity set 'StudentAdmissionDetailsModelContext.StudentAdmissionDetailsModel'  is null.";
        }

        // POST: StudentAdmission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public int Edit(int id)
        {

            if (!StudentAdmissionDetailsModelExists(id)){
                return 404;
            }

            StudentAdmissionDetailsModel studentAdmissionDetailsModel = _context.StudentAdmissionDetailsModel.FirstOrDefault(m => m.Id == id);;   

            try{   
                studentAdmissionDetailsModel.Approved = true;

                _context.Update(studentAdmissionDetailsModel);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
                
                    return 500;
            }

            return  200;
            
        }

        private bool StudentAdmissionDetailsModelExists(int id)
        {
          return (_context.StudentAdmissionDetailsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
