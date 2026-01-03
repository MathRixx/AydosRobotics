using AydosRobotics_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AydosRobotics_WEB.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Robot> Robots { get; set; } = null!;
        public DbSet<Motor> Motors { get; set; } = null!;
        public DbSet<MotorDriver> MotorDrivers { get; set; } = null!;
        public DbSet<RobotMotor> RobotMotors { get; set; } = null!;
        public DbSet<RobotMotorDriver> RobotMotorDrivers { get; set; } = null!;
        public DbSet<Models.DriveType> DriveTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ------------------------------
            // Robot ↔ Motor (many-to-many via RobotMotor)
            // ------------------------------
            modelBuilder.Entity<RobotMotor>()
                .HasKey(rm => new { rm.RobotId, rm.MotorId });

            modelBuilder.Entity<RobotMotor>()
                .HasOne(rm => rm.Robot)
                .WithMany(r => r.RobotMotors)
                .HasForeignKey(rm => rm.RobotId);

            modelBuilder.Entity<RobotMotor>()
                .HasOne(rm => rm.Motor)
                .WithMany(m => m.RobotMotors)
                .HasForeignKey(rm => rm.MotorId);

            // ------------------------------
            // Robot ↔ MotorDriver (many-to-many via RobotMotorDriver)
            // ------------------------------
            modelBuilder.Entity<RobotMotorDriver>()
                .HasKey(rmd => new { rmd.RobotId, rmd.MotorDriverId });

            modelBuilder.Entity<RobotMotorDriver>()
                .HasOne(rmd => rmd.Robot)
                .WithMany(r => r.RobotMotorDrivers)
                .HasForeignKey(rmd => rmd.RobotId);

            modelBuilder.Entity<RobotMotorDriver>()
                .HasOne(rmd => rmd.MotorDriver)
                .WithMany(md => md.RobotMotorDrivers)
                .HasForeignKey(rmd => rmd.MotorDriverId);

            // ------------------------------
            // Robot ↔ DriveType (one-to-one)
            // ------------------------------
            modelBuilder.Entity<Robot>()
                .HasOne(r => r.DriveType)
                .WithOne(dt => dt.Robot)
                .HasForeignKey<Models.DriveType>(dt => dt.RobotId);

            // ------------------------------
            // Team ↔ Robot (one-to-many)
            // ------------------------------
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Robot)
                .WithOne(r => r.Team)
                .HasForeignKey(r => r.TeamId);

            modelBuilder.Entity<Models.DriveType>().HasData(
                new List<Models.DriveType>() {
                    new Models.DriveType(){ Id = 1, Name="Tank Drive"},
                    new Models.DriveType(){ Id = 2, Name="Mecanum Drive"},
                    new Models.DriveType(){ Id = 3, Name="Swerve Drive"},
                    new Models.DriveType(){ Id = 4, Name="H Drive"},
                    new Models.DriveType(){ Id = 5, Name="Octanum/Butterfly Drive"},
                    new Models.DriveType(){ Id = 6, Name="Kiwi Drive (Omni Wheels)"},
                    new Models.DriveType(){ Id = 7, Name="Holonomic Drive (Omni Wheel X-Drive)"},
                    new Models.DriveType(){ Id = 8, Name="Treads"},
                }
            );
            modelBuilder.Entity<Motor>().HasData(
                new List<Motor>()
                {
                    new Motor(){ Id = 1, Name = "NEO", Type = "Brushless", Vendor = "REV Robotics"},
                    new Motor(){ Id = 2, Name = "NEO 550", Type = "Brushless", Vendor = "REV Robotics"},
                    new Motor(){ Id = 3, Name = "Falcon 500", Type = "Brushless", Vendor = "Falcon FX"},
                    new Motor(){ Id = 4, Name = "CIM", Type = "Brushed", Vendor = "AndyMark"},
                    new Motor(){ Id = 5, Name = "mini CIM", Type = "Brushed", Vendor = "AndyMark"},
                    new Motor(){ Id = 6, Name = "BAG", Type = "Brushed", Vendor = "AndyNark"},
                    new Motor(){ Id = 7, Name = "775pro", Type = "Brushed", Vendor = "VEX"},
                    new Motor(){ Id = 8, Name = "RedLine", Type = "Brushed", Vendor = "AndyNark"},
                }
            );
            modelBuilder.Entity<MotorDriver>().HasData(
                new List<MotorDriver>()
                {
                    new MotorDriver(){ Id = 1, Name = "Talon SR", Type = "PWM", Vendor = "CTRE"},
                    new MotorDriver(){ Id = 2, Name = "Talon SRX", Type = "CAN", Vendor = "CTRE"},
                    new MotorDriver(){ Id = 3, Name = "Victor SP", Type = "PWM", Vendor = "VEX Robotics"},
                    new MotorDriver(){ Id = 4, Name = "Victor SPX", Type = "CAN", Vendor = "VEX Robotics"},
                    new MotorDriver(){ Id = 5, Name = "SPARK", Type = "PWM", Vendor = "REV Robotics"},
                    new MotorDriver(){ Id = 6, Name = "SPARK MAX", Type = "CAN", Vendor = "REV Robotics"},
                }
            );
        }

    }
}
