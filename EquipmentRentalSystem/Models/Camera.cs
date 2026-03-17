namespace EquipmentRentalSystem.Models;

public class Camera: Equipment
{
    public double Megapixels { get; private set; }
    public bool HasLensIncluded {  get; private set; }
    
    public Camera(string name, double megapixels, bool hasLensIncluded):base(name)
    {
        Megapixels = megapixels;
        HasLensIncluded = hasLensIncluded;
    }
}