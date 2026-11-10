using System.Collections;
using System.Numerics;

namespace PetrikGepkezelo;

public class NetworkDeviceManager: IEnumerable<Device>
{
    List<Device> devices = new();

    public void LoadTestData()
    {
        devices.Add(new Device("ePhone", "11:22:33:aa:bb:cc", 0x0a_00_00_05, new UInt128(0xfe08_0000_0000_0000, 0x0000_0000_0000_0005)));
        devices.Add(new Device("Dad's Desktop", "11:22:33:aa:bb:dd", 0x0a_00_00_06, new UInt128(0xfe08_0000_0000_0000, 0x0000_0000_0000_0006)));
        devices.Add(new Device("Petrik SmartLamp", "11:22:33:aa:bb:ee", 0x0a_00_00_09, null));
    }

    public IEnumerator<Device> GetEnumerator()
    {
        return devices.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal static string IPv6ToString(Device device)
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

    public static string IPv4ToString(Device device)
    {
        byte[] ipv4Bytes = BitConverter.GetBytes(device.Ipv4);
        var ipv4String = string.Format("{0}.{1}.{2}.{3}", ipv4Bytes[3], ipv4Bytes[2], ipv4Bytes[1], ipv4Bytes[3]);
        return ipv4String;
    }
}
