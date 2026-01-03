namespace AydosRobotics_WEB.Models
{
    public class RobotMotorDriver
    {
        public int MotorDriverId { get; set; }
        public MotorDriver MotorDriver { get; set; } = null!;
        public int RobotId { get; set; }
        public Robot Robot { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
