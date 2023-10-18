using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceManagement.Data;
using StudentAttendanceManagement.Models;
using System.Text.Json;

namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[Action]")]
    public class StudentAttendanceController : Controller
    {
        private readonly StudentAttendanceDetailsContext _context;

        public StudentAttendanceController(StudentAttendanceDetailsContext context)
        {
            _context = context;
        }

        // GET: StudentAttendance
        public string Index()
        {
            if (_context.StudentAttendanceDetails != null && JsonSerializer.Serialize(_context.StudentAttendanceDetails.ToList()) == "[]" && ModelState.IsValid)
            {
                var studentAttendanceDetails = new StudentAttendanceDetails
                {
                    StudentName = "Layth",
                    AttendencePercentage = 45.5,
                    StudentStatus = "Not Detemined"
                };

                var studentAttendanceDetails2 = new StudentAttendanceDetails
                {
                    StudentName = "Kais",
                    AttendencePercentage = 50,
                    StudentStatus = "Not Detemined"
                };

                var studentAttendanceDetails3 = new StudentAttendanceDetails
                {
                    StudentName = "Mohammad",
                   AttendencePercentage = 50.5,
                    StudentStatus = "Not Detemined"
                };

                _context.Add(studentAttendanceDetails);
                _context.Add(studentAttendanceDetails2);
                _context.Add(studentAttendanceDetails3);

                _context.SaveChanges();
            }

              return _context.StudentAttendanceDetails != null ? 
                          JsonSerializer.Serialize(
                            _context.StudentAttendanceDetails.
                            ToList()
                          ) :
                          "Entity set '_context.StudentAttendanceDetails'  is null.";
        }

       

        // POST: StudentAttendance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public int Edit(int id)
        {

            if (!StudentAttendanceDetailsExists(id)){
                return 404;
            }

            StudentAttendanceDetails studentAdmissionDetailsModel = _context.StudentAttendanceDetails.FirstOrDefault(m => m.Id == id);;   

            try{   
                if(studentAdmissionDetailsModel.AttendencePercentage > 50){
                    studentAdmissionDetailsModel.StudentStatus = "Success";
                }else{
                    studentAdmissionDetailsModel.StudentStatus = "Fail";
                }

                _context.Update(studentAdmissionDetailsModel);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
                
                    return 500;
            }

            return  200;
            
        }

        private bool StudentAttendanceDetailsExists(int id)
        {
          return (_context.StudentAttendanceDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
