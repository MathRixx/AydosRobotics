using System.ComponentModel.DataAnnotations;

namespace AydosRobotics_WEB.Models
{
    public class RobotMotor
    {
        public int RobotId { get; set; }
        public Robot Robot { get; set; } = null!;

        public int MotorId { get; set; }
        public Motor Motor { get; set; } = null!;

        public int Quantity { get; set; }
    }
} 
