namespace AydosRobotics_WEB.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
    }
}
