using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegisterSubject.Data;
using RegisterSubject.Models;
using System.Text.Json;

namespace RegisterSubject.Controllers
{
    [Route("api/[Action]")]
    public class RegisterSubjectController : Controller
    {
        private readonly SubjectContext _context;

        public RegisterSubjectController(SubjectContext context)
        {
            _context = context;
        }

        // GET: RegisterSubject
        public string Index()
        {
               if (_context.Subject != null && JsonSerializer.Serialize(_context.Subject.ToList()) == "[]" && ModelState.IsValid)
            {
                var Subject = new Subject
                {
                    SubjectName = "WDC",
                    NumberOfStudent = 0
                };

                var Subject2 = new Subject
                {
                    SubjectName = "WSC",
                    NumberOfStudent = 0
                };

                var Subject3 = new Subject
                {
                    SubjectName = "WDL",
                    NumberOfStudent = 0
                };

                _context.Add(Subject);
                _context.Add(Subject2);
                _context.Add(Subject3);

                _context.SaveChanges();
            }

              return _context.Subject != null ? 
                          JsonSerializer.Serialize(
                            _context.Subject.
                            ToList()
                          ) :
                          "Entity set 'SubjectContext.Subject'  is null.";
        
        }



        // POST: RegisterSubject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public int Edit(int id)
        {
             if (!SubjectExists(id)){
                return 404;
            }

            Subject subject = _context.Subject.FirstOrDefault(m => m.Id == id);;   

            try{   
                subject.NumberOfStudent ++;

                _context.Update(subject);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
                
                    return 500;
            }

            return  200;
        }

        private bool SubjectExists(int id)
        {
          return (_context.Subject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
