using System.ComponentModel.DataAnnotations;

namespace StudentAdmissionManagement.Models
{
    public class StudentAdmissionDetailsModel
    {
        public int Id { get; set; }
        
        public string? StudentName { get; set; }
        
        public string? StudentClass { get; set; }
        
        public bool Approved { get; set; }
    }
}
