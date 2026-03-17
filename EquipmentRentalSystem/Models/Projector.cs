namespace EquipmentRentalSystem.Models;

public class Projector: Equipment
{
    public string Resolution { get; private set; }
    public int BrightnessInLumens { get; private set; }
    
    public Projector(string name, string resolution, int brightnessInLumens): base(name)
    {
        Resolution = resolution;
        BrightnessInLumens = brightnessInLumens;
    }
}