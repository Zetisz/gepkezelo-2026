using System.Numerics;
using PetrikGepkezelo;

Console.WriteLine("Petrik Network Device Manager");
Console.WriteLine("*****************************");

var manager = new DeviceManager();

while(true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine(" 1. List devices");
    Console.WriteLine(" 2. Load test data");
    Console.WriteLine(" 3. Exit");
    var option = Console.ReadLine();
    switch (option) {
        case "1":
            foreach (var device in manager)
            {
                byte[] ipv4Bytes = BitConverter.GetBytes(device.Ipv4);
                var ipv4String = string.Format("{0}.{1}.{2}.{3}", ipv4Bytes[3], ipv4Bytes[2], ipv4Bytes[1], ipv4Bytes[3]);

                byte[] ipv6Bytes = ((BigInteger)device.Ipv6).ToByteArray(isUnsigned: true);
                var ipv6String = "";
                for (int i = ipv6Bytes.Length - 1; i >= 0; i--)
                {
                    ipv6String += ipv6Bytes[i].ToString("X2");
                    if (i % 2 == 1)
                    {
                        ipv6String += ":";
                    }
                }
                Console.WriteLine("{0}: {1} {2} {3}", device.Name, device.MAC, ipv4String, ipv6String);
            }
            break;
        case "2":
            manager.LoadTestData();
            break;
        case "3":
            // Exit program
            return;
    }
}
