namespace AydosRobotics_WEB.Models
{
    public class Motor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Vendor { get; set; } = null!;
        public ICollection<RobotMotor> RobotMotors { get; set; } = new List<RobotMotor>();

    }
}
