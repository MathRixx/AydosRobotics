namespace AydosRobotics_WEB.Models
{
    public class MotorDriver
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? Vendor { get; set; }
        public ICollection<RobotMotorDriver> RobotMotorDrivers { get; set; } = new List<RobotMotorDriver>();
    }
}
