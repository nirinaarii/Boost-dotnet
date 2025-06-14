namespace Backend.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int? Age { get; set; }
        public string? Adresse { get; set; }
    }
}