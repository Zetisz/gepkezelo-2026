using PetrikGepkezelo;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Petrik Network Device Manager");
        Console.WriteLine("*****************************");

        var manager = new NetworkDeviceManager();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine(" 1. List devices");
            Console.WriteLine(" 2. Load test data");
            Console.WriteLine(" 3. Exit");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    WriteDevicesToConsole(manager);
                    break;
                case "2":
                    manager.LoadTestData();
                    break;
                case "3":
                    // Exit program
                    return;
            }
        }

        static void WriteDevicesToConsole(NetworkDeviceManager manager)
        {
            foreach (var device in manager)
            {
                string ipv4String = manager.IPv4ToString(device);
                string ipv6String = manager.IPv6ToString(device);
                Console.WriteLine("{0}: {1} {2} {3}", device.Name, device.Mac, ipv4String, ipv6String);
            }
        }
    }
}