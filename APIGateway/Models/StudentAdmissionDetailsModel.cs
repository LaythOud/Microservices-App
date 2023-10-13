using System.ComponentModel.DataAnnotations;

namespace DotNet.Docker.Models;

public class StudentAdmissionDetailsModel
{
    public int Id { get; set; }
    
    public string StudentName { get; set; }
    
    public string StudentClass { get; set; }
    
    public bool Approved { get; set; }
}

