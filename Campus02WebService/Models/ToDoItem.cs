namespace Campus02WebService.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public string Description { get; set; } // Darf nicht leer sein und darf max. 12 Zeichen lang sein
        public string DueDate { get; set; } // darf nicht leer sein
        public string Status { get; set; } // darf nicht leer sein, und max. 12 Zeichen haben

    }
}
