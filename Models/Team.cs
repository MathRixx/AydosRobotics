namespace AydosRobotics_WEB.Models
{
    public class Team
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Season { get; set; } = DateTime.Now.Year;
        public string? Regional { get; set; }
        public int TeamNumber { get; set; }
        public string TeamName { get; set; } = null!;
        public int TeamPitNo { get; set; }
        public string? School { get; set; }
        public string? Region { get; set; }
        public string? Mentor { get; set; }
        public ICollection<Robot> Robot { get; set; }


    }
}
