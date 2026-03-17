using System;
namespace EquipmentRentalSystem.Models;

public abstract class User
{
    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public int MaxRentals { get; protected set; }

    protected User(string firstName, string lastName)
    {
        Id = Guid.NewGuid().ToString();
        FirstName = firstName;  
        LastName = lastName;
    }
}