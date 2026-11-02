namespace PetrikGepkezelo;

public class Device
{
    public Device(string name, string mac, uint ipv4, UInt128? ipv6)
    {
        Name = name;
        MAC = mac;
        Ipv4 = ipv4;
        Ipv6 = ipv6;
    }

    public string Name
    {
        get;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name must not be empty");
            }
            field = value;
        }
    }

    public string MAC
    {
        get;
        private set;
    }

    public UInt32 Ipv4
    {
        get;
        private set;
    }

    public UInt128? Ipv6
    {
        get;
        private set;
    }
}
