using System.ComponentModel.DataAnnotations;

namespace AydosRobotics_WEB.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Season { get; set; } = DateTime.Now.Year;
        public string? Regional { get; set; }
        [Required]
        public string RobotName { get; set; } = null!;
        [Required]
        public int Points { get; set; }
        [Required]
        public bool Taxi { get; set; }
        [Required]
        public string Details { get; set; } = null!;
        [Required]
        public string AutonomousDetails { get; set; } = null!;
        [Required]
        public DriveType DriveType { get; set; } = null!;
        [Required]
        public ICollection<RobotMotor> RobotMotors { get; set; } = new List<RobotMotor>();
        [Required]
        public ICollection<RobotMotorDriver> RobotMotorDrivers { get; set; } = new List<RobotMotorDriver>();
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

    }
}
