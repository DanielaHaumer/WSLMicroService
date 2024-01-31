namespace Campus02WebService.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } // Name muss max. 8 Zeichen sein und darf nicht leer sein
        public string Email { get; set; } // Muss email-Format haben
        public string Role { get; set; } // Muss max. 8 Zeichen lang sein und darf nicht leer sein
    }
}
