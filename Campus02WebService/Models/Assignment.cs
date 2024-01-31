namespace Campus02WebService.Models
{
    public class Assignment
    {
        public long Id { get; set; } 
        public long UserId { get; set; } // darf nicht leer sein
        public long TaskId { get; set; } // darf nicht leer sein
        public string Timestamp { get; set; } // darf nicht leer sein
    }
}
