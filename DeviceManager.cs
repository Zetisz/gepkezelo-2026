using System.Collections;

namespace PetrikGepkezelo;

public class DeviceManager: IEnumerable<Device>
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
}
