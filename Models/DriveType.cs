namespace AydosRobotics_WEB.Models
{
    public class DriveType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? RobotId { get; set; }
        public Robot? Robot { get; set; }
    }
}
