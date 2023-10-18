namespace APIGateway.Models
{
    public class StudentAttendanceDetails
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public double AttendencePercentage { get; set; }
        public string? StudentStatus { get; set; }
    }
}