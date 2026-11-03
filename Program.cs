using PetrikGepkezelo;
using System.Numerics;

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
        string ipv4String = IPv4ToString(device);
        string ipv6String = IPv6ToString(device);
        Console.WriteLine("{0}: {1} {2} {3}", device.Name, device.Mac, ipv4String, ipv6String);
    }
}

static string IPv6ToString(Device device)
{
    var ipv6String = "";
    if (device.Ipv6 != null)
    {
        byte[] ipv6Bytes = ((BigInteger)device.Ipv6).ToByteArray(isUnsigned: true);
        for (int i = ipv6Bytes.Length - 1; i >= 0; i--)
        {
            ipv6String += ipv6Bytes[i].ToString("X2");
            if (i % 2 == 1)
            {
                ipv6String += ":";
            }
        }
    }
    else
    {
        ipv6String = "<none>";
    }

    return ipv6String;
}

static string IPv4ToString(Device device)
{
    byte[] ipv4Bytes = BitConverter.GetBytes(device.Ipv4);
    var ipv4String = string.Format("{0}.{1}.{2}.{3}", ipv4Bytes[3], ipv4Bytes[2], ipv4Bytes[1], ipv4Bytes[3]);
    return ipv4String;
}