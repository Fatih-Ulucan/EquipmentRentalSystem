using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentRentalSystem.Models;

namespace EquipmentRentalSystem.Services;

public class RentalService
{
    private readonly List<Equipment> _equipments = new();
    private readonly List<User> _users = new();
    private readonly List<Rental> _rentals = new();

    public void AddUser(User user)
    {
        _users.Add(user);
        Console.WriteLine($"User added: {user.FirstName} {user.LastName}");
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
        Console.WriteLine($"Equipment added: {equipment.Name}");
    }

    public void DisplayAllEquipment()
    {
        Console.WriteLine("\n--- All Equipment ---");
        foreach (var eq in _equipments)
        {
            string status = eq.IsAvailable ? "Available" : "Unavailable";
            Console.WriteLine($"- {eq.Name} (ID: {eq.Id.Substring(0,8)}...) Status: {status}");
        }
    } 

    public void DisplayAvailableEquipment()
    {
        Console.WriteLine("\n--- Available Equipment ---");
        var availableEq = _equipments.Where(e => e.IsAvailable).ToList();
    
        if (!availableEq.Any())
        {
            Console.WriteLine("No equipment is currently available.");
            return;
        }

        foreach (var eq in availableEq)
        {
            Console.WriteLine($"- {eq.Name} (ID: {eq.Id.Substring(0,8)}...)");
        }
    }

    public void RentEquipment(User user, Equipment equipment, int durationInDays)
    {
        if (!equipment.IsAvailable)
        {
            Console.WriteLine($"Error: '{equipment.Name}' is not available for rental.");
            return;
        }

        int activeRentals = _rentals.Count(r => r.RentedBy.Id == user.Id && r.ReturnDate == null);
    
        if (activeRentals >= user.MaxRentals)
        {
            Console.WriteLine($"Error: User '{user.FirstName}' has reached the maximum limit of {user.MaxRentals} active rentals.");
            return;
        }

        Rental rental = new Rental(user, equipment, durationInDays);
        _rentals.Add(rental);
        equipment.MarkAsUnavailable();

        Console.WriteLine($"Success: '{user.FirstName}' rented '{equipment.Name}' until {rental.DueDate.ToShortDateString()}.");
    }
    public void ReturnEquipment(User user, Equipment equipment, DateTime actualReturnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.RentedBy.Id == user.Id && r.RentedEquipment.Id == equipment.Id && r.ReturnDate == null);

        if (rental == null)
        {
            Console.WriteLine($"Error: No active rental found for '{user.FirstName}' and '{equipment.Name}'.");
            return;
        }

        decimal penalty = 0;
        if (actualReturnDate > rental.DueDate)
        {
            int daysLate = (actualReturnDate - rental.DueDate).Days;
            penalty = daysLate * 50; 
        }

        rental.CompleteRental(actualReturnDate, penalty);
        equipment.MarkAsAvailable();

        Console.WriteLine($"Success: '{user.FirstName}' returned '{equipment.Name}'. Penalty applied: {penalty}");
    }
}