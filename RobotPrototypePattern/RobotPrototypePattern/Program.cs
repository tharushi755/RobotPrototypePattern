using System;

namespace RobotPrototypePattern
{
    // Prototype Interface
    public interface IRobotPrototype
    {
        IRobotPrototype Clone();
    }

    // Base Robot class
    public abstract class Robot : IRobotPrototype
    {
        public string ModelName { get; set; }
        public double BatteryCapacity { get; set; }
        public string SoftwareVersion { get; set; }

        protected Robot(string modelName, double batteryCapacity, string softwareVersion)
        {
            ModelName = modelName;
            BatteryCapacity = batteryCapacity;
            SoftwareVersion = softwareVersion;
        }

        // Prototype Pattern - Clone method
        public abstract IRobotPrototype Clone();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Model Name       : {ModelName}");
            Console.WriteLine($"Battery Capacity : {BatteryCapacity} hours");
            Console.WriteLine($"Software Version  : {SoftwareVersion}");
        }
    }

    // Service Robot
    public class ServiceRobot : Robot
    {
        public string ServiceTask { get; set; }

        public ServiceRobot(
            string modelName,
            double batteryCapacity,
            string softwareVersion,
            string serviceTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            ServiceTask = serviceTask;
        }

        public override IRobotPrototype Clone()
        {
            return new ServiceRobot(
                ModelName,
                BatteryCapacity,
                SoftwareVersion,
                ServiceTask);
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("----- Service Robot -----");
            base.DisplayDetails();
            Console.WriteLine($"Service Task      : {ServiceTask}");
            Console.WriteLine();
        }
    }

    // Industrial Robot
    public class IndustrialRobot : Robot
    {
        public string IndustrialTask { get; set; }

        public IndustrialRobot(
            string modelName,
            double batteryCapacity,
            string softwareVersion,
            string industrialTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            IndustrialTask = industrialTask;
        }

        public override IRobotPrototype Clone()
        {
            return new IndustrialRobot(
                ModelName,
                BatteryCapacity,
                SoftwareVersion,
                IndustrialTask);
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("----- Industrial Robot -----");
            base.DisplayDetails();
            Console.WriteLine($"Industrial Task   : {IndustrialTask}");
            Console.WriteLine();
        }
    }

    // Entertainment Robot
    public class EntertainmentRobot : Robot
    {
        public string EntertainmentFeature { get; set; }

        public EntertainmentRobot(
            string modelName,
            double batteryCapacity,
            string softwareVersion,
            string entertainmentFeature)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            EntertainmentFeature = entertainmentFeature;
        }

        public override IRobotPrototype Clone()
        {
            return new EntertainmentRobot(
                ModelName,
                BatteryCapacity,
                SoftwareVersion,
                EntertainmentFeature);
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("----- Entertainment Robot -----");
            base.DisplayDetails();
            Console.WriteLine(
                $"Entertainment Feature : {EntertainmentFeature}");
            Console.WriteLine();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ROBOT FACTORY - PROTOTYPE PATTERN");
            Console.WriteLine("==================================");
            Console.WriteLine();

            // Create original Service Robot
            ServiceRobot serviceRobot = new ServiceRobot(
                "ServiceBot-A1",
                12,
                "v1.0",
                "Hospital Assistance");

            Console.WriteLine("Original Robot:");
            serviceRobot.DisplayDetails();

            // Clone Service Robot
            ServiceRobot clonedServiceRobot =
                (ServiceRobot)serviceRobot.Clone();

            // Customize cloned robot
            clonedServiceRobot.ModelName = "ServiceBot-A2";
            clonedServiceRobot.BatteryCapacity = 18;
            clonedServiceRobot.SoftwareVersion = "v2.0";

            Console.WriteLine("Cloned and Customized Robot:");
            clonedServiceRobot.DisplayDetails();


            // Create original Industrial Robot
            IndustrialRobot industrialRobot = new IndustrialRobot(
                "IndustrialBot-X1",
                20,
                "v1.5",
                "Welding");

            Console.WriteLine("Original Robot:");
            industrialRobot.DisplayDetails();

            // Clone Industrial Robot
            IndustrialRobot clonedIndustrialRobot =
                (IndustrialRobot)industrialRobot.Clone();

            // Customize cloned robot
            clonedIndustrialRobot.ModelName = "IndustrialBot-X2";
            clonedIndustrialRobot.BatteryCapacity = 25;
            clonedIndustrialRobot.SoftwareVersion = "v2.0";

            Console.WriteLine("Cloned and Customized Robot:");
            clonedIndustrialRobot.DisplayDetails();


            // Create original Entertainment Robot
            EntertainmentRobot entertainmentRobot =
                new EntertainmentRobot(
                    "EntertainBot-E1",
                    10,
                    "v1.0",
                    "Dancing and Music");

            Console.WriteLine("Original Robot:");
            entertainmentRobot.DisplayDetails();

            // Clone Entertainment Robot
            EntertainmentRobot clonedEntertainmentRobot =
                (EntertainmentRobot)entertainmentRobot.Clone();

            // Customize cloned robot
            clonedEntertainmentRobot.ModelName = "EntertainBot-E2";
            clonedEntertainmentRobot.BatteryCapacity = 15;
            clonedEntertainmentRobot.SoftwareVersion = "v1.5";

            Console.WriteLine("Cloned and Customized Robot:");
            clonedEntertainmentRobot.DisplayDetails();


            Console.WriteLine("==================================");
            Console.WriteLine("Robot cloning completed successfully.");

            Console.ReadKey();
        }
    }
}
