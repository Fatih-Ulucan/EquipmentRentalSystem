namespace EquipmentRentalSystem.Models;


public class Laptop: Equipment
{
  
    public string OperatingSystem { get; private set; }
    public int RamSizeInGB { get; private set; }


    public Laptop(string name, string operatingSystem, int ramSizeInGB) : base(name)
    {
        OperatingSystem = operatingSystem;
        RamSizeInGB = ramSizeInGB;
    }
}